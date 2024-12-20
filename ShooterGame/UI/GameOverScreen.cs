using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ShooterGame.UI
{
    public class GameOverScreen
    {
        private SpriteFont _font;
        private GraphicsDeviceManager _graphics;

        private Rectangle _restartButton;
        private Rectangle _exitButton;

        private Color _restartColor = Color.White;
        private Color _exitColor = Color.White;

        public GameOverScreen(GraphicsDeviceManager graphics)
        {
            _graphics = graphics;
        }

        public void LoadContent(SpriteFont font)
        {
            _font = font;

            // Define button areas
            _restartButton = new Rectangle(300, 300, 200, 50);
            _exitButton = new Rectangle(300, 400, 200, 50);
        }

        public string Update(GameTime gameTime)
        {
            MouseState mouseState = Mouse.GetState();
            Point mousePosition = mouseState.Position;

            // Check hover and click
            if (_restartButton.Contains(mousePosition) && mouseState.LeftButton == ButtonState.Pressed)
                return "Restart";

            if (_exitButton.Contains(mousePosition) && mouseState.LeftButton == ButtonState.Pressed)
                return "Exit";

            return null;
        }

        public void Draw(SpriteBatch spriteBatch, int finalScore)
        {
            // No Begin/End here; assume it's handled externally
            spriteBatch.DrawString(
                _font,
                "Game Over",
                new Vector2(300, 200),
                Color.Red
            );

            spriteBatch.DrawString(
                _font,
                $"Final Score: {finalScore}",
                new Vector2(300, 250),
                Color.White
            );

            DrawButton(spriteBatch, _restartButton, "Restart", _restartColor);
            DrawButton(spriteBatch, _exitButton, "Exit", _exitColor);
        }


        private void DrawButton(SpriteBatch spriteBatch, Rectangle buttonRect, string text, Color color)
        {
            Texture2D buttonTexture = new Texture2D(_graphics.GraphicsDevice, 1, 1);
            buttonTexture.SetData(new[] { Color.Gray });

            spriteBatch.Draw(buttonTexture, buttonRect, color);

            Vector2 textSize = _font.MeasureString(text);
            Vector2 textPosition = new Vector2(
                buttonRect.X + (buttonRect.Width - textSize.X) / 2,
                buttonRect.Y + (buttonRect.Height - textSize.Y) / 2
            );

            spriteBatch.DrawString(_font, text, textPosition, Color.Black);
        }
    }
}