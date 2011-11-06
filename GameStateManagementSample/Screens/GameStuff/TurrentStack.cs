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
        public TurrentStack(ContentManager content)
        {
            // TODO: Construct any child components here
            this.LoadContent(content);
        }

        protected void LoadContent(ContentManager content)
        {
            myTexture = content.Load<Texture2D>("stack");
        }

        public void Draw(GameTime gameTime, SpriteBatch sb, int myPosition, int xOffset)
        {
            sb.Draw(myTexture,
                    new Rectangle((800 - myTexture.Width - xOffset),
                        480 - myTexture.Height * (myPosition+1), 
                        myTexture.Width, 
                        myTexture.Height),
                    Color.White);
        }
    }
}
