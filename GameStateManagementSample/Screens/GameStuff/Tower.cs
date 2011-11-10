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
    public class Tower
    {
        //Texture2D myTexture;
        List<TurrentStack> myStacks;
        EnergyBar daBar;


        public Tower(ContentManager content)
        {
            daBar = new EnergyBar(content);

            myStacks = new List<TurrentStack>();
            for (int i = 0; i < 3; i++)
            {
                TurrentStack temp = new TurrentStack(content, i, daBar.getWidth());
                myStacks.Add(temp);
            }

            
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public  void Update(GameTime gameTime, Vector2 touchPosition)
        {
            // TODO: Add your update code here

            daBar.Update(gameTime);

            //TODO:
            //I don't like this at all! We should pass this as an update parameter...shouldn't we?
            //mixing paradigms. ughugh.
            int turrentTouched = calcualateTurrentTouched(touchPosition);
            if(turrentTouched != -1)
                myStacks[turrentTouched].touched();

            foreach (TurrentStack stack in myStacks)
            {
                stack.Update(gameTime, ref daBar);
            }
        }


        //tie this more into the turrent stacks themselves???
        private int calcualateTurrentTouched(Vector2 touchPosition)
        {
            int temp = -1;

            if (touchPosition.X > 700 - myStacks[0].getWidth())
            {
                for (int i = 0; i < myStacks.Count; i++)
                {
                    Rectangle stack = new Rectangle(
                        (int)myStacks[i].myPosition.X, 
                        (int)myStacks[i].myPosition.Y, 
                        myStacks[i].getWidth(), 
                        myStacks[i].getHeight());

                    Rectangle touch = new Rectangle(
                        (int)touchPosition.X,
                        (int)touchPosition.Y,
                        1,
                        1);

                    
                    if (stack.Intersects(touch))
                    { temp = i; break; }
                }
            }

            return temp;
        }

        public void Draw(GameTime gameTime, SpriteBatch sb)
        {
            daBar.Draw(gameTime, sb);

            for (int i = 0; i < myStacks.Count; i++ )
            {
                myStacks[i].Draw(gameTime, sb);
            }
        }
    }
}
