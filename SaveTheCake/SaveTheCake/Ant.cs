using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SaveTheCake
{
    class Ant
    {
        Vector2 location;
        Vector2 target;
        float speed;
        float rotation;
        Texture2D texture;

        public Ant(Vector2 s_location, Vector2 s_target, float s_speed, Texture2D s_texture)
        {
            location = s_location;
            target = s_target;
            speed = s_speed;
            texture = s_texture;
        }

        public void update()
        {
            //TODO: Make the ants move tward the target;
            rotation = angleTo(location, target);
            Vector2 move = new Vector2(0, 0);
            move.X = (float)Math.Cos(rotation) * speed;
            move.Y = (float)Math.Sin(rotation) * speed;
            location += move;
        }

        public void setTarget(Vector2 newTarget)
        {
            target = newTarget;
        }
        private float angleTo(Vector2 start, Vector2 end)
        {
            float rotation = 0;
            Vector2 offset = end;
            offset -= start;
            rotation = (float)Math.Atan2(offset.Y, offset.X);
            return rotation;
        }

        public void draw(SpriteBatch spritebatch, Camera camera)
        {
            spritebatch.Begin(SpriteSortMode.Texture, BlendState.AlphaBlend, SamplerState.PointClamp, null, null, null, camera.getTransformation());
            spritebatch.Draw(texture, location, new Rectangle(0,0,32,32), Color.White, rotation, new Vector2(16,16),1f,SpriteEffects.None,0f);
           // spritebatch.Draw(texture, location, Color.White);
            spritebatch.End();
        }
    }
}
