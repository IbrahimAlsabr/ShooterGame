namespace ShooterGame.Core;

using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

public class Player
{
    public Vector2 PlayerPosition { get; private set; }
    public int Health { get; private set; }
    private Texture2D _texture;

    private float _speed = 200f;
    private GraphicsDeviceManager _graphics;
    private int _score = 0;

    public Player(Vector2 startPosition, GraphicsDeviceManager graphics)
    {
        PlayerPosition = startPosition;
        Health = 3;
        _graphics = graphics;
    }

    public void LoadContent(ContentManager content)
    {
        _texture = content.Load<Texture2D>("Player");
    }

    public void Update(GameTime gameTime)
    {
        HandleInput(gameTime);

        float clampedX = MathHelper.Clamp(
            PlayerPosition.X,
            _texture.Width - 25,
            _graphics.PreferredBackBufferWidth
        );

        float clampedY = MathHelper.Clamp(
            PlayerPosition.Y,
            0,
            _graphics.PreferredBackBufferHeight - _texture.Height - 25
        );

        PlayerPosition = new Vector2(clampedX, clampedY);
    }

    private void HandleInput(GameTime gameTime)
    {
        KeyboardState state = Keyboard.GetState();
        Vector2 movement = Vector2.Zero;

        if (state.IsKeyDown(Keys.Up))
            movement.Y -= 1;
        if (state.IsKeyDown(Keys.Down))
            movement.Y += 1;
        if (state.IsKeyDown(Keys.Left))
            movement.X -= 1;
        if (state.IsKeyDown(Keys.Right))
            movement.X += 1;

        // Normalize diagonal movement and apply _speed
        if (movement.Length() > 0)
        {
            movement.Normalize();
            PlayerPosition += movement * _speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        if (_texture != null)
            spriteBatch.Draw(
                _texture,
                PlayerPosition,
                null,
                Color.White,
                MathHelper.ToRadians(90),
                Vector2.Zero,
                1,
                SpriteEffects.None,
                0
            );
    }

    public int Width => _texture.Width;

    public int Height => _texture.Height;

    public void UpdateScore(int score)
    {
        _score += score;
    }

    public int Score => _score;
}