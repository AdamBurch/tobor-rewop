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
    public class Turrent
    {
        Texture2D myTexture;
        Vector2 myPosition;
        Color myColor = Color.White;
        public Turrent(ContentManager content, Vector2 myPos)
        {
            // TODO: Construct any child components here
            myPosition = myPos;
            this.LoadContent(content);
        }

        protected void LoadContent(ContentManager content)
        {
            myTexture = content.Load<Texture2D>("testTurrent");
        }

        //in thie future this will need to take the POWER of the fire, for charging!!!
        public void fire()
        {
            GameplayScreen.fireBullet(myPosition);
        }

        public int getWidth()
        {
            return myTexture.Width;
        }

        public void Draw(GameTime gameTime, SpriteBatch sb)
        {
            sb.Draw(myTexture,
                    new Rectangle((int)myPosition.X,
                        (int)myPosition.Y, 
                        myTexture.Width, 
                        myTexture.Height),
                    myColor);
        }
    }
}
