using System;

namespace Zadanie_2A {
	class Program {
		static void Main(string[] args) {
			
			Console.WriteLine ("===== float =====");
			
			Console.WriteLine ("Minimalna wartość float: " + float.MinValue);
			Console.WriteLine ("Maksymalna wartość float: " + float.MaxValue);
			float przepełnienie_float = float.MaxValue * 2;
			float niedomiar_float = float.MinValue * 2;
			
			// wartość stała PositiveInfinity i NegativeInfinity nie jest w stanie wyświetlić się w konsoli
			// możliwe że zależy to od ustawień lokalizacji, widziałem też wersję że konsola powinna pokazywać tekst "Infinity" zamiast "?"
			Console.WriteLine ("Przepełnienie float: " + przepełnienie_float);
			Console.WriteLine ("Niedomiar float: " + niedomiar_float);
			if (float.IsPositiveInfinity(przepełnienie_float)) {
				Console.WriteLine ("Przepełnienie jest reprezentowane jako stała float.PositiveInfinity");
			}
			if (float.IsNegativeInfinity(niedomiar_float)) {
				Console.WriteLine ("Niedomiar jest reprezentowany jako stała float.NegativeInfinity");
			}
			
			Console.WriteLine ("");
			Console.WriteLine ("===== double =====");
			
			Console.WriteLine ("Minimalna wartość double: " + double.MinValue);
			Console.WriteLine ("Maksymalna wartość double: " + double.MaxValue);
			double przepełnienie_double = double.MaxValue * 2;
			double niedomiar_double = double.MinValue * 2;
			
			Console.WriteLine ("Przepełnienie double: " + przepełnienie_double);
			Console.WriteLine ("Niedomiar double: " + niedomiar_double);
			if (double.IsPositiveInfinity(przepełnienie_double)) {
				Console.WriteLine ("Przepełnienie jest reprezentowane jako stała double.PositiveInfinity");
			}
			if (double.IsNegativeInfinity(niedomiar_double)) {
				Console.WriteLine ("Niedomiar jest reprezentowany jako stała double.NegativeInfinity");
			}
			
			Console.WriteLine("");
			Console.WriteLine("Żeby bezpiecznie obsłużyć sytuacje przekraczające granicę reprezentacji potrzebujemy ulepszonych metod do wykonywania obliczeń");
			
			// Console.WriteLine (Pomnóż (double.MaxValue, 2)); zwróci wyjątek przekroczenia granicy reprezentacji
			// Console.WriteLine (Pomnóż (1.0E-307, 1.0E-307)); // zwróci wyjątek przekroczenia precyzji
			
		}
		
		static double Dodaj(double a,double b) {
			double w = a + b;
			if (double.IsInfinity (w))
				throw new OverflowException("Wynik przekroczył granicę reprezentacji");
			if (w == 0.0 && a != (-b))
				throw new OverflowException("Wynik przekroczył maksymalną precyzje systemu");
			return w;
		}

		static double Odejmij(double a,double b) {
			double w = a - b;
			if (double.IsInfinity (w))
				throw new OverflowException("Wynik przekroczył granicę reprezentacji");
			if (w == 0.0 && a != b)
				throw new OverflowException("Wynik przekroczył maksymalną precyzje systemu");
			return w;
		}

		static double Pomnóż(double a, double b) {
			double w = a * b;
			if (double.IsInfinity (w))
				throw new OverflowException("Wynik przekroczył granicę reprezentacji");
			if (w == 0 && a != 0 && b != 0)
				throw new OverflowException("Wynik przekroczył maksymalną precyzje systemu");
			return w;
		}

		static double Podziel(double a,double b) {
	  		double w = a / b;
			  if (double.IsInfinity (w))
				throw new OverflowException("Wynik przekroczył granicę reprezentacji");
	  		if (w == 0.0 && a != 0)
				throw new OverflowException("Wynik przekroczył maksymalną precyzje systemu");
	  		return w;
		}

	}
}
