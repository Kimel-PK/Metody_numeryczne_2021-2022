using System;
using AwokeKnowing.GnuplotCSharp;

namespace Zadanie_2C {
    class Program {
        static void Main(string[] args) {
            
            int rozmiar_tablicy = 50;
            
            float[] wyniki_float = new float[rozmiar_tablicy];
            double[] wyniki_double = new double[rozmiar_tablicy];
            decimal[] wyniki_decimal = new decimal[rozmiar_tablicy];
            
            wyniki_decimal[0] = 1/3m;
            wyniki_float[0] = 1/3f;
            wyniki_double[0] = 1/3d;
            
            for (int i = 1; i < rozmiar_tablicy; i++) {
                wyniki_decimal[i] = 4 * wyniki_decimal[i-1] - 1;
                wyniki_float[i] = 4 * wyniki_float[i-1] - 1;
                wyniki_double[i] = 4 * wyniki_double[i-1] - 1;
            }
            
            GnuPlot.HoldOn();
            GnuPlot.Plot(Array.ConvertAll(wyniki_decimal, x => (double)x), "with line");
            GnuPlot.Plot(Array.ConvertAll(wyniki_float, x => (double)x), "with line");
            GnuPlot.Plot(wyniki_double, "with line");
            GnuPlot.HoldOff();
            
        }
    }
}
