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
    public class EnergyBar
    {
        Texture2D myTexture;
        TimeSpan myTimer;
        double powerRemaining = 0;
        double totalPower = 0;

        public EnergyBar(ContentManager content)
        {
            // TODO: Construct any child components here
            powerRemaining = 100;
            totalPower = 100;
            myTimer = new TimeSpan();

            this.LoadContent(content);
        }

        protected  void LoadContent(ContentManager content)
        {
            myTexture = content.Load<Texture2D>("energyBar");
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public void Update(GameTime gameTime)
        {
            // TODO: Add your update code here

            myTimer = myTimer.Add(gameTime.ElapsedGameTime);

            if (myTimer.Seconds >= 1)
            {
                myTimer = new TimeSpan();
                if(powerRemaining < totalPower)
                    powerRemaining += 3;
            }
        }

        public bool hasAvailable(int power)
        {
            return powerRemaining > power;
        }

        public bool takeEnergy(int power)
        {
            if (powerRemaining > power)
            {
                powerRemaining -= power;
                return true;
            }
            else
            {
                return false;
            }
        }


        //we need to use a screen hieght and width pulled from the PROPER place! NO HARDCODING!!!
        public void Draw(GameTime gameTime, SpriteBatch sb)
        {
            sb.Draw(myTexture,
                    new Rectangle((800 - myTexture.Width),
                        (int)(480 - (480 * powerRemaining/totalPower)), 
                        myTexture.Width, 
                        myTexture.Height),
                    Color.White);
        }

        public int getWidth()
        {
            return myTexture.Width;
        }
    }
}
