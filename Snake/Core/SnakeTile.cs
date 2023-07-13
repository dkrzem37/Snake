using System.Collections;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace Snake.Core;

public class SnakeTile
{
    public static Texture2D playerTile;
    public Vector2 position;
    public Rectangle collisionBox;

    public SnakeTile(Vector2 position){
        this.position = position;
        this.collisionBox = new Rectangle((int) position.X, (int) position.Y, Game1.tileSize, Game1.tileSize );
    }

}
