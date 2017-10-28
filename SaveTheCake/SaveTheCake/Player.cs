using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace SaveTheCake
{
    class Player
    {
        // logical Veriables;
        Vector2 location;
        Vector2 target;
        float speed;

        // graphics Veriables
        Texture2D texture;

        //constructors
        public Player(Vector2 s_location, Texture2D s_texture, Vector2 s_target)
        {
            location = s_location;
            target = s_target;
            texture = s_texture;
            speed = 2.5f;
        }

        public void uptate(KeyboardState key)
        {
            //movement
            if(key.IsKeyDown(Keys.W))
            {
                location.Y -= speed;
            }
            else if (key.IsKeyDown(Keys.S))
            {
                location.Y += speed;
            }
            if(key.IsKeyDown(Keys.A))
            {
                location.X -= speed;
            }
            else if (key.IsKeyDown(Keys.D))
            {
                location.X += speed;
            }
        }

        public void draw(SpriteBatch spritebatch, Camera camera)
        {
            Vector2 drawRec = new Vector2(32 / 2, 32/2);
            drawRec += location;
            spritebatch.Begin(SpriteSortMode.Texture, BlendState.AlphaBlend, SamplerState.PointClamp, null, null, null, camera.getTransformation());
            spritebatch.Draw(texture, drawRec, Color.White);
            spritebatch.End();
        }

        public Vector2 pLocation()
        {
            return location;
        }
    }
}
