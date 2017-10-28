﻿using System;
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
            location.Y++;
        }

        public void draw(SpriteBatch spritebatch, Camera camera)
        {
            spritebatch.Begin(SpriteSortMode.Texture, BlendState.AlphaBlend, SamplerState.PointClamp, null, null, null, camera.getTransformation());
            spritebatch.Draw(texture, location, Color.White);
            spritebatch.End();
        }
    }
}
