using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Tobor_Rewop
{
    public abstract class RenderComponent : Component
    {
        public RenderComponent(String id)
        {
            this.id = id;
        }

        abstract public void render(Game game, GameTime gameTime, SpriteBatch sb);
    }
}
