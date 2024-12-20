namespace ShooterGame.Core;

using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

public class Enemy
{
    public Vector2 Position { get; private set; }
    public int Health { get; private set; }
    private Texture2D _texture;
    private Vector2 _velocity;
    private float _scale;

    public Enemy(Vector2 startPosition, Vector2 startVelocity, float scale)
    {
        Position = startPosition;
        _velocity = startVelocity;
        Health = 1;
        _scale = scale;
    }

    public void LoadContent(ContentManager content)
    {
        _texture = content.Load<Texture2D>("Enemy");
    }

    public void Update(GameTime gameTime)
    {
        Position += _velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        if (Health < 0) Health = 0;
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        if (_texture != null)
        {
            spriteBatch.Draw(
                _texture,
                Position,
                null,
                Color.White,
                0f,
                Vector2.Zero,
                _scale,
                SpriteEffects.None,
                0f
            );
        }
    }

    public int Width => (int)(_texture.Width * Scale);
    public int Height => (int)(_texture.Height * Scale);

    public float Scale { get; private set; } = 0.5f;

    public int enemySize => (int)(_scale * 100);
}