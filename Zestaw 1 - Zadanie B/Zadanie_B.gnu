set ylabel "Wartosc"

set multiplot layout 3,1
set title "Cena Bitcoin"
set xrange [57:129]
plot "btc.data" title "Cena BitCoin" with lines
set title "Cena Etherium"
set xrange [57:129]
plot "eth.data" title "Cena Etherium" with lines
set title "Sin(x)"
set xrange [57:129]
set xlabel "Dni"
plot sin(x)
unset multiplot