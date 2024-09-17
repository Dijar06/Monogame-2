using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Monogame
{
    public class BaseClass
    {
        protected Vector2 position;
        protected Texture2D texture;
        protected Color color;
        protected Rectangle rectangle;
        
        public Rectangle Rectangle{
            get {return rectangle;}
            set {rectangle = value;}
        }
        public BaseClass(Texture2D texture, Vector2 position)
        {
            this.texture = texture;
            this.position = position;
            color = Color.White;
        }

        public void Draw(SpriteBatch spriteBatch){
            rectangle = new Rectangle((int)position.X, (int)position.Y,100,100);
            spriteBatch.Draw(texture, rectangle, color);
        }

        public virtual void Update(){}
    }
}