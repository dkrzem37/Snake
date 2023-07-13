using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Snake.Core;

public static class CollisionDetection
{
    public static bool CollidesWithWall(Rectangle head, List<Rectangle> collisionMap)
    {
        foreach(Rectangle wall in collisionMap)
        {
            if(head.Intersects(wall))
                return true;
        }

        return false;
    }
    public static bool CollidesWithCollectible(Rectangle head, Rectangle collectible )
    {
        if(collectible.Intersects(head))
            return true;
        return false;
    }
    public static bool CollidesWithSnakeBody(Rectangle head, List<SnakeTile> snakeBody, int headPosition)
    {
        for(int i = 0; i < snakeBody.Count; ++i)
        {
         if(i != headPosition)   
            if(snakeBody[i].collisionBox.Intersects(head))
                return true;
        }
        return false;
    }
}