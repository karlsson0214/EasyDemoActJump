using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyMonoGame;

namespace EasyDemoActJump
{
    internal class Ground : Actor
    {
        private bool isMoveable = false;
        private float ySpeed = -3;

        public bool IsMoveable
        {
            get { return isMoveable; }
            set { isMoveable = value; }
        }
        
        public override void Act()
        {
            if (isMoveable)
            {
                Move();
            }
        }
        private void Move()
        {
            if (Y >= 450)
            {
                // move up  
                ySpeed = -3;

            }
            if (Y <= 150)
            {
                // move down
                ySpeed = 3;
            }
            Y += ySpeed;
        }
    }
}
