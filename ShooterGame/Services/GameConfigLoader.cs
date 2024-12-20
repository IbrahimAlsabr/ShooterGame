using System;
using System.IO;
using System.Xml.Serialization;

public class GameConfigLoader
{
    private GameConfig config;
    string configPath = "Data/XML/GameConfig.xml";

    public GameConfigLoader()
    {
        try
        {
            XmlSerializer serializer = new XmlSerializer(typeof(GameConfig));
            using (FileStream fileStream = new FileStream(configPath, FileMode.Open))
            {
                config = (GameConfig)serializer.Deserialize(fileStream);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erreur lors du chargement de la configuration : {ex.Message}");
        }
    }

    public int GetScreenWidth()
    {
        return config.GeneralSettings.Screen.Width;
    }

    public int GetScreenHeight()
    {
        return config.GeneralSettings.Screen.Height;
    }

    public int GetScreenFrameRate()
    {
        return config.GeneralSettings.Screen.FrameRate;
    }


    public int GetPlayerSpeed(string level)
    {
        switch (level.ToLower())
        {
            case "easy":
                return config.DifficultyLevels[0].Player.Speed;

            case "medium":
                return config.DifficultyLevels[1].Player.Speed;

            case "hard":
                return config.DifficultyLevels[2].Player.Speed;

            default:
                return 200;
        }
    }
    
    public int GetPlayerInitHealth(string level)
    {
        switch (level.ToLower())
        {
            case "easy":
                return config.DifficultyLevels[0].Player.Health;

            case "medium":
                return config.DifficultyLevels[1].Player.Health;

            case "hard":
                return config.DifficultyLevels[2].Player.Health;

            default:
                return 200;
        }
    }
    
    public double GetPlayerProjectileCooldown(string level)
    {
        switch (level.ToLower())
        {
            case "easy":
                return config.DifficultyLevels[0].Player.ProjectileCooldown;

            case "medium":
                return config.DifficultyLevels[1].Player.ProjectileCooldown;

            case "hard":
                return config.DifficultyLevels[2].Player.ProjectileCooldown;

            default:
                return 200;
        }
    }
    
    public int GetEnemySpawnRate(string level)
    {
        switch (level.ToLower())
        {
            case "easy":
                return config.DifficultyLevels[0].Enemies.SpawnRate;

            case "medium":
                return config.DifficultyLevels[1].Enemies.SpawnRate;

            case "hard":
                return config.DifficultyLevels[2].Enemies.SpawnRate;

            default:
                return 0;
        }
    }
    
    public int GetEnemyMinSpeed(string level)
    {
        switch (level.ToLower())
        {
            case "easy":
                return config.DifficultyLevels[0].Enemies.MinSpeed;

            case "medium":
                return config.DifficultyLevels[1].Enemies.MinSpeed;

            case "hard":
                return config.DifficultyLevels[2].Enemies.MinSpeed;

            default:
                return 0;
        }
    }
    
    public int GetEnemyMaxSpeed(string level)
    {
        switch (level.ToLower())
        {
            case "easy":
                return config.DifficultyLevels[0].Enemies.MaxSpeed;

            case "medium":
                return config.DifficultyLevels[1].Enemies.MaxSpeed;

            case "hard":
                return config.DifficultyLevels[2].Enemies.MaxSpeed;

            default:
                return 0;
        }
    }
    
    public int GetEnemiesNumber(string level)
    {
        switch (level.ToLower())
        {
            case "easy":
                return config.DifficultyLevels[0].Enemies.EnemiesNumber;

            case "medium":
                return config.DifficultyLevels[1].Enemies.EnemiesNumber;

            case "hard":
                return config.DifficultyLevels[2].Enemies.EnemiesNumber;

            default:
                return 0;
        }
    }
    
    public int GetProjectileSpeed(string level)
    {
        switch (level.ToLower())
        {
            case "easy":
                return config.DifficultyLevels[0].Projectiles.Speed;

            case "medium":
                return config.DifficultyLevels[1].Projectiles.Speed;

            case "hard":
                return config.DifficultyLevels[2].Projectiles.Speed;

            default:
                return 350;
        }
    }
    
    public int GetProjectileDamage(string level)
    {
        switch (level.ToLower())
        {
            case "easy":
                return config.DifficultyLevels[0].Projectiles.Damage;

            case "medium":
                return config.DifficultyLevels[1].Projectiles.Damage;

            case "hard":
                return config.DifficultyLevels[2].Projectiles.Damage;

            default:
                return 3;
        }
    }
}