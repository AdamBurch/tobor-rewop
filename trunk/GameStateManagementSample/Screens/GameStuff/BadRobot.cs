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
    public class BadRobot
    {
        Texture2D myTexture;
        Vector2 myPosition;
        public int HP;
        public Rectangle collisionBox;

        public bool isAlive;
        public BadRobot(ContentManager content, Vector2 initialPosition)
        {
            // TODO: Construct any child components here
            Random r = new Random();
            myPosition = initialPosition;
            isAlive = true;
            HP = r.Next(1, 3);
            this.LoadContent(content);
            collisionBox = new Rectangle((int)myPosition.X, (int)myPosition.Y,
                                         myTexture.Width, myTexture.Height);
        }

        protected void LoadContent(ContentManager content)
        {
            // robot
            myTexture = content.Load<Texture2D>("BadRobot");
        }


        public void Draw(GameTime gt, SpriteBatch sb)
        {
            sb.Draw(myTexture, new Rectangle((int)myPosition.X,
                       (int)myPosition.Y,
                       myTexture.Width,
                       myTexture.Height),
                       Color.White);
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public void Update(GameTime gameTime)
        {
            myPosition.X += 2;
            collisionBox.X = (int)myPosition.X;
            //offscreen???
            if (myPosition.X >= 600 - myTexture.Width)
                isAlive = false;
            if (HP <= 0)
                isAlive = false;
        }
    }
}
