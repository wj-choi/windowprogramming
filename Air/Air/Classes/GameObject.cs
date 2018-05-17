﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Air
{
    class GameObject
    {
        protected Bitmap image;
        protected RectangleF rect;

        public GameObject(Bitmap bitmap)
        {
            this.image = bitmap;
            Size size = bitmap.Size;
            rect = new RectangleF(0, 0, size.Width, size.Height);
        }

        public void draw(Graphics g)
        {
            g.DrawImage(image, rect);
        }

        public virtual void update(Point location, int msec)
        {
            rect.X = location.X;
            rect.Y = location.Y;
        }

        public void setPosition(float x, float y)
        {
            rect.X = x;
            rect.Y = y;
        }
    }
}