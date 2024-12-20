using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace ShooterGame.Core
{
    public static class CollisionManager
    {
        private static void CheckPlayerEnemyCollisions(
            Player player, List<Enemy> enemies, Action onPlayerEnemyCollision = null
        )
        {
            // Check collisions between player and enemies
            foreach (var enemy in enemies)
            {
                Rectangle playerBounds = new Rectangle(
                    (int)player.PlayerPosition.X,
                    (int)player.PlayerPosition.Y,
                    player.Width,
                    player.Height
                );

                Rectangle enemyBounds = new Rectangle(
                    (int)enemy.Position.X,
                    (int)enemy.Position.Y,
                    enemy.Width,
                    enemy.Height
                );

                if (playerBounds.Intersects(enemyBounds))
                {
                    onPlayerEnemyCollision?.Invoke();
                    return;
                }
            }
        }

        private static void CheckProjectilesEnemyCollisions(
            Player player, List<Enemy> enemies, List<Projectile> projectiles
        )
        {
            for (int i = projectiles.Count - 1; i >= 0; i--)
            {
                var projectile = projectiles[i];

                for (int j = enemies.Count - 1; j >= 0; j--)
                {
                    var enemy = enemies[j];

                    Rectangle projectileBounds = new Rectangle(
                        (int)projectile.Position.X,
                        (int)projectile.Position.Y,
                        projectile.Width,
                        projectile.Height
                    );

                    Rectangle enemyBounds = new Rectangle(
                        (int)enemy.Position.X,
                        (int)enemy.Position.Y,
                        enemy.Width,
                        enemy.Height
                    );

                    if (enemyBounds.Intersects(projectileBounds))
                    {
                        projectile.Deactivate();
                        enemy.TakeDamage(projectile.Damage);

                        if (enemy.Health <= 0)
                        {
                            enemies.RemoveAt(j);
                            player.UpdateScore(enemy.enemySize);
                        }

                        projectiles.RemoveAt(i);
                        break;
                    }
                }
            }
        }

        public static void CheckCollisions(
            Player player, List<Enemy> enemies, List<Projectile> projectiles, Action onPlayerEnemyCollision
        )
        {
            // Check collisions between player and enemies
            CheckPlayerEnemyCollisions(
                player, enemies, onPlayerEnemyCollision
            );

            // Check collisions between projectiles and enemies
            CheckProjectilesEnemyCollisions(
                player, enemies, projectiles
            );

            // Cleanup inactive projectiles and enemies
            projectiles.RemoveAll(p => !p.IsActive);
            enemies.RemoveAll(e => e.Health <= 0);
        }
    }
}