# Zestaw 2 - Zadanie C

## Treść zadania

Proszę zaimplementować przykład z wykładu profesora. Mamy zatem ciąg:

```math
SE = \frac{\sigma}{\sqrt{n}}
```

![equation](https://latex.codecogs.com/gif.latex?%5Cbegin%7Bcases%7D%20x_%7Bn&plus;1%7D%3D4x_%7Bn%7D-1%20%5C%5C%20x_%7B0%7D%3D%5Cfrac%7B1%7D%7B3%7D%20%5Cend%7Bcases%7D)

i badamy jego rozbieżność. Proszę w implementacji wykorzystać szeroki wachlarz reprezentacji liczb zmiennoprzecinkowych. Wyniki proszę zilustrować wykresem.

## Komentarz

Decimal to typ danych w C# przydatny w obliczeniach finansowych. Pozwala na bardzo dużą precyzję ale ma w porównaniu do float i double bardzo małe zakresy. Float bardzo szybko traci dokładność i już po 50 iteracjach błąd sięga rzedu 1x10²¹.
