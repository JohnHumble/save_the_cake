using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SaveTheCake
{
    class Cake
    {
        Vector2 location;
        Texture2D texture;

        public Cake(Vector2 s_location, Texture2D s_texture)
        {
            location = s_location;
            texture = s_texture;
        }

        public void draw(SpriteBatch spritebatch, Camera camera)
        {
            Vector2 drawRec = new Vector2(32 / 2, 32 / 2);
            drawRec += location;
            spritebatch.Begin(SpriteSortMode.Texture, BlendState.AlphaBlend, SamplerState.PointClamp, null, null, null, camera.getTransformation());
            spritebatch.Draw(texture, drawRec, Color.White);
            spritebatch.End();
        }
    }
}
