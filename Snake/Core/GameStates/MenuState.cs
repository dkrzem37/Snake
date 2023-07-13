using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Snake.Core.GameStates;


public class MenuState : State
{

    public override void Draw(GameTime gameTime, SpriteBatch spriteBatch, SpriteFont font)
    {
        spriteBatch.DrawString( font, "Start Game", new Vector2(Data.ScreenW / 2 - 30, Data.ScreenH / 2), Color.White);
        
    }

    public override void Update(GameTime gameTime)
    {
        throw new System.NotImplementedException();
    }
}