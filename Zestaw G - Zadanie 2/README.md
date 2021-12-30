# Zadanie 2

Dana jest macierz A ∈ R¹²⁸x¹²⁸ o następującej strukturze:

```text
    ┌                             ┐
    | 4 1 0 0 1 0 0 0 0 0 0 … … … |
    | 1 4 1 0 0 1 0 0 0 0 0 … … … |
    | 0 1 4 1 0 0 1 0 0 0 0 … … … |
    | 0 0 1 4 1 0 0 1 0 0 0 … … … |
    | 1 0 0 1 4 1 0 0 1 0 0 … … … |
    | 0 1 0 0 1 4 1 0 0 1 0 … … … |
    | 0 0 1 0 0 1 4 1 0 0 1 … … … |
A = | … … … … … … … … … … … … … … |
    | … … … 0 0 1 0 0 1 4 1 0 0 1 |
    | … … … 0 0 0 1 0 0 1 4 1 0 0 |
    | … … … 0 0 0 0 1 0 0 1 4 1 0 |
    | … … … 0 0 0 0 0 1 0 0 1 4 1 |
    | … … … 0 0 0 0 0 0 1 0 0 1 4 |
    └                             ┘
```

Rozwiązać równanie Ax = e, gdzie e jest wektorem, którego wszystkie składowe są równe 1, za pomocą:

- (a) metody Gaussa-Seidela,
- (b) metody gradientów sprzężonych.
