using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Snake.Core;
using System.Linq;
using Snake.Core.Maps;

namespace Snake.Core;

public class Player
{
    //private SnakeTile head;
    public int headPosition, tailPosition, secondPosition; 
    public List<SnakeTile> body;
    private bool dirUp, dirDown, dirLeft, dirRight;
    private bool dirChosen;

    public Player(){
        body = new List<SnakeTile>();
        body.Add(new SnakeTile(new Vector2(60, 120)));
        body.Add(new SnakeTile(new Vector2(60, 90)));
        body.Add(new SnakeTile(new Vector2(60, 60)));
        dirDown = true;
        headPosition = 0;
        //secondPosition = 1;
        //tailPosition = body.Count - 1;
    }

    public void Controls(){
        var kstate = Keyboard.GetState();

        if (kstate.IsKeyDown(Keys.W))
        {
            if(!dirDown && ! dirUp && dirChosen == false){
                dirUp = true;
                dirDown = false;
                dirLeft = false;
                dirRight = false;
                dirChosen = true;
            }
        }

        else if(kstate.IsKeyDown(Keys.S))
        {
            if(!dirUp && !dirDown && dirChosen == false){
                dirUp = false;
                dirDown = true;
                dirLeft = false;
                dirRight = false;
                dirChosen = true;
            }
        }

        else if (kstate.IsKeyDown(Keys.A))
        {
            if(!dirRight && !dirLeft && dirChosen == false){
                dirUp = false;
                dirDown = false;
                dirLeft = true;
                dirRight = false;
                dirChosen = true;
            }
        }

        else if(kstate.IsKeyDown(Keys.D))
        {
            if(!dirLeft && !dirRight && dirChosen == false){
                dirUp = false;
                dirDown = false;
                dirLeft = false;
                dirRight = true;
                dirChosen = true;
            }
        }
    }

    public void Move( GameTime gameTime, List<Rectangle> collisionList, ref List<Rectangle> emptyBlocksList, ref Collectible collectible){
    
            dirChosen = false;
         
            Vector2 lastBlockPosition = body[body.Count - 1].position;

            for(int i = body.Count - 1; i > 0; i--)
            {
                 body[i].position.Y = body[i - 1].position.Y;
                body[i].position.X = body[i - 1].position.X;

                body[i].collisionBox.Y = body[i - 1].collisionBox.Y;
                body[i].collisionBox.X = body[i - 1].collisionBox.X;
            }

            if(dirUp == true){
                body[headPosition].position.Y -= Game1.tileSize;
                body[headPosition].collisionBox.Y -= Game1.tileSize;
            }
            if(dirDown == true){
                body[headPosition].position.Y += Game1.tileSize;
                body[headPosition].collisionBox.Y += Game1.tileSize;
                
            }

             if(dirLeft == true){
                body[headPosition].position.X -= Game1.tileSize;
                body[headPosition].collisionBox.X -= Game1.tileSize;
                
            }
            if(dirRight == true){
                body[headPosition].position.X += Game1.tileSize;
                body[headPosition].collisionBox.X += Game1.tileSize;
                
            }   

            if(Game1.self.collectedFlag)
            {
                body.Add(new SnakeTile(lastBlockPosition));
                Game1.self.collectedFlag = false;
            }

            if(CollisionDetection.CollidesWithCollectible(this.body[headPosition].collisionBox, collectible.collisionBox))
            {
                Game1.self.score++;
                if(Game1.self.score > 5)
                    Game1.self.Exit();
                Game1.self.collectedFlag = true;
                collectible = Collectible.SpawnNewCollectible(emptyBlocksList, this.body);
            }
            
            if(CollisionDetection.CollidesWithWall(body[headPosition].collisionBox, collisionList) || CollisionDetection.CollidesWithSnakeBody(body[headPosition].collisionBox, this.body, headPosition))
                Game1.self.Exit();
    }

    public void Draw(SpriteBatch spriteBatch){
        foreach(SnakeTile tile in body){
            spriteBatch.Draw(SnakeTile.playerTile, tile.position, Color.White);
        }
    }
}
