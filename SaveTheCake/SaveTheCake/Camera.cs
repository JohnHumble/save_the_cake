using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace SaveTheCake
{
    class Camera
    {
        public Vector2 location;
        public float scale;
        private Matrix transform;

        // initalize
        public Camera(Vector2 loc)
        {
            location = loc;
            scale = 1;
            transform = new Matrix();
        }
        public Camera(Vector2 loc, float scl)
        {
            location = loc;
            scale = scl;
            transform = new Matrix();
        }
        public Camera(float x, float y, float scl = 1)
        {
            location = new Vector2(x, y);
            scale = scl;
            transform = new Matrix();
        }

        // change location.
        public void setLocation(Vector2 loc)
        {
            loc.X *= -1;
            loc.Y *= -1;
            location = loc;
        }
        public void setLocation(int x, int y)
        {
            location = new Vector2(x * -1, y * -1);
        }

        // change scale
        public void setScale(float Scale)
        {
            scale = Scale;
        }

        // give matrix. use this in draw method
        public Matrix getTransformation()
        {
            transform = Matrix.CreateTranslation(new Vector3(location.X, location.Y, 0)) * Matrix.CreateScale(scale);
            return transform;
        }
    }
}
