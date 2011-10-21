using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Tobor_Rewop
{
    public class Entity
    {
        private String id;
        private List<Component> Components;
        private List<RenderComponent> RenderComponents;

        private Point Position;

        private Rectangle thisEntity;

        public Entity(String id)
        {
            this.id = id;
            Components = new List<Component>();
            RenderComponents = new List<RenderComponent>();
            Position = new Point(0, 0);
            thisEntity = new Rectangle();
        }

        // setter
        public void setPosition(int x, int y)
        {
            Position.X = x;
            Position.Y = y;
            thisEntity.Location = Position;
        }

        public void setSize(int width, int height)
        {
            thisEntity.Width = width;
            thisEntity.Height = height;
        }

        public void addComponent(Component comp)
        {
            comp.setOwnerEntity(this);
            Components.Add(comp);
        }

        public void addRenderComponent(RenderComponent Rend)
        {
            Rend.setOwnerEntity(this);
            RenderComponents.Add(Rend);
        }

        // getter
        public Point getPosition()
        {
            return Position;
        }

        public int getWidth()
        {
            return thisEntity.Width;
        }

        public int getHeight()
        {
            return thisEntity.Height;
        }

        public Rectangle getRect()
        {
            return thisEntity;
        }

        public List<Component> getComponentList()
        {
            return Components;
        }

        public List<RenderComponent> getRenderComponentList()
        {
            return RenderComponents;
        }

        // collusion detection
        public bool coolusionTest(Entity e)
        {
            return thisEntity.Intersects(e.getRect());
        }

        // update all component
        public void update(Game game, GameTime TimePassed)
        {
            foreach(Component c in Components)
            {
                c.update(game, TimePassed);
            }
        }

        // update all render
        public void render(Game game, GameTime TimePassed)
        {
            foreach (Component c in Components)
            {
                c.update(game, TimePassed);
            }
        }
    }
}
