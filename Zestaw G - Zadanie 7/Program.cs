// korzystam z biblioteki Math.NET
using MathNet.Numerics.LinearAlgebra;
using AwokeKnowing.GnuplotCSharp;
using MathNet.Numerics;

Vector<double> x = Vector<double>.Build.DenseOfArray (new double[] {0.062500, 0.187500, 0.312500, 0.437500, 0.562500, 0.687500, 0.812500, 0.937500});
Vector<double> fx = Vector<double>.Build.DenseOfArray (new double[] {0.687959, 0.073443, -0.517558, -1.077264, -1.600455, -2.080815, -2.507266, -2.860307});
Vector<double> a = Vector<double>.Build.Dense (x.Count);
Vector<double> f_k_next = Vector<double>.Build.Dense (x.Count);
Vector<double> f_k = fx.Clone();

Vector<double> ls = Vector<double>.Build.Dense (a.Count);

for (int i = 0; i < 8; i++) {
	ls[i] += do_l (x, i);
}

for (int i = 0; i < 8; i++) {
	a[0] += do_l (x, i) * fx[i];
}

for (int i = 1; i < 8; i++) {
	
	for (int j = 0; j < 8; j++) {
		f_k_next[j] = (f_k[j] - a[i - 1]) / x[j];
	}
	
	for (int j = 0; j < 8; j++) {
		a[i] += do_l (x, j) * f_k_next[j];
	}
	
	f_k = f_k_next.Clone();
}

Console.WriteLine ("Wynik:");

for (int i = 0; i < a.Count; i++) {
	a[i] = Math.Round(a[i], 4);
    Console.WriteLine ("a[" + i + "] = " + a[i]);
}

// gnuplot

Vector<double> plot_x = Vector<double>.Build.DenseOfArray (Generate.LinearSpaced(128, -1, 1));
Vector<double> plot_fx = a[7] * vec_pow (plot_x, 7) + a[6] * vec_pow (plot_x, 6) + a[5] * vec_pow (plot_x, 5) + a[4] * vec_pow (plot_x, 4) + a[3] * vec_pow (plot_x, 3) + a[2] * vec_pow (plot_x, 2) + a[1] * plot_x + a[0];

GnuPlot.HoldOn();
GnuPlot.Plot (plot_x.ToArray(), plot_fx.ToArray(), "with lines lc rgb 'blue'");
GnuPlot.Plot (x.ToArray(), fx.ToArray(), "lc rgb 'red' lw 5");

// ===========

double do_l (Vector<double> x, int j) {
	
	double a = 1.0;
	double b = 1.0;
	
	for (int i = 0; i < j; i++) {
		a *= -x[i];
		b *= x[j] - x[i];
	}
	
	for (int i = j + 1; i < 8; i++) {
		a *= -x[i];
		b *= x[j] - x[i];
	}
	
	return a / b;
}

Vector<double> vec_pow (Vector<double> v, int pow) {
	
	Vector<double> result = v.Clone();
	
	for (int i = 0; i < result.Count; i++) {
		result[i] = Math.Pow (result[i], pow);
	}
	
	return result;
}