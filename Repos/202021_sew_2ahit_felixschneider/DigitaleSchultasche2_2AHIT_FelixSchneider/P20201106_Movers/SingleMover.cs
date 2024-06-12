using System;
using System.Collections.Generic;
using System.Text;

namespace P20201106_Movers
{
    enum diretion {N, S, E, W};
    

    class SingleMover:Urtier
    {
        

        public SingleMover(int x, int y):base(x,y)
        {
            
        }

        //public override void Move()
        //{
        //    dir = GetDirectionRandom();
        //    MoveDirection();
        //}
        
    }
}
