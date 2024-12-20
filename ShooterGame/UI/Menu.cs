using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace ShooterGame.UI
{
    public class Menu
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private SpriteFont _font;
        private MouseState _currentMouseState;
        private MouseState _previousMouseState;

        private Rectangle _easyButton;
        private Rectangle _mediumButton;
        private Rectangle _hardButton;

        private Color _easyColor = Color.White;
        private Color _mediumColor = Color.White;
        private Color _hardColor = Color.White;

        private string _chosenLevel = "";

        // Public property to access the chosen level
        public string ChosenLevel => _chosenLevel;

        public Menu(GraphicsDeviceManager graphics)
        {
            _graphics = graphics;
        }

        public void LoadContent(ContentManager content)
        {
            _spriteBatch = new SpriteBatch(_graphics.GraphicsDevice);
            _font = content.Load<SpriteFont>("Fonts/DefaultFont");

            // Define button areas
            _easyButton = new Rectangle(200, 150, 200, 50);
            _mediumButton = new Rectangle(200, 250, 200, 50);
            _hardButton = new Rectangle(200, 350, 200, 50);
        }

        public void Update()
        {
            _previousMouseState = _currentMouseState;
            _currentMouseState = Mouse.GetState();

            Point mousePosition = _currentMouseState.Position;

            _easyColor = Color.White;
            _mediumColor = Color.White;
            _hardColor = Color.White;

            if (_easyButton.Contains(mousePosition))
            {
                _easyColor = Color.Yellow;
                if (IsLeftMouseClicked())
                {
                    _chosenLevel = "Easy";
                }
            }
            else if (_mediumButton.Contains(mousePosition))
            {
                _mediumColor = Color.Yellow;
                if (IsLeftMouseClicked())
                {
                    _chosenLevel = "Medium";
                }
            }
            else if (_hardButton.Contains(mousePosition))
            {
                _hardColor = Color.Yellow;
                if (IsLeftMouseClicked())
                {
                    _chosenLevel = "Hard";
                }
            }
        }

        public void Draw()
        {
            _graphics.GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            // Draw buttons
            DrawButton(_easyButton, "Easy", _easyColor);
            DrawButton(_mediumButton, "Medium", _mediumColor);
            DrawButton(_hardButton, "Hard", _hardColor);

            // Draw chosen level
            if (!string.IsNullOrEmpty(_chosenLevel))
            {
                _spriteBatch.DrawString(_font, "Chosen Level: " + _chosenLevel, new Vector2(200, 450), Color.White);
            }

            _spriteBatch.End();
        }

        private void DrawButton(Rectangle buttonRect, string text, Color color)
        {
            Texture2D buttonTexture = new Texture2D(_graphics.GraphicsDevice, 1, 1);
            buttonTexture.SetData(new[] { Color.Gray });

            _spriteBatch.Draw(buttonTexture, buttonRect, color);

            Vector2 textSize = _font.MeasureString(text);
            Vector2 textPosition = new Vector2(
                buttonRect.X + (buttonRect.Width - textSize.X) / 2,
                buttonRect.Y + (buttonRect.Height - textSize.Y) / 2
            );

            _spriteBatch.DrawString(_font, text, textPosition, Color.Black);
        }

        private bool IsLeftMouseClicked()
        {
            return _currentMouseState.LeftButton == ButtonState.Pressed &&
                   _previousMouseState.LeftButton == ButtonState.Released;
        }
    }
}
