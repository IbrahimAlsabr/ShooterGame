using System.Collections.Generic;

public class GameConfig
{
    public GeneralSettings GeneralSettings { get; set; }
    public List<Level> DifficultyLevels { get; set; }
    public UISettings UI { get; set; }
}

public class GeneralSettings
{
    public Screen Screen { get; set; }
    public Controls Controls { get; set; }
}

public class Screen
{
    public int Width { get; set; }
    public int Height { get; set; }
    public int FrameRate { get; set; }
}

public class Controls
{
    public string MoveUp { get; set; }
    public string MoveDown { get; set; }
    public string MoveLeft { get; set; }
    public string MoveRight { get; set; }
    public string ArrowUp { get; set; }
    public string ArrowDown { get; set; }
    public string ArrowLeft { get; set; }
    public string ArrowRight { get; set; }
    public string Pause { get; set; }
    public string Shoot { get; set; }
}

public class Level
{
    public string Name { get; set; }
    public Player Player { get; set; }
    public Enemies Enemies { get; set; }
    public Projectiles Projectiles { get; set; }
}

public class Player
{
    public int Speed { get; set; }
    public int Health { get; set; }
    public float ProjectileCooldown { get; set; }
}

public class Enemies
{
    public int SpawnRate { get; set; }
    public int MinSpeed { get; set; }
    public int MaxSpeed { get; set; }
    public int EnemiesNumber { get; set; }
}

public class Projectiles
{
    public int Speed { get; set; }
    public int Damage { get; set; }
}

public class UISettings
{
    public string Font { get; set; }
    public Position HealthPosition { get; set; }
    public Position ScorePosition { get; set; }
}

public class Position
{
    public int X { get; set; }
    public int Y { get; set; }
}