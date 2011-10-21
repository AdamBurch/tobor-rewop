using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Tobor_Rewop
{
    public abstract class Component
    {
        protected String id;
        protected Entity owner;

        public String getId()
        {
            return id;
        }

        public void setOwnerEntity(Entity owner)
        {
            this.owner = owner;
        }

        public abstract void update(Game game, GameTime gameTime);
    }
}
