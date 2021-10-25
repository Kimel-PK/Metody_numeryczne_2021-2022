using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AwokeKnowing.GnuplotCSharp;

namespace Zadanie_B {
	class Program {
		static void Main(string[] args) {
			
			double[] wynikiFloat = new double[2048];
			double[] wynikiDouble = new double[2048];
			
			for (int i = 0; i < 2048; i++) {
				wynikiFloat[i] = Iteruj_float(i);
				wynikiDouble[i] = Iteruj_double(i);
			}
			
			GnuPlot.HoldOn();
			GnuPlot.Plot(wynikiFloat);
			GnuPlot.Plot(wynikiDouble);
			GnuPlot.HoldOff();
			
			foreach (double liczba in wynikiDouble) {
				Console.Write (liczba + ", ");
			}
			Console.WriteLine (" ");
			
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