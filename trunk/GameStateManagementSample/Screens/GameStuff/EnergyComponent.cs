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
    public class EnergyComponent
    {
        Texture2D myTexture;
        Vector2 myPosition;
        TimeSpan myTimer;
        bool touchedLastFrame;

        public EnergyComponent(ContentManager content, Vector2 myPos)
        {
            myPosition = myPos;
            touchedLastFrame = false;
            myTimer = new TimeSpan();
            this.LoadContent(content);
        }

        protected void LoadContent(ContentManager content)
        {
            myTexture = content.Load<Texture2D>("battery");
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public void Update(GameTime gameTime, bool turretTouched, ref Turrent myTurret, ref EnergyBar daBar)
        {
            myTimer = myTimer.Add(gameTime.ElapsedGameTime);

            // TODO: Add your update code here
            if (turretTouched && daBar.hasAvailable(2))
            {

                if (!touchedLastFrame)
                {
                    daBar.takeEnergy(2);
                    myTurret.fire();
                    myTimer = new TimeSpan();
                }
                else if(myTimer.Seconds >= 1)
                {
                    daBar.takeEnergy(2);
                    myTurret.fire();
                    myTimer = new TimeSpan();
                }

 
            }

            touchedLastFrame = turretTouched;
        }

        public void Draw(GameTime gT, SpriteBatch sb)
        {
            sb.Draw(myTexture, new Rectangle((int)myPosition.X,
                        (int)myPosition.Y, 
                        myTexture.Width, 
                        myTexture.Height),
                        Color.White);
 
        }
    }
}
