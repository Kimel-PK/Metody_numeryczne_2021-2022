// korzystam z biblioteki Math.NET
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;

Console.WriteLine ("============== Podpunkt a ==============");

// zapisujemy macież jako 3 wektory żeby oszczędzić zasobów
Vector<double> a = DenseVector.OfArray(new double[] {1,1,1,1,1,1});
Vector<double> b = DenseVector.OfArray(new double[] {4,4,4,4,4,4,4});
Vector<double> c = DenseVector.OfArray(new double[] {1,1,1,1,1,1});

Vector<double> d = DenseVector.OfArray(new double[] {1,2,3,4,5,6,7});

Vector<double> x = Rozwiąż (a, b, c, d);

for (int i = 0; i < b.Count; i++) {
	Console.WriteLine ("x[" + i + "]: " + x[i]);
}

Console.WriteLine ("============== Podpunkt b ==============");

// wektory a, b, c, d zostają z poprzedniego podpunktu

double alpha = 1.0;

Vector<double> u = Vector<double>.Build.Dense(d.Count);

u[0] = alpha;
u[^1] = alpha; // w C# [^1] pierwszy element od końca tablicy

b[0] = b[0] - alpha;
b[^1] = b[^1] - alpha;

Vector<double> z = Rozwiąż (a, b, c, d);
Vector<double> q = Rozwiąż (a, b, c, u);

double factor = (z[0] + alpha * z[^1] / alpha) / (1.0 + q[0] + alpha * q[^1] / alpha);

for (int i = 0; i < b.Count; i++) {
	z[i] -= factor * q[i];
}

for (int i = 0; i < b.Count; i++) {
	Console.WriteLine ("x[" + i + "]: " + z[i]);
}

// =============

Vector<double> Rozwiąż (Vector<double> a1, Vector<double> a2, Vector<double> a3, Vector<double> y) {
	
	Vector<double> a = a1.Clone();
	Vector<double> b = a2.Clone();
	Vector<double> c = a3.Clone();
	Vector<double> d = y.Clone();
	
	for (int i = 0; i < b.Count - 1; i++) {
		double w = a[i] / b[i];
		b[i+1] = b[i+1] - w * c[i];
		d[i+1] = d[i+1] - w * d[i];
	}
	
	Vector<double> u = Vector<double>.Build.Dense(d.Count);
	
	for (int i = u.Count - 1; i >= 0; i--) {
		if (i == u.Count - 1) {
			u[i] = d[i] / b[i];
		} else {
			u[i] = (d[i] - c[i] * u[i + 1]) / b[i];
		}
	}
	
	return u;
	
}