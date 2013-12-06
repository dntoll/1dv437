using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using MinimalGame.model;
using Microsoft.Xna.Framework.Graphics;

namespace MinimalGame.view
{
    class Camera
    {
        private float displaceX = 0;
        private float displaceY = 0;
        private float scaleX;
        private float scaleY;


        public Camera(Viewport port)
        {
            scaleX = port.Width / model.Level.SIZE_X;
            scaleY = port.Height / model.Level.SIZE_Y;

            if (scaleY < scaleX)
            {
                scaleX = scaleY;
            }
            else if (scaleY > scaleX)
            {
                scaleY = scaleX;
            }
        }
        
    
        internal Microsoft.Xna.Framework.Rectangle translateRect(Vector2 modelCenter, float modelRadius)
        {
            float viewRadiusX = modelRadius * scaleX;
            float viewRadiusY = modelRadius * scaleY;

 	          //Camera translations
            int screenX = (int)((modelCenter.X * scaleX + displaceX) - viewRadiusX);
            int screenY = (int)((modelCenter.Y * scaleY + displaceY) - viewRadiusY);


            return new Rectangle(screenX, screenY, (int)(viewRadiusX * 2.0f), (int)(viewRadiusY * 2.0f));
        }

        internal Rectangle translateRectFromCenterTop(Vector2 modelPadCenterTop, float modelRadius)
        {
            float viewRadiusX = modelRadius * scaleX;

            int screenX = (int)((modelPadCenterTop.X * scaleX + displaceX) - viewRadiusX);
            int screenY = (int)((modelPadCenterTop.Y * scaleY + displaceY));

            return new Rectangle(screenX, screenY, (int)(viewRadiusX * 2.0f), (int)(viewRadiusX * 2.0f));
        }
    }
}
