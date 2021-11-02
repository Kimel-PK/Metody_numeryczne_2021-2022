# Zestaw 2 - Zadanie C

## Treść zadania

Proszę zaimplementować przykład z wykładu profesora. Mamy zatem ciąg:

$
\begin{cases}
x_{n+1} = 4x_{n} - 1 \\
x_{0} = \frac{1}{3}
\end{cases}
$

i badamy jego rozbieżność. Proszę w implementacji wykorzystać szeroki wachlarz reprezentacji liczb zmiennoprzecinkowych. Wyniki proszę zilustrować wykresem.

## Komentarz

Decimal to typ danych w C# przydatny w obliczeniach finansowych. Pozwala na bardzo dużą precyzję ale ma w porównaniu do float i double bardzo małe zakresy. Float bardzo szybko traci dokładność i już po 50 iteracjach błąd sięga rzedu 1x10²¹.
