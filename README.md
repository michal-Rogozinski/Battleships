# Gra Battleships
## Założenia projektowe
Projekt ten składa się z następujących modułów:
- Klasy Square będącej podstawową jednostką mapy.
- Klasy Field będącej listą jednostek Square.
- Klasy HitsBoard zawierających mapę trafień i pudeł.
- Klasy Fleet zawierającą listę statków.
- Klas Ship i ShipTypes, gdzie klasa Ship jest strukturą abstrakcyjną definiującą podstawowe właściwości statku (nazwa,rodzaj,wielkość)
a klasa ShipTypes jest klasą implementującą.
- Klasy Coordinates zawierająca koordynaty w płaszczyźnie 2D.
- Enumeratora TypeEnumeration, która zawiera warianty stanów w jakich może znajdować się pole (zajęcie przez statek,trafienie,pudło,puste pole).
- Enumeratora FiringResult wykorzystywanego na potrzeby klasy HitsBoard.
- Klasy Player zawierającej dane na temat gracza(imię,tablica własnych statków,tablica trafień przeciwnika),metody inicializujące tablice statków
jak i metody aktualizujące stan tablic.
- Klasy Util zawierająca metody wspomagające.

Program działa całkowicie w interfejsie CLI.

## Przebieg gry
Tablice graczy są losowo zapełniane na początku gry poprzez metodę PlaceShips. Metoda ta działa w pętli aż do momentu umieszczenia wszyskich statków
na tablicy w taki sposób, że żaden statek nie przecina innego statku.
Następnie gracz pierwszy oddaje strzał. Strzał może zostać oddany na dwa sposoby:
- poprzez losowe wybranie koordynatów
- poprzez wybranie pola będącego w sąsiedztwie miejsca trafienia

Na koniec ruchu następuje aktualizacja stanów tablic oraz wydruk stanu pola po strzale (trafienie/pudło), oraz w przypadku
zatopienia statku podanie informacji o zatopieniu.

Gra kończy się w momencie spełnienia warunku kończącego,czyli zatopienia wszystkich statków jednego z graczy.
