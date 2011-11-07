using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace GameStateManagementSample.Screens
{
    class Turrent
    {
        Texture2D myTexture;
        Color myColor = Color.White;
        public Turrent(ContentManager content)
        {
            // TODO: Construct any child components here
            this.LoadContent(content);
        }

        public void touched()
        {
            myColor = Color.Yellow;
        }

        protected void LoadContent(ContentManager content)
        {
            myTexture = content.Load<Texture2D>("testTurrent");
        }

        public void Draw(GameTime gameTime, SpriteBatch sb, Vector2 stackPosition)
        {
            sb.Draw(myTexture,
                    new Rectangle((int)stackPosition.X,
                        (int)stackPosition.Y, 
                        myTexture.Width, 
                        myTexture.Height),
                    myColor);
        }
    }
}
