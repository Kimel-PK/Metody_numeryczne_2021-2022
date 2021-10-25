using System;
using AwokeKnowing.GnuplotCSharp;

namespace Zadanie_B {
	class Program {
		static void Main(string[] args) {
			
			double[] wynikiFloat = new double[2049];
			double[] wynikiDouble = new double[2049];
			
			for (int i = 1; i <= 2048; i++) {
				wynikiFloat[i] = Iteruj_float(i);
				wynikiDouble[i] = Iteruj_double(i);
			}
			
			GnuPlot.Set ("xrange [1:2048]");
			GnuPlot.Set ("multiplot layout 1,2");
			GnuPlot.Set ("title \"Float\"");
			GnuPlot.Plot(wynikiFloat);
			GnuPlot.Set ("title \"Double\"");
			GnuPlot.Plot(wynikiDouble);
			GnuPlot.Unset ("multiplot");
			
		}
		
		static float Iteruj_float (int mianownik) {
			float dx = 1.0f / (float)mianownik;
			float x = 0.0f;
			for (int i = 1; i <= mianownik; i++) {
				x = x + dx;
			}
			return Math.Abs (1.0f - x);
		}
		
		static double Iteruj_double (int mianownik) {
			double dx = 1.0 / (double)mianownik;
			double x = 0.0;
			for (int i = 1; i <= mianownik; i++) {
				x = x + dx;
			}
			return Math.Abs (1.0 - x);
		}
		
	}
}