namespace Snake.Core.GameStates;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;


public abstract class State
{
    public abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch, SpriteFont font);
    public abstract void Update(GameTime gameTime);
}