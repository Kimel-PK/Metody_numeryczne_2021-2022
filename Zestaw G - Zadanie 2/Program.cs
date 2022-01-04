// korzystam z biblioteki Math.NET
using MathNet.Numerics.LinearAlgebra;

Console.WriteLine ("================== Podpunkt a ==================");

Vector<double> A_1 = Vector<double>.Build.Dense(124, 1);
Vector<double> A_2 = Vector<double>.Build.Dense(127, 1);
Vector<double> A_3 = Vector<double>.Build.Dense(128, 4);
Vector<double> A_4 = Vector<double>.Build.Dense(127, 1);
Vector<double> A_5 = Vector<double>.Build.Dense(124, 1);

Vector<double> b = Vector<double>.Build.Dense(128, 1);

Vector<double> x = Vector<double>.Build.Dense(128);

for (int i = 1; i < 100; i++) {
	
	x[0] = b[0] - x[1] - x[4];
	x[0] /= A_3[0];
	
	x[1] = b[1] - x[0] - x[2] - x[5];
	x[1] /= A_3[1];
	
	x[2] = b[2] - x[1] - x[3] - x[6];
	x[2] /= A_3[2];
	
	x[3] = b[3] - x[2] - x[4] - x[7];
	x[3] /= A_3[3];
	
	for (int j = 4; j < 124; j++) {
		x[j] = b[j] - x[j - 4] - x[j - 1] - x[j + 1] - x[j + 4];
		x[j] /= A_3[j];
	}
	
	x[124] = b[124] - x[120] - x[123] - x[125];
	x[124] /= A_3[124];
	
	x[125] = b[125] - x[121] - x[124] - x[126];
	x[125] /= A_3[125];
	
	x[126] = b[126] - x[122] - x[125] - x[127];
	x[126] /= A_3[126];
	
	x[127] = b[127] - x[123] - x[126];
	x[127] /= A_3[127];
	
}

Console.WriteLine ("Wynik:");
ShowVector (x);
Console.WriteLine ("");

Console.WriteLine ("================== Podpunkt b ==================");

x = Vector<double>.Build.Dense(128);
Vector<double> x_diff = Vector<double>.Build.Dense(128);

Vector<double> r = b - OptMul (A_1, A_2, A_3, A_4, A_5, x);
Vector<double> p = r.Clone();

double alfa = 0;
double beta = 0;

while (r.Norm(2) > 0.0000000000001) {
	
	alfa = (r * r) / (p * OptMul (A_1, A_2, A_3, A_4, A_5, p));
	Vector<double> r_k = r - alfa * OptMul (A_1, A_2, A_3, A_4, A_5, p);
	beta = (r_k * r_k) / (r * r);
	Vector<double> p_k = r_k + beta * p;
	Vector<double> x_k = x + alfa * p;
	
	r = r_k;
	p = p_k;
	x = x_k;
}

Console.WriteLine ("Wynik:");
ShowVector (x);

Vector<double> OptMul (Vector<double> A_1, Vector<double> A_2, Vector<double> A_3, Vector<double> A_4, Vector<double> A_5, Vector<double> v) {
	
	Vector<double> q = Vector<double>.Build.Dense (v.Count);
	
	q[0] = A_3[0] * v[0] + A_2[0] * v[1] + A_1[0] * v[4];
	q[1] = A_4[0] * v[0] + A_3[1] * v[1] + A_2[1] * v[2] + A_1[1] * v[5];
	q[2] = A_4[1] * v[1] + A_3[2] * v[2] + A_2[2] * v[3] + A_1[2] * v[6];
	q[3] = A_4[2] * v[2] + A_3[3] * v[3] + A_2[3] * v[4] + A_1[3] * v[7];
	
	for (int i = 4; i < 124; i++) {
		q[i] = A_1[i] * v[i + 4] + A_2[i] * v[i + 1] + A_3[i] * v[i] + A_4[i - 1] * v[i - 1] + A_5[i - 4] * v[i - 4];
	}
	
	q[124] = A_2[124] * v[125] + A_3[124] * v[124] + A_4[123] * v[123] + A_5[120] * v[120];
	q[125] = A_2[125] * v[126] + A_3[125] * v[125] + A_4[124] * v[124] + A_5[121] * v[121];
	q[126] = A_2[126] * v[127] + A_3[126] * v[126] + A_4[125] * v[125] + A_5[122] * v[122];
	q[127] = A_3[127] * v[127] + A_4[126] * v[126] + A_5[123] * v[123];
	
	return q;
}

void ShowVector (Vector<double> v) {
	
	for (int i = 0; i < v.Count; i++)
		Console.WriteLine ("x[" + i + "] = " + v[i]);
}