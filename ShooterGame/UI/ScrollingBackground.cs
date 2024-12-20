using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace ShooterGame.UI
{
    public class ScrollingBackground
    {
        private Vector2 _screenPos;
        private Vector2 _origin;
        private Vector2 _textureSize;
        private Texture2D _texture;
        private int _screenWidth;

        public void LoadContent(GraphicsDevice device, ContentManager content)
        {
            _texture = content.Load<Texture2D>("Starfield");
            _screenWidth = device.Viewport.Width;
            int screenheight = device.Viewport.Height;

            _origin = new Vector2(0, _texture.Height / 2);
            _screenPos = new Vector2(_screenWidth / 2, screenheight / 2);
            _textureSize = new Vector2(_texture.Width, 0);
        }

        public void Update(float deltaX)
        {
            _screenPos.X -= deltaX;

            if (_screenPos.X < 0)
            {
                _screenPos.X += _texture.Width;
            }
        }

        public void Draw(SpriteBatch batch, Color color)
        {
            if (_screenPos.X < _screenWidth)
            {
                batch.Draw(_texture, _screenPos, null,
                    color, 0, _origin, 1, SpriteEffects.None, 0f);
            }

            batch.Draw(_texture, _screenPos - _textureSize, null,
                color, 0, _origin, 1, SpriteEffects.None, 0f);
        }
    }
}