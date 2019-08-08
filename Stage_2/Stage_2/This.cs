using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stage_2
{
    class This
    {
        int x;

        public void Bar(int x)
        {
            this.x = x;
        }
        public void Baz()
        {
            x = 30;
        }
    }
}
