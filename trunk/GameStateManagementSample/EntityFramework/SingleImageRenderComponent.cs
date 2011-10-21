using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Tobor_Rewop
{
    public class SingleImageRenderComponent : RenderComponent
    {
        Texture2D img;
        public SingleImageRenderComponent(String id, Texture2D img) : base(id)
        {
            this.id = id;
            this.img = img;
        }

        public override void update(Game game, GameTime gameTime)
        {
            throw new NotImplementedException();
        }

        public override void render(Game game, GameTime gameTime, SpriteBatch sb) 
        {
            Console.WriteLine("WTF");
            Vector2 mPosition = new Vector2((float)owner.getPosition().X, owner.getPosition().Y);
            sb.Begin();
       
            sb.Draw(img, mPosition, Color.White);

            sb.End();
        }
    }
}
