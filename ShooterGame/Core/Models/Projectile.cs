namespace ShooterGame.Core;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

public class Projectile
{
    public Vector2 Position { get; private set; }
    private Vector2 _velocity;
    private Texture2D _texture;

    public int Damage { get; private set; }
    public bool IsActive { get; private set; }

    public Projectile(Vector2 startPosition, Vector2 startVelocity, int damage) 
    {
        Position = startPosition;
        _velocity = startVelocity;
        Damage = damage;
        IsActive = true;
    }

    public void LoadContent(ContentManager content)
    {
        _texture = content.Load<Texture2D>("Projectile");
        
    }

    public void Update(GameTime gameTime)
    {
        Position += _velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;

        // Deactivate if out of bounds (example: screen bounds)
        if (Position.X < 0 || Position.X > 900 || Position.Y < 0 || Position.Y > 900)
        {
            IsActive = false;
        }
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        if (IsActive && _texture != null)
            spriteBatch.Draw(
                _texture,
                Position,
                null,
                Color.White,
                MathHelper.ToRadians(90),
                Vector2.Zero,
                0.2f,
                SpriteEffects.None,
                0.0f
            );
    }

    public void Deactivate()
    {
        IsActive = false;
    }

    public float Scale { get; private set; } = 0.2f;
    public int Width => (int)(_texture.Width * Scale);
    public int Height => (int)(_texture.Height * Scale);
}