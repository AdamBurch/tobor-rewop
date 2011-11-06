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


        public Tower(ContentManager content)
        {
            myStacks = new List<TurrentStack>();
            myStacks.Add(new TurrentStack(content));
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public  void Update(GameTime gameTime)
        {
            // TODO: Add your update code here
        }

        public void Draw(GameTime gameTime, SpriteBatch sb)
        {
            for (int i = 0; i < myStacks.Count; i++ )
            {
                myStacks[i].Draw(gameTime, sb, i);
            }
        }
    }
}
