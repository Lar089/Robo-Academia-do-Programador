using System;
using System.Collections.Generic;
using System.Text;

namespace RoboAtividade2.model
{
    class X : Y
    {
        private int x;

        public X()
        {
        }

        public X(int x)
        {
            this.x = x;
        }

        public int SGX
        {
            get { return x; }
            set { x = value; }
        }

    }
}
