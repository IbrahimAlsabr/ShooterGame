using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System;
using ShooterGame.Services;
using ShooterGame.UI;

namespace ShooterGame.Core;

public class GameManager
{
    // Basic
    private GraphicsDeviceManager _graphics;
    private ContentManager _content;
    private SpriteFont _defaultFont;

    // Models
    private Player _player;
    private List<Enemy> _enemies;
    private List<Projectile> _projectiles;

    // Generators (Managers)
    private EnemySpawner _enemySpawner;
    private ProjectileManager _projectileManager;

    // Times
    private float _timeSinceLastShot = 0f;
    private float _shotCooldown = 1f;

    public bool IsGameEnd { get; private set; }

    public string Level = "medium";
    private GameConfigLoader _loader;
    private PlayerProfileLoader _profileLoader;

    public GameManager(GraphicsDeviceManager graphics, ContentManager content)
    {
        _enemies = new List<Enemy>();
        _projectiles = new List<Projectile>();
        _graphics = graphics;
        _content = content;
        _defaultFont = _content.Load<SpriteFont>("Fonts/DefaultFont");
    }

    public void Initialize()
    {
        _loader = new GameConfigLoader();
         _profileLoader = new PlayerProfileLoader();
        _player = new Player(new Vector2(100, 300), _graphics);
        _enemies = new List<Enemy>([]);
        _enemySpawner = new EnemySpawner(
            _graphics,
            _loader.GetEnemyMaxSpeed(Level),
            _loader.GetEnemyMinSpeed(Level),
            _loader.GetEnemiesNumber(Level),
            _content);
    }

    public void LoadContent()
    {
        _player.LoadContent(_content);
        _projectileManager = new ProjectileManager(500, _content);
    }

    public void Update(GameTime gameTime)
    {
        _timeSinceLastShot += (float)gameTime.ElapsedGameTime.TotalSeconds;
        _player.Update(gameTime);
        _projectileManager.HandleShooting(_player, _projectiles, ref _timeSinceLastShot, _shotCooldown);
        _enemySpawner.SpawnEnemies(gameTime, _enemies);

        foreach (var projectile in _projectiles)
            projectile.Update(gameTime);

        foreach (var enemy in _enemies)
            enemy.Update(gameTime);

        CollisionManager.CheckCollisions(
            _player, _enemies, _projectiles, () => { Console.WriteLine("Game Over!"); }
        );

        _projectiles.RemoveAll(p => !p.IsActive);
        if (_enemySpawner.HasFinishedSpawning())
        {
            // create and show thw score 
            Console.WriteLine("Score: " + _player.Score);
            IsGameEnd = true;
        }
    }


    public void Draw(SpriteBatch spriteBatch)
    {
        if (IsGameEnd)
        {
            Console.WriteLine("YOU WIN - YOUR SCORE IS :" + _player.Score);
            Console.WriteLine("LAST SCORE WAS :" + _profileLoader.GetLastScore());
            Console.WriteLine("LAST LEVEL WAS :" + _profileLoader.GetLastLevel());
        }

        _player.Draw(spriteBatch);

        foreach (var projectile in _projectiles)
            projectile.Draw(spriteBatch);

        foreach (var enemy in _enemies)
            enemy.Draw(spriteBatch);

        UIManager.DrawUI(spriteBatch, _defaultFont, _profileLoader.GetPlayerName(), _player.Score, Level);
    }
}