using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Monogame
{
    public class Player : BaseClass
    {
        public Player(Texture2D texture):  base(texture, new Vector2(400,240)){
            color = Color.White;
        }

        public override void Update(){
            KeyboardState kState = Keyboard.GetState();
            if(kState.IsKeyDown(Keys.W)){
            position.Y -= 5;
            }
            if(kState.IsKeyDown(Keys.S)){
            position.Y += 5;
            }
            if(kState.IsKeyDown(Keys.A)){
            position.X -= 5;
            }

            if(kState.IsKeyDown(Keys.D)){
            position.X += 5;
            }
        }
    }
}