using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Snake.Core;

public class Collectible
{
    public static Texture2D Texture{get; set; }
    public Rectangle collisionBox;
    public static List<Rectangle> possibleSpawnBlocks;
    public static System.Random rnd = new System.Random();


    public Collectible(Point position)
    {
        collisionBox = new Rectangle(position, new Point(Game1.tileSize, Game1.tileSize));
    }

    public static Collectible SpawnNewCollectible(List<Rectangle> emptyBlocksList, List<SnakeTile> snakeBody)
    {
        possibleSpawnBlocks = new List<Rectangle>(emptyBlocksList);
        foreach(SnakeTile st in snakeBody)
        {
            possibleSpawnBlocks.Remove(st.collisionBox);
        }

        int randomNum = rnd.Next(possibleSpawnBlocks.Count);
        return  new Collectible(new Point(possibleSpawnBlocks[randomNum].X, possibleSpawnBlocks[randomNum].Y));
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(Texture, collisionBox, Color.White);
    }

    
}