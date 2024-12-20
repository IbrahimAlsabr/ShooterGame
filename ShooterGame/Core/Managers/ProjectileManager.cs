using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ShooterGame.Core
{
    public class ProjectileManager
    {
        private ContentManager _content;
        private int _speed;

        public ProjectileManager( int speed, ContentManager content)
        {
            // _projectileTexture = projectileTexture;
            _speed = speed;
            _content = content;
        }

        public void HandleShooting(
            Player player,
            List<Projectile> projectiles,
            ref float timeSinceLastShot,
            float shotCooldown)
        {
            KeyboardState state = Keyboard.GetState();

            if (state.IsKeyDown(Keys.Space) && timeSinceLastShot >= shotCooldown)
            {
                Vector2 projectilePosition = player.PlayerPosition + new Vector2(20, 0);
                Vector2 projectileVelocity = new Vector2(_speed, 0);
                projectiles.Add(new Projectile(projectilePosition, projectileVelocity, 1));
                projectiles[^1].LoadContent(_content);
                timeSinceLastShot = 0f;
            }
        }
    }
}