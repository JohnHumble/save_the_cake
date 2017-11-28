using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SaveTheCake
{
    class Hill
    { 
        //Private members;
        List<Ant> ants;
        Vector2 location;

        public Hill(Vector2 location)
        {
            this.location = location;
        }

        public void update(Vector2 target,Texture2D texture)
        {
            Ant basic = new Ant(location, target, 3, texture);
        }
    }
}
