using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyMonoGame;
using Microsoft.Xna.Framework.Input;

namespace EasyDemoActJump
{
    internal class Player : Actor
    {
        private float gravity = 0.1f;
        private float ySpeed = 0;
        public override void Act()
        {
            if (IsTouching(typeof(Ground)))
            {
                ySpeed = 0;
            }
            else
            {
                ySpeed += gravity;
                Y += ySpeed;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Space) && OnGround())
            {
                ySpeed = -5;
                Y += ySpeed;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                X -= 3;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                X += 3;
            }



        }
        private bool OnGround()
        {
            if (IsTouching(typeof(Ground)))
            {
                Ground ground = (Ground)GetOneIntersectingActor(typeof(Ground));
                // is above?
                if ( ground.Y - 10 - Y + 25> 0)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
