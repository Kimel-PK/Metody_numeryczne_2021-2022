using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AwokeKnowing.GnuplotCSharp;

namespace Zadanie_B {
    class Program {
        static void Main(string[] args) {
            
            GnuPlot.Plot("sin(x) + 2", "lc rgb \"magenta\" lw 5");
            
        }
    }
}