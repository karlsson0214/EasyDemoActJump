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
        private float xSpeed = 0;
        public override void Act()
        {
            if (InAir())
            {
                MoveByGravity();
            }
            else
            {
                // on ground
                CheckMove();
            }
        }
        private bool OnGround()
        {
            if (IsTouching(typeof(Ground)))
            {
                Ground ground = (Ground)GetOneIntersectingActor(typeof(Ground));
                // on ground - max 10 pixel into ground from above
                if ( Y + Height / 2 < ground.Y - ground.Height / 2 + 10 )
                {
                    return true;
                }
            }
            return false;
        }
        private bool InAir()
        {
            return !OnGround();
        }
        private void MoveByGravity()
        {
            ySpeed += gravity;
            Y += ySpeed;
            X += xSpeed;
            if (IsTouching(typeof(Ground)))
            {
                Actor ground = GetOneIntersectingActor(typeof(Ground));
                if (Y < ground.Y)
                {
                    // from above - stop at ground
                    float deltaY = Y + Height / 2 - ground.Y + ground.Height / 2;
                    // 1 pixel inside the ground
                    Y -= deltaY + 1;
                    ySpeed = 0;
                }
                else
                {
                    // from below - stop at roof
                    float deltaY = ground.Y + ground.Height / 2 - Y + Height / 2;
                    // keep 1 pixel below roof
                    Y += deltaY +10;
                    ySpeed = 0;
                }
            }
        }
        private void CheckMove()
        {
            if (OnGround())
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Left))
                {
                    xSpeed = -3;
                    X += xSpeed;
                    IsFlippedHorizontally = true;
                }
                else if (Keyboard.GetState().IsKeyDown(Keys.Right))
                {
                    xSpeed = 3;
                    X += xSpeed;
                    IsFlippedHorizontally = false;
                }
                else
                {
                    xSpeed = 0;
                }
                if (Keyboard.GetState().IsKeyDown(Keys.Space) || 
                    Keyboard.GetState().IsKeyDown(Keys.Up))
                {
                    ySpeed = -5;
                    Y += ySpeed;
                }
            }
        }
    }
}
