using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ShooterGame.Core
{
    public static class UIManager
    {
        public static void DrawUI(SpriteBatch spriteBatch, SpriteFont font, string playerName, int score, string level)
        {
            spriteBatch.DrawString(
                font,
                $"Name: {playerName}\nScore: {score}\nLevel: {level}",
                new Vector2(10, 10),
                Color.White
            );
        }
    }
}