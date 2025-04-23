using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Heathen;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private SpriteFont _gameFont;


    private Texture2D _backgroundTexture;
    private List<Texture2D> _cardTextures;
    

    private Vector2 _firstCardPosition;
    private int _cardSpacing = 250;
    
    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        
        _graphics.PreferredBackBufferWidth = 1600;
        _graphics.PreferredBackBufferHeight = 800;
    }

    protected override void Initialize()
    {
        _cardTextures = new List<Texture2D>();
        _firstCardPosition = new Vector2(300, 200);
        
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        _gameFont = Content.Load<SpriteFont>("belligerent");
        _backgroundTexture = Content.Load<Texture2D>("images/background/teastain64");
        
        _cardTextures.Add(Content.Load<Texture2D>("images/cards/00-TheFool"));
        _cardTextures.Add(Content.Load<Texture2D>("images/cards/01-TheMagician"));
        _cardTextures.Add(Content.Load<Texture2D>("images/cards/02-TheHighPriestess"));
        _cardTextures.Add(Content.Load<Texture2D>("images/cards/03-TheEmpress"));
      
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();
        
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Black);

        _spriteBatch.Begin();
        
        _spriteBatch.DrawString(_gameFont, "Hello MonoGame!", new Vector2(100, 100), Color.White);

        _spriteBatch.Draw(_backgroundTexture, new Rectangle(0, 0, 
            _graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight), Color.White);
        
     
        for (int i = 0; i < _cardTextures.Count; i++)
        {
            Vector2 position = new Vector2(_firstCardPosition.X + (i * _cardSpacing), _firstCardPosition.Y);
            
            float scale = 0.5f; 
            
            _spriteBatch.Draw(
                _cardTextures[i],
                position,
                null,
                Color.White,
                0f,
                Vector2.Zero,
                scale,
                SpriteEffects.None,
                0f
            );
        }
        
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}