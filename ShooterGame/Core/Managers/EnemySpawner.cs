using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace ShooterGame.Core
{
    public class EnemySpawner
    {
        private ContentManager _content;
        private readonly Random _random = new Random();
        private float _timeSinceLastSpawn = 0f;
        private float _spawnCooldown = 2f;
        private int _maxSpeed;
        private int _minSpeed;
        private GraphicsDeviceManager _graphics;
        private int _enemiesToSpawn;
        private int _spawnedEnemies;

        public EnemySpawner(GraphicsDeviceManager graphics, int maxSpeed, int minSpeed, int enemiesToSpawn,
            ContentManager content)
        {
            _graphics = graphics;
            _maxSpeed = maxSpeed;
            _minSpeed = minSpeed;
            _enemiesToSpawn = enemiesToSpawn;
            _spawnedEnemies = 0;
            _content = content;
        }

        public void SpawnEnemies(
            GameTime gameTime,
            List<Enemy> enemies)
        {
            if (_spawnedEnemies >= _enemiesToSpawn)
                return;

            _timeSinceLastSpawn += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (_timeSinceLastSpawn >= _spawnCooldown)
            {
                float randomY = _random.Next(0, _graphics.PreferredBackBufferHeight - 100);
                float randomX = _graphics.PreferredBackBufferWidth;
                float randomScale = (float)_random.NextDouble() * 0.7f + 0.5f;

                var enemy = new Enemy(
                    new Vector2(randomX, randomY),
                    new Vector2(-_random.Next(_minSpeed, _maxSpeed), _random.Next(-20, 20)),
                    randomScale
                );

                enemy.LoadContent(_content);
                enemies.Add(enemy);

                _spawnedEnemies++;
                _timeSinceLastSpawn = 0f;
                _spawnCooldown = _random.Next(1, 3);
            }
        }

        public bool HasFinishedSpawning()
        {
            return _spawnedEnemies >= _enemiesToSpawn;
        }
    }
}