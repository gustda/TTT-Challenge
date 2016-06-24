using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTT_Challenge.Controller;

namespace TTT_Challenge
{
    class Program
    {
        static void Main(string[] args)
        {
            var controller = new GameController();
            controller.Run();
        }
    }
}
