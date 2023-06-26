Program - główna klasa całego programu, uruchamia grę i wyświetla ekran początkowy i końcowy.

Game - klasa sterująca główną logiką gry, czyli zmianą tur i graczy, losowaniem nowej lokalizacji, wyznaczaniem zwycięzcy.

Player - klasa będąca wirtualnym przedstawieniem jednego gracza, zawiera pola opisujące wszystkie przypisane mu własności, jak np. stan portfela, posiadane nieruchomości i ich wartość, statystyki posiadanych nieruchomości takie jak liczba wybudowanych domów lub hoteli, a także symbol gracza, lokalizację, czy jeszcze nie zbankrutował itp. Metody tej klasy to głównie gettery i settery pól, jest też metoda Lose, która jest wywoływana, gdy gracz zrezygnuje lub zbankrutuje i usuwa cały majątek gracza oraz jego pionek z planszy.

Board - klasa będąca reprezentacją planszy, przechowuje wszystkie jej wiersze. Metody tej klasy służą do printowania w konsoli aktualnego stanu planszy oraz modyfikowania go.

Location - nadklasa wszystkich lokalizacji na planszy, jej pole board przechowuje aktualną planszę, a wirtualna metoda LocationAction jest wywoływana, gdy gracz się znajdzie w danej lokalizacji.

BuyableLocation (podklasa Location) - klasa dziedzicząca od Location, reprezentuje lokalizację, którą gracz jest w stanie zakupić. Jej pola przechowują podstawowe informacje o danej lokalizacji, takie jak jej nazwa, właściciel, cena, wysokości czynszu itp. Jej ważniejsze metody to BuyablePropertyAction, która ustala, czy gracz płaci czynsz, czy może zakupić nieruchomość, PayRent, która pobiera od gracza czynsz, BuyAction, SellAction, MortgageAction - odpowiednio kupno, sprzedaż i zastaw nieruchomości.

City (podklasa BuyableLocation) - klasa dziedzicząca od BuyableLocation, reprezentuje lokalizację będącą miastem. Jej pola przechowują informacje dotyczące domów i hoteli, a metody umozliwiają zakup takiego domu lub hotelu. Klasa nadpisuje też metodę LocationAction - jeśli w danym mieście stanie jego właściciel, to dawany jest mu wybór odnośnie tego, czy chce kupić dom, hotel, sprzedać miasto lub je zastawić, może też nie wybierać żadnej z opcji. Jeśli gracz nie jest właścicielem, to uruchamiana jest metoda BuyablePropertyAction.

RailwayLine (podklasa BuyableLocation) - klasa dziedzicząca od BuyableLocation, reprezentuje linię kolejową. Jest analogiczna do klasy City, z tą różnicą, że w takich lokalizacjach nie można stawiać domów i hoteli.

PowerAndWater (podklasa BuyableLocation) - klasa dziedzicząca od BuyableLocation, reprezentuje elektrownię atomową lub sieć wodociągową. Jak wyżej, analogiczna do City, zmienia tylko metodę GetRent określającą wysokość czynszu.

SpecialLocation (podklasa Location) - klasa dziedzicząca od Location, jest nadklasą klas wszystkich lokalizacji, których nie da się zakupić. Jej metody to PayPlayer - dodająca graczowi pieniędzy, TaxPlayer - zabierająca graczowi pieniądze i MovePlayer - zmieniająca lokalizację gracza na planszy.

Start (podklasa SpecialLocation) - klasa reprezentująca Start na planszy. Nadpisuje metodę LocationAction.

WealthTax, GuardedParking, GoToJail, Jail, FreeParking (podklasy SpecialLocation) - klasy analogiczne do klasy Start, wszystkie nadpisują metodę LocationAction na swój sposób (np. wykorzystując metody PayPlayer, TaxPlayer, czy skazując gracza na więzienie).

BlueChance, RedChance (podklasy SpecialLocation) - klasy reprezentujące pola szansy na planszy, nadpisują metodę LocationAction, która po wywołaniu będzie symulować losowanie odpowiedniej karty szansy i zastosuje jej ekeft na graczu.