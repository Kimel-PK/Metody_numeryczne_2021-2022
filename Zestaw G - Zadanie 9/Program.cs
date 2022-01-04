// korzystam z biblioteki Math.NET
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using MathNet.Numerics;
using AwokeKnowing.GnuplotCSharp;

Vector<double> x = Vector.Build.Dense(65, i => -1 + i / 32.0);
Vector<double> y = Vector.Build.Dense(65, i => 1 / (1 + 5 * x[i] * x[i]));

Vector<double> a = Vector<double>.Build.Dense(62, 1);
Vector<double> b = Vector<double>.Build.Dense(63, 4);
Vector<double> c = Vector<double>.Build.Dense(62, 1);

Vector<double> d = Vector.Build.Dense(63, i => y[i] - 2 * y[i + 1] + y[i + 2]);

Vector<double> eps = Rozwiąż (a, b, c, (6.0 / Math.Pow (x[1] - x[0], 2)) * d);
eps = Wstaw (eps, 0, 0);
eps = Wstaw (eps, 0, 64);

Vector<double> plot_x = Vector<double>.Build.DenseOfArray (Generate.LinearSpaced(1024, x[0], x[64]));
Vector<double> plot_fx = Splajn_Kubiczny (plot_x);

GnuPlot.HoldOn();
GnuPlot.Plot (plot_x.ToArray(), plot_fx.ToArray(), "with lines");

double[] plot_x1 = new double[] {x[0], x[5], x[7], x[16], x[21], x[39], x[42], x[61]};
double[] plot_fx1 = new double[] {y[0], y[5], y[7], y[16], y[21], y[39], y[42], y[61]};

GnuPlot.Plot (plot_x1, plot_fx1, "lc rgb 'red' lw 5");

// ==========

Vector<double> Rozwiąż (Vector<double> _a1, Vector<double> _a2, Vector<double> _a3, Vector<double> _d) {
	
	Vector<double> a = _a1.Clone();
	Vector<double> b = _a2.Clone();
	Vector<double> c = _a3.Clone();
	Vector<double> d = _d.Clone();
	
	for (int i = 0; i < d.Count - 1; i++) {
		double w = a[i] / b[i];
		b[i + 1] = b[i + 1] - w * c[i];
		d[i + 1] = d[i + 1] - w * d[i];
	}
	
	Vector<double> u = Vector<double>.Build.Dense(d.Count);
	
	for (int i = u.Count - 1; i >= 0; i--) {
		if (i == u.Count - 1)
			u[i] = d[i] / b[i];
		else
			u[i] = (d[i] - c[i] * u[i + 1]) / b[i];
	}
	
	return u;
}

Vector<double> Splajn_Kubiczny (Vector<double> x_x) {
	
	Vector<double> fx = Vector<double>.Build.Dense (x_x.Count);
	
	double a_x;
	double b_x;
	double c_x;
	double d_x;
	
	for (int i = 0; i < x_x.Count; i++) {
		
		int j;
		
		if (i == x_x.Count - 1)
			j = (int)((x_x[i] - x[0]) / (x[1] - x[0]) - 1);
		else
			j = (int)((x_x[i] - x[0]) / (x[1] - x[0]));
		
		a_x = (x[j + 1] - x_x[i]) / (x[j + 1] - x[j]);
		b_x = (x_x[i] - x[j]) / (x[j + 1] - x[j]);
		c_x = (1 / 6.0) * (Math.Pow(a_x, 3) - a_x) * Math.Pow (x[j + 1] - x[j], 2);
		d_x = (1 / 6.0) * (Math.Pow(b_x, 3) - b_x) * Math.Pow (x[j + 1] - x[j], 2);
		fx[i] = a_x * y[j] + b_x * y[j + 1] + c_x * eps[j] + d_x * eps[j + 1];
	}
	
	return fx;
}

Vector<double> Wstaw (Vector<double> v, double liczba, int pozycja) {
	
	Vector<double> wynik = Vector<double>.Build.Dense (v.Count + 1);
	
	for (int i = 0; i < pozycja; i++)
		wynik[i] = v[i];
	
	for (int i = pozycja; i < v.Count; i++)
		wynik[i + 1] = v[i];
	
	wynik[pozycja] = liczba;
	
	return wynik;
}