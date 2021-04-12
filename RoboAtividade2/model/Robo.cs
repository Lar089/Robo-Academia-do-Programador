using System;
using System.Collections.Generic;
using System.Text;

namespace RoboAtividade2.model
{
    class Robo : X 
    {
        private Face face;
        private X x;
        private Y y;

        public Robo()
        {
        }

        public Robo(Face face, X x, Y y)
        {
            this.face = face;
            this.x = x;
            this.y = y;
        }

        public Face Face
        {
            get { return face; }
            set { face = value; }
        }

        public X X
        {
            get { return x; }
            set { x = value; }
        }

        public Y Y
        {
            get { return y; }
            set { y = value; }
        }
    }
}
