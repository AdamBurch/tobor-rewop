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
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class TurrentStack
    {
        Texture2D myTexture;
        Turrent myTurrent;
        public Vector2 myPosition;
        public TurrentStack(ContentManager content)
        {
            // TODO: Construct any child components here

            myTurrent = new Turrent(content);
            this.LoadContent(content);
        }

        public void setPosition(int stackPos, int xOffset)
        {
            myPosition = new Vector2((800 - myTexture.Width - xOffset),
                        480 - myTexture.Height * (stackPos + 1));
 
        }

        public void touched()
        {
            myTurrent.touched();
        }

        protected void LoadContent(ContentManager content)
        {
            myTexture = content.Load<Texture2D>("stack");
        }

        public int getWidth()
        {
            return myTexture.Width;
        }
        public int getHeight()
        {
            return myTexture.Height;
        }

        public void Draw(GameTime gameTime, SpriteBatch sb)
        {
            sb.Draw(myTexture,
                    new Rectangle((int)myPosition.X,
                        (int)myPosition.Y, 
                        myTexture.Width, 
                        myTexture.Height),
                    Color.White);

            myTurrent.Draw(gameTime, sb, myPosition);
        }
    }
}
