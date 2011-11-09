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
        EnergyComponent myComponent;
        public Vector2 myPosition;
        bool touchMyTurret;
        public TurrentStack(ContentManager content, int stackPos, int xOffset)
        {
            // TODO: Construct any child components here

            this.LoadContent(content);

            myPosition = new Vector2((800 - myTexture.Width - xOffset),
                        480 - myTexture.Height * (stackPos + 1));
 

            myTurrent = new Turrent(content, myPosition);
            myComponent = new EnergyComponent(content, new Vector2(myPosition.X + myTurrent.getWidth(), myPosition.Y));
            
        }

        public void touched()
        {
            touchMyTurret = true;
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

        public void Update(GameTime gameTime, ref EnergyBar daBar)
        {
            myComponent.Update(gameTime, touchMyTurret, ref myTurrent, ref daBar);
            touchMyTurret = false;
        }

        public void Draw(GameTime gameTime, SpriteBatch sb)
        {
            sb.Draw(myTexture,
                    new Rectangle((int)myPosition.X,
                        (int)myPosition.Y, 
                        myTexture.Width, 
                        myTexture.Height),
                    Color.White);


            myComponent.Draw(gameTime, sb);
            myTurrent.Draw(gameTime, sb);
        }
    }
}
