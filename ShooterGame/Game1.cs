using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ShooterGame.Core;
using ShooterGame.UI;

namespace ShooterGame;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private Menu _menu;
    private GameManager _gameManager;
    private ScrollingBackground _background;

    private enum GameState
    {
        Menu,
        Playing,
        GameOver
    }

    private GameState _currentGameState;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
    }

    protected override void Initialize()
    {
        _menu = new Menu(_graphics);
        _gameManager = new GameManager(_graphics, Content);
        _gameManager.Initialize();
        _currentGameState = GameState.Menu;

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        _menu.LoadContent(Content);
        _background = new ScrollingBackground();
        _background.LoadContent(GraphicsDevice, Content);
        _gameManager.LoadContent();
    }

    protected override void Update(GameTime gameTime)
    {
        // !! to see 
        if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        switch (_currentGameState)
        {
            case GameState.Menu:
                _menu.Update();
                _gameManager.Level = _menu.ChosenLevel;

                if (!string.IsNullOrEmpty(_menu.ChosenLevel))
                {
                    _currentGameState = GameState.Playing;
                }

                break;

            case GameState.Playing:
                var deltaX = (float)(gameTime.ElapsedGameTime.TotalSeconds * 100);
                _background.Update(deltaX);
                _gameManager.Update(gameTime);
                break;
            
            case GameState.GameOver:
                if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                {
                    // Restart the game
                    _gameManager.Initialize();
                    _gameManager.LoadContent();
                    _currentGameState = GameState.Menu; // Back to menu or GameState.Playing for direct restart
                }

                break;
        }

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        _spriteBatch.Begin();

        switch (_currentGameState)
        {
            case GameState.Menu:
                _menu.Draw();
                break;

            case GameState.Playing:
                _background.Draw(_spriteBatch, Color.White);
                _gameManager.Draw(_spriteBatch);
                break;

            case GameState.GameOver:
                _spriteBatch.DrawString(
                    Content.Load<SpriteFont>("Fonts/DefaultFont"),
                    "Game Over!\nPress Enter to Restart",
                    new Vector2(200, 300),
                    Color.Red
                );
                break;
        }

        _spriteBatch.End();
        base.Draw(gameTime);
    }
}