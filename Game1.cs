using System;
using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.VisualBasic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Monogame;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    Player player;

    Texture2D pixel;
    List<BaseClass> enemies = new List<BaseClass>();
    
    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        pixel = new Texture2D(GraphicsDevice,1,1);
        pixel.SetData(new Color[]{Color.White});

        player = new Player(pixel);
        enemies.Add(new Enemy(pixel, new Vector2(400,10)));
        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here
        
        player.Update();
        foreach(var enemy in enemies){
            enemy.Update();
        }
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here
        _spriteBatch.Begin();
        foreach(var enemy in enemies){
            enemy.Draw(_spriteBatch);
        }
        player.Draw(_spriteBatch);
        _spriteBatch.End();

        base.Draw(gameTime);
    }

    public void RemoveEnemy(){
        List<BaseClass> temp = new List<BaseClass>();
        MouseState ms = Mouse.GetState();
        foreach (var enemy in enemies){
            if(enemy.Rectangle.Contains(ms.Position)){
                temp.Add(enemy);
            }
        }

        enemies = temp;
    }

    public void AddEnemy(){
        Random rand = new Random();
        enemies.Add(new Enemy(pixel, new Vector2(rand.Next(0,700))));
    }
}