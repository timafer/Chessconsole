using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chessinconsolebecausewhy
{
    class Program
    {
        static void Main(string[] args)
        {
            Controler.Control cont = new Controler.Control(args[0]);
            cont.start();
        }
    }
}
