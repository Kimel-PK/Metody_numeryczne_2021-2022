# Zestaw 2 - Zadanie B

## Treść zadania

Korzystając z ulubionego języka proszę zaimplementować następujący pseudokod:

```text
function iteruj(mianownik)
    dx = 1.0 / float(m)
    x = 0.0
    do i = 1 .. mianownik
        x = x + dx
    end do
    return abs(1.0 - x)
```

Gdzie mianownik to dodatnia liczba całkowita, 1.0 oraz 0.0 to liczby zmiennoprzecinkowe, funkcja float zamienia liczbę całkowitą na liczbę zmiennoprzecinkową natomiast funkcja abs zwraca wartość bezwzględną.

Korzystając z implementacji:

- proszę zbadać jak zmieni się wynik funkcji gdy mianownik = 1 .. 2048
- proszę zbadać jak zmieni się wynik funkcji gdy:
  - liczby zmiennoprzecinkowe reprezentowane są w pojedynczej precyzji
  - liczby zmiennoprzecinkowe reprezentowane są w podwójnej precyzji
- otrzymane wyniki proszę zinterpretować i skomentować :-)

## Komentarz

Po zsumowaniu wszystkich mniejszych liczb powinniśmy za każdym razem otrzymywać 1, jednak przez przymus zaokrąglania bardzo małych liczb do formatu jaki jesteśmy w stanie zapisać na komputerze wynik jest tylko zbliżony do 1.

Dla zmiennych typu float największy błąd jest rzędu 3x10e-5.

Dla zmiennych typu double największy błąd jest rzędu 6x10e-14.

Zmienne typu double przechowywane są na większej ilości bitów i dzieki temu zapewniają większą precyzję.