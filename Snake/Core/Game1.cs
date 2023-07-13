using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Snake.Core.GameStates;
using Snake.Core.Maps;
using System.Collections.Generic;




namespace Snake.Core;

public class Game1 : Game
{
    
    public static Game1 self;
    private Texture2D obramowka;
    //Texture2D ballTexture, squareTexture;
    //Vector2 squarePosition;
    public const float tickTime = 0.07f;
    public const int tileSize = 30;
    public int score;
    float tickTimeMeasure;
    Player player;
    public static GraphicsDeviceManager graphics;
    private SpriteBatch spriteBatch;
    Map01 map;
    Collectible collectible;
    public bool collectedFlag;
    private SpriteFont scoreFont;
    private State currentState;

    public Game1()
    {
        self = this;
        graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        //squarePosition = new Vector2((Data.ScreenW / 30) * 14, (Data.ScreenH / 30) * 14);
        currentState = new MenuState();
        score = 0;
        map = new Map01();
        player = new Player();
        tickTimeMeasure = tickTime;
        //System.Console.WriteLine(Map01.test + " Udalo sie");
        graphics.PreferredBackBufferWidth = Data.ScreenW;
        graphics.PreferredBackBufferHeight = Data.ScreenH;
        graphics.ApplyChanges();
        // for(int i = 0; i< 3; ++i){
        //     var itemToRemove = player.body[i].collisionBox;
        //     map.emptyBlocksList.Remove(itemToRemove);
        // }
        collectible = new Collectible(new Point(600, 600));
        Collectible.possibleSpawnBlocks = new List<Rectangle>(map.emptyBlocksList);
        collectedFlag = false;
        // foreach(Rectangle rec in map.emptyBlocksList)
        // {
        //     System.Console.WriteLine("PosX: " + rec.X);
        //     System.Console.WriteLine("PosY: " + rec.Y);
        // }
        base.Initialize();
    }

    protected override void LoadContent()
    {
        spriteBatch = new SpriteBatch(GraphicsDevice);
        
        //map.boarderTexture = Content.Load<Texture2D>("images/block");
        //ballTexture = Content.Load<Texture2D>("images/ball");
        //squareTexture = Content.Load<Texture2D>("images/block");
        map.blockTexture = Content.Load<Texture2D>("images/block");
        map.passableBlockTexture = Content.Load<Texture2D>("images/passableBlock");
        SnakeTile.playerTile = Content.Load<Texture2D>("images/block");
        Collectible.Texture = Content.Load<Texture2D>("images/block");
        obramowka = Content.Load<Texture2D>("images/green");
        scoreFont = Content.Load<SpriteFont>("fonts/score");
        
    }

    protected override void Update(GameTime gameTime)
    {
        tickTimeMeasure -= (float)gameTime.ElapsedGameTime.TotalSeconds;
        if(tickTimeMeasure < 0){
            tickTimeMeasure = tickTime;
            //squarePosition.Y -= 30;
            player.Move( gameTime, map.wallRectanglesList, ref map.emptyBlocksList, ref collectible);
        }
        if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();


        player.Controls();

        

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        spriteBatch.Begin();
        //spriteBatch.Draw(ballTexture, new Vector2(0,0), Color.White);

        //currentState.Draw(gameTime, spriteBatch, scoreFont);

        map.Draw(spriteBatch);
        collectible.Draw(spriteBatch);
        player.Draw(spriteBatch);

        spriteBatch.DrawString(scoreFont, "Score: " + score, new Vector2(Data.ScreenW / 2 - 30, 0), Color.White);


        //move this to game state
        //
        


        //collectible.Draw(spriteBatch);

        // foreach(Rectangle rec in Collectible.possibleSpawnBlocks)
        // {
        //     spriteBatch.Draw(obramowka, rec,  Color.White);
        // }
        
        //spriteBatch.Draw(squareTexture, squarePosition, null,  Color.White, 0f, new Vector2(squareTexture.Width / 2, squareTexture.Height / 2), Vector2.One, SpriteEffects.None, 0f);
        //spriteBatch.Draw(squareTexture, squarePosition,  Color.White);

        spriteBatch.End();

        base.Draw(gameTime);
    }
}
