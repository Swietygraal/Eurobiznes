namespace Eurobiznes;

public class Location
{
    private Board board;

    public Board Board
    {
        get => board;
        set => board = value;
    }
    
    public virtual void LocationAction(Player p)
    {}
}

public class BuyableLocation : Location
{
    private string name;
    private int price;
    private List<int> rent_prices;
    private int curr_rent_tier;
    private Player? owner;
    private int mortgage;
    private bool is_mortgaged;

    public void SetLocationParams(string nm, int p, List<int> rp, int m)
    {
        name = nm;
        price = p;
        rent_prices = rp;
        curr_rent_tier = 0;
        owner = null;
        mortgage = m;
        is_mortgaged = false;
    }

    public virtual int GetRent()
    {
        return rent_prices[curr_rent_tier];
    }

    public void BuyablePropertyAction(Player p)
    {
        Board b = Board;
        if (owner != null && owner != p)
        {
            if (!is_mortgaged && (owner.InJail == 0))
            {
                int rent = GetRent();
                if (p.Money >= rent)
                    PayRent(p);
                else
                {
                    b.ReplaceCommunicate("Nie stać cię na zapłatę czynszu, przegrywasz.", 20);
                    b.ReplaceCommunicate("Naciśnij dowolny klawisz, aby kontynuować.", 30);
                    p.Lose(b);
                    Console.ReadKey(true);
                }
            }
            else
            {
                b.ReplaceCommunicate("Właściciel nie pobiera czynszu.", 20);
                b.ReplaceCommunicate("Naciśnij dowolny klawisz, aby kontynuować.", 30);
                Console.ReadKey(true);
            }
        }
        else if (owner == null)
        {
            if (p.Money >= price)
            {
                b.ReplaceCommunicate("Czy chcesz kupić " + name + " za " + price.ToString() + " $ ? T/N", 20);
                ConsoleKeyInfo decision = Console.ReadKey(true);
                while (decision.Key != ConsoleKey.T && decision.Key != ConsoleKey.N)
                    decision = Console.ReadKey(true);
                if (decision.Key == ConsoleKey.T)
                    BuyAction(p);
            }
            else
            {
                b.ReplaceCommunicate("Nie stać cię na zakup " + name + ".", 20);
                b.ReplaceCommunicate("Naciśnij dowolny klawisz, aby kontynuować.", 30);
                Console.ReadKey(true);
            }
        }
    }

    public void PayRent(Player p)
    {
        Board b = Board;
        int rent = GetRent();
        p.Money -= rent;
        owner.Money += rent;
        b.ReplaceCommunicate("Płacisz " + rent.ToString() + " $.", 20);
        b.ReplaceCommunicate("Naciśnij dowolny klawisz, aby kontynuować.", 30);
        Console.ReadKey(true);
    }

    public void BuyAction(Player p)
    {
        Board b = Board;
        p.Money -= price;
        p.ValueOfProperties += price;
        owner = p;
        p.AddLocation(this);
        b.ReplaceCommunicate("Kupujesz " + name + ".", 21);
        b.ReplaceCommunicate("Naciśnij dowolny klawisz, aby kontynuować.", 30);
        Console.ReadKey(true);
    }

    public void SellAction(Player p)
    {
        Board b = Board;
        p.Money += price;
        p.ValueOfProperties -= price;
        SpecificSellAction(p);
        owner = null;
        curr_rent_tier = 0;
        p.RemoveLocation(this);
        b.ReplaceCommunicate("Sprzedajesz " + name + ".", 22);
        b.ReplaceCommunicate("Naciśnij dowolny klawisz, aby kontynuować.", 30);
        Console.ReadKey(true);
    }

    public virtual void SpecificSellAction(Player p)
    {}

    public void MortgageAction(Player p)
    {
        Board b = Board;
        p.Money += mortgage;
        is_mortgaged = true;
        b.ReplaceCommunicate("Zastawiasz " + name + ".", 22);
        b.ReplaceCommunicate("Naciśnij dowolny klawisz, aby kontynuować.", 30);
        Console.ReadKey(true);
    }

    public Player Owner
    {
        get => owner;
        set => owner = value;
    }

    public int CurrRentTier
    {
        set => curr_rent_tier = value;
    }
}

public class City : BuyableLocation
{
    private int house_price;
    private int hotel_price;
    private int number_of_houses;
    private bool has_hotel;

    public City(string nm, int p, List<int> rp, int m, int hs_p, int ht_p, Board b)
    {
        Board = b;
        SetLocationParams(nm, p, rp, m);
        house_price = hs_p;
        hotel_price = ht_p;
        number_of_houses = 0;
        has_hotel = false;
    }

    public override void LocationAction(Player p)
    {
        Board b = Board;
        if (Owner == p)
        {
            b.ReplaceCommunicate("Wybierz opcję: S - sprzedaj nieruchomość, Z - zastaw nieruchomość, K - kup dom lub hotel, X - nic nie rób", 20);
            ConsoleKeyInfo decision = Console.ReadKey(true);
            while(decision.Key != ConsoleKey.S && decision.Key != ConsoleKey.Z && decision.Key != ConsoleKey.K && decision.Key != ConsoleKey.X)
                decision = Console.ReadKey(true);
            if (decision.Key == ConsoleKey.S)
                SellAction(p);
            else if(decision.Key == ConsoleKey.Z)
                MortgageAction(p);
            else if (decision.Key == ConsoleKey.K)
            {
                if (number_of_houses < 4)
                {
                    if (p.Money >= house_price)
                    {
                        b.ReplaceCommunicate("Czy chcesz kupić dom za " + house_price.ToString() + " $ ? T/N", 21);
                        decision = Console.ReadKey(true);
                        while (decision.Key != ConsoleKey.T && decision.Key != ConsoleKey.N)
                            decision = Console.ReadKey(true);
                        if (decision.Key == ConsoleKey.T)
                            BuyHouse(p);
                    }
                    else
                    {
                        b.ReplaceCommunicate("Nie stać cię na zakup domu.", 21);
                        b.ReplaceCommunicate("Naciśnij dowolny klawisz, aby kontynuować.", 30);
                        Console.ReadKey(true);
                    }
                }
                else if (!has_hotel)
                {
                    if (p.Money >= hotel_price)
                    {
                        b.ReplaceCommunicate("Czy chcesz kupić hotel za " + hotel_price.ToString() + " $ ? T/N", 21);
                        decision = Console.ReadKey(true);
                        while (decision.Key != ConsoleKey.T && decision.Key != ConsoleKey.N)
                            decision = Console.ReadKey(true);
                        if (decision.Key == ConsoleKey.T)
                            BuyHotel(p);
                    }
                    else
                    {
                        b.ReplaceCommunicate("Nie stać cię na zakup hotelu.", 21);
                        b.ReplaceCommunicate("Naciśnij dowolny klawisz, aby kontynuować.", 30);
                        Console.ReadKey(true);
                    }
                }
                else
                {
                    b.ReplaceCommunicate("Wybudowano już maksymalną liczbę domów i hoteli.", 21);
                    b.ReplaceCommunicate("Naciśnij dowolny klawisz, aby kontynuować.", 30);
                    Console.ReadKey(true);
                }
            }
        }
        else
            BuyablePropertyAction(p);
    }

    public void BuyHouse(Player p)
    {
        Board b = Board;
        p.Money -= house_price;
        p.ValueOfProperties += house_price;
        number_of_houses++;
        p.HousesBuilt++;
        CurrRentTier = number_of_houses;
        b.ReplaceCommunicate("Kupujesz dom.", 22);
        b.ReplaceCommunicate("Naciśnij dowolny klawisz, aby kontynuować.", 30);
        Console.ReadKey(true);
    }

    public void BuyHotel(Player p)
    {
        Board b = Board;
        p.Money -= hotel_price;
        p.ValueOfProperties += hotel_price;
        has_hotel = true;
        p.HotelsBuilt++;
        CurrRentTier = 5;
        b.ReplaceCommunicate("Kupujesz hotel.", 22);
        b.ReplaceCommunicate("Naciśnij dowolny klawisz, aby kontynuować.", 30);
        Console.ReadKey(true);
    }

    public override void SpecificSellAction(Player p)
    {
        p.Money += house_price * number_of_houses;
        p.ValueOfProperties -= house_price * number_of_houses;
        number_of_houses = 0;
        if (has_hotel)
        {
            p.Money += hotel_price;
            p.ValueOfProperties -= hotel_price;
            has_hotel = false;
        }
    }
}

public class RailwayLine : BuyableLocation
{
    public RailwayLine(string nm, int p, List<int> rp, int m, Board b)
    {
        Board = b;
        SetLocationParams(nm, p, rp, m);
    }

    public override void LocationAction(Player p)
    {
        Board b = Board;
        Player prev_owner = Owner;
        if (p == Owner)
        {
            b.ReplaceCommunicate("Wybierz opcję: S - sprzedaj nieruchomość, Z - zastaw nieruchomość, X - nic nie rób", 20);
            ConsoleKeyInfo decision = Console.ReadKey(true);
            while(decision.Key != ConsoleKey.S && decision.Key != ConsoleKey.Z && decision.Key != ConsoleKey.X)
                decision = Console.ReadKey(true);
            if (decision.Key == ConsoleKey.S)
                SellAction(p);
            else if(decision.Key == ConsoleKey.Z)
                MortgageAction(p);
        }
        else
            BuyablePropertyAction(p);
        Player curr_owner = Owner;
        if (curr_owner == p && curr_owner != prev_owner)
            p.OwnedRailways++;
        if(curr_owner != null)
            CurrRentTier = curr_owner.OwnedRailways;
    }
}

public class PowerAndWater : BuyableLocation
{
    private Random roll;
    
    public PowerAndWater(string nm, int p, List<int> rp, int m, Board b)
    {
        Board = b;
        SetLocationParams(nm, p, rp, m);
        roll = new Random();
    }

    public override int GetRent()
    {
        int rent = 10 * (roll.Next(1, 7) + roll.Next(1, 7));
        Player owner = Owner;
        rent *= owner.PowerAndWaterOwned;
        return rent;
    }

    public override void LocationAction(Player p)
    {
        Board b = Board;
        Player prev_owner = Owner;
        if (p == Owner)
        {
            b.ReplaceCommunicate("Wybierz opcję: S - sprzedaj nieruchomość, Z - zastaw nieruchomość, X - nic nie rób", 20);
            ConsoleKeyInfo decision = Console.ReadKey(true);
            while(decision.Key != ConsoleKey.S && decision.Key != ConsoleKey.Z && decision.Key != ConsoleKey.X)
                decision = Console.ReadKey(true);
            if (decision.Key == ConsoleKey.S)
                SellAction(p);
            else if(decision.Key == ConsoleKey.Z)
                MortgageAction(p);
        }
        else
            BuyablePropertyAction(p);
        Player curr_owner = Owner;
        if (curr_owner == p && prev_owner != curr_owner)
            p.PowerAndWaterOwned++;
        if(curr_owner != null)
            CurrRentTier = curr_owner.PowerAndWaterOwned;
    }
}

public class SpecialLocation : Location
{
    public void PayPlayer(Player p, int amount)
    {
        p.Money += amount;
    }

    public void TaxPlayer(Player p, int amount)
    {
        Board b = Board;
        if(p.Money >= amount)
            p.Money -= amount;
        else
        {
            b.ReplaceCommunicate("Nie stać cię na opłatę, przegrywasz.", 21);
            p.Lose(b);
        }
        b.ReplaceCommunicate("Naciśnij dowolny klawisz, aby kontynuować.", 30);
        Console.ReadKey(true);
    }

    public void MovePlayer(Player p, int l_idx)
    {
        Board b = Board;
        b.MovePlayer(p.PlayerLocation, l_idx, p);
        p.PlayerLocation = l_idx;
    }
}

public class Start : SpecialLocation
{
    public Start(Board b)
    {
        Board = b;
    }

    public override void LocationAction(Player p)
    {
        Board b = Board;
        PayPlayer(p, 400);
        b.ReplaceCommunicate("Otrzymujesz 400 $ za przejście przez Start.", 20);
        b.ReplaceCommunicate("Naciśnij dowolny klawisz, aby kontynuować.", 30);
        Console.ReadKey(true);
    }
}

public class WealthTax : SpecialLocation
{
    public WealthTax(Board b)
    {
        Board = b;
    }

    public override void LocationAction(Player p)
    {
        Board b = Board;
        TaxPlayer(p, 200);
        if (!p.IsBankrupt)
        {
            b.ReplaceCommunicate("Płacisz 200 $ podatku od wzbogacenia.", 20);
            b.ReplaceCommunicate("Naciśnij dowolny klawisz, aby kontynuować.", 30);
            Console.ReadKey(true);
        }
    }
}

public class GuardedParking : SpecialLocation
{
    public GuardedParking(Board b)
    {
        Board = b;
    }

    public override void LocationAction(Player p)
    {
        Board b = Board;
        TaxPlayer(p, 400);
        if (!p.IsBankrupt)
        {
            b.ReplaceCommunicate("Płacisz 400 $ za postój na strzeżonym parkingu.", 20);
            b.ReplaceCommunicate("Naciśnij dowolny klawisz, aby kontynuować.", 30);
            Console.ReadKey(true);
        }
    }
}

public class RedChance : SpecialLocation
{
    private Random roll;
    
    public RedChance(Board b)
    {
        Board = b;
        roll = new Random();
    }

    public override void LocationAction(Player p)
    {
        Board b = Board;
        int n = roll.Next(1, 17);
        switch (n)
        {
            case 1:
                b.ReplaceCommunicate("Wracasz do Madrytu.", 20);
                MovePlayer(p, 14);
                b.ReplaceCommunicate("Naciśnij dowolny klawisz, aby kontynuować.", 30);
                Console.ReadKey(true);
                break;
            case 2:
                PayPlayer(p, 200);
                b.ReplaceCommunicate("Bank wypłaca Ci procenty w wysokości 100 $.", 20);
                b.ReplaceCommunicate("Naciśnij dowolny klawisz, aby kontynuować.", 30);
                Console.ReadKey(true);
                break;
            case 3:
                b.ReplaceCommunicate("Idziesz do Kolei Wschodnich. Jeżeli przechodzisz przez Start otrzymasz 400 $.", 20);
                if(p.PlayerLocation > 35)
                    PayPlayer(p, 400);
                MovePlayer(p, 35);
                b.ReplaceCommunicate("Naciśnij dowolny klawisz, aby kontynuować.", 30);
                Console.ReadKey(true);
                break;
            case 4:
                PayPlayer(p, 400);
                b.ReplaceCommunicate("Bank wypłaca Ci należne odsetki w wysokości 300 $.", 20);
                b.ReplaceCommunicate("Naciśnij dowolny klawisz, aby kontynuować.", 30);
                Console.ReadKey(true);
                break;
            case 5:
                b.ReplaceCommunicate("Wracasz do Brukseli. Jeżeli przechodzisz przez Start otrzymujesz 400 $.", 20);
                if(p.PlayerLocation > 23)
                    PayPlayer(p, 400);
                MovePlayer(p, 23);
                b.ReplaceCommunicate("Naciśnij dowolny klawisz, aby kontynuować.", 30);
                Console.ReadKey(true);
                break;
            case 6:
                b.ReplaceCommunicate("Piłeś w czasie pracy, płacisz karę 40 $.", 20);
                TaxPlayer(p, 40);
                break;
            case 7:
                b.ReplaceCommunicate("Idziesz do Neapolu. Jeżeli przechodzisz przez Start otrzymasz 400 $.", 20);
                if(p.PlayerLocation > 6)
                    PayPlayer(p, 400);
                MovePlayer(p, 6);
                b.ReplaceCommunicate("Naciśnij dowolny klawisz, aby kontynuować.", 30);
                Console.ReadKey(true);
                break;
            case 8:
                b.ReplaceCommunicate("Płacisz opłatę za szkołę 300 $.", 20);
                TaxPlayer(p, 300);
                break;
            case 9:
                b.ReplaceCommunicate("Wychodzisz wolny z Więzienia. Kartę należy zachować do wykorzystania.", 20);
                p.JailCard = true;
                b.ReplaceCommunicate("Naciśnij dowolny klawisz, aby kontynuować.", 30);
                Console.ReadKey(true);
                break;
            case 10:
                b.ReplaceCommunicate("Idziesz do Więzienia. Nie przechodzisz przez Start. Nie otrzymujesz premii 400 $.", 20);
                if(!p.JailCard)
                    p.InJail += 2;
                else
                {
                    b.ReplaceCommunicate("Unikasz Więzienia dzięki posiadanej karcie.", 21);
                    p.JailCard = false;
                }
                b.ReplaceCommunicate("Naciśnij dowolny klawisz, aby kontynuować.", 30);
                Console.ReadKey(true);
                break;
            case 11:
                PayPlayer(p, 200);
                b.ReplaceCommunicate("Rozwiązałeś dobrze krzyżówkę. Jako I nagrodę otrzymujesz 200 $.", 20);
                b.ReplaceCommunicate("Naciśnij dowolny klawisz, aby kontynuować.", 30);
                Console.ReadKey(true);
                break;
            case 12:
                b.ReplaceCommunicate("Wracasz na Start.", 20);
                MovePlayer(p, 0);
                b.ReplaceCommunicate("Naciśnij dowolny klawisz, aby kontynuować.", 30);
                Console.ReadKey(true);
                break;
            case 13:
                b.ReplaceCommunicate("Remontujesz swoje domy. Płacisz do banku za każdy dom 50 $, za każdy hotel 200 $.", 20);
                TaxPlayer(p, p.HousesBuilt * 50 + p.HotelsBuilt * 200);
                break;
            case 14:
                b.ReplaceCommunicate("Cofasz się o 3 pola.", 20);
                MovePlayer(p, p.PlayerLocation - 3);
                b.ReplaceCommunicate("Naciśnij dowolny klawisz, aby kontynuować.", 30);
                Console.ReadKey(true);
                break;
            case 15:
                b.ReplaceCommunicate("Zobowiązany jesteś zmodernizować swoje miasto, płacisz do banku za każdy dom 80 $, za każdy hotel 230 $.", 20);
                TaxPlayer(p, p.HousesBuilt * 80 + p.HotelsBuilt * 230);
                break;
            default:
                b.ReplaceCommunicate("Mandat za szybką jazdę. Płacisz 30 $.", 20);
                TaxPlayer(p, 30);
                break;
        }
    }
}

public class BlueChance : SpecialLocation
{
    private Random roll;

    public BlueChance(Board b)
    {
        Board = b;
        roll = new Random();
    }

    public override void LocationAction(Player p)
    {
        Board b = Board;
        int n = roll.Next(1, 17);
        switch (n)
        {
            case 1:
                b.ReplaceCommunicate("Wracasz na Start.", 20);
                MovePlayer(p, 0);
                b.ReplaceCommunicate("Naciśnij dowolny klawisz, aby kontynuować.", 30);
                Console.ReadKey(true);
                break;
            case 2:
                PayPlayer(p, 400);
                b.ReplaceCommunicate("Bank pomylił się na Twoją korzyść, otrzymujesz 400 $.", 20);
                b.ReplaceCommunicate("Naciśnij dowolny klawisz, aby kontynuować.", 30);
                Console.ReadKey(true);
                break;
            case 3:
                b.ReplaceCommunicate("Idziesz do Więzienia. Nie przechodzisz przez Start. Nie otrzymujesz 400 $.", 20);
                if(!p.JailCard)
                    p.InJail += 2;
                else
                {
                    b.ReplaceCommunicate("Unikasz Więzienia dzięki posiadanej karcie.", 21);
                    p.JailCard = false;
                }
                b.ReplaceCommunicate("Naciśnij dowolny klawisz, aby kontynuować.", 30);
                Console.ReadKey(true);
                break;
            case 4:
                PayPlayer(p, 150);
                b.ReplaceCommunicate("Masz urodziny, otrzymujesz 150 $.", 20);
                b.ReplaceCommunicate("Naciśnij dowolny klawisz, aby kontynuować.", 30);
                Console.ReadKey(true);
                break;
            case 5:
                PayPlayer(p, 200);
                b.ReplaceCommunicate("Otrzymujesz w spadku 200 $.", 20);
                b.ReplaceCommunicate("Naciśnij dowolny klawisz, aby kontynuować.", 30);
                Console.ReadKey(true);
                break;
            case 6:
                b.ReplaceCommunicate("Płacisz na budowę szpitala 400 $.", 20);
                TaxPlayer(p, 400);
                break;
            case 7:
                PayPlayer(p, 50);
                b.ReplaceCommunicate("Bank wypłaca Ci należne 7% odsetek od kapitałów - otrzymujesz 50 $.", 20);
                b.ReplaceCommunicate("Naciśnij dowolny klawisz, aby kontynuować.", 30);
                Console.ReadKey(true);
                break;
            case 8:
                b.ReplaceCommunicate("Płacisz koszty leczenia w wysokości 20 $.", 20);
                TaxPlayer(p, 20);
                break;
            case 9:
                PayPlayer(p, 40);
                b.ReplaceCommunicate("Otrzymujesz zwrot nadpłaconego podatku dochodowego 40 $.", 20);
                b.ReplaceCommunicate("Naciśnij dowolny klawisz, aby kontynuować.", 30);
                Console.ReadKey(true);
                break;
            case 10:
                PayPlayer(p, 200);
                b.ReplaceCommunicate("Zająłeś II miejsce w konkursie piękności, otrzymujesz z banku 200 $.", 20);
                b.ReplaceCommunicate("Naciśnij dowolny klawisz, aby kontynuować.", 30);
                Console.ReadKey(true);
                break;
            case 11:
                b.ReplaceCommunicate("Wracasz do Wiednia.", 20);
                MovePlayer(p, 39);
                b.ReplaceCommunicate("Naciśnij dowolny klawisz, aby kontynuować.", 30);
                Console.ReadKey(true);
                break;
            case 12:
                b.ReplaceCommunicate("Płacisz za kartę 20 $.", 20);
                TaxPlayer(p, 20);
                break;
            case 13:
                PayPlayer(p, 200);
                b.ReplaceCommunicate("Otrzymujesz roczną rentę w wysokości 200 $.", 20);
                b.ReplaceCommunicate("Naciśnij dowolny klawisz, aby kontynuować.", 30);
                Console.ReadKey(true);
                break;
            case 14:
                b.ReplaceCommunicate("Wychodzisz wolny z Więzienia. Kartę należy zachować do wykorzystania.", 20);
                p.JailCard = true;
                b.ReplaceCommunicate("Naciśnij dowolny klawisz, aby kontynuować.", 30);
                Console.ReadKey(true);
                break;
            case 15:
                PayPlayer(p, 20);
                b.ReplaceCommunicate("Z magazynu, w którym kupujesz otrzymujesz rabat w wysokości 20 $.", 20);
                b.ReplaceCommunicate("Naciśnij dowolny klawisz, aby kontynuować.", 30);
                Console.ReadKey(true);
                break;
            default:
                b.ReplaceCommunicate("Płacisz składkę ubezpieczeniową w wysokości 20 $.", 20);
                TaxPlayer(p, 20);
                break;
        }
    }
}

public class GoToJail : SpecialLocation
{
    public GoToJail(Board b)
    {
        Board = b;
    }

    public override void LocationAction(Player p)
    {
        Board b = Board;
        b.ReplaceCommunicate("Idziesz do Więzienia.", 20);
        if (!p.JailCard)
        {
            b.MovePlayer(p.PlayerLocation, 10, p);
            p.PlayerLocation = 10;
            p.InJail += 2;
            b.PrintBoard();
        }
        else
        {
            b.ReplaceCommunicate("Unikasz Więzienia dzięki posiadanej karcie.", 21);
            p.JailCard = false;
        }
        b.ReplaceCommunicate("Naciśnij dowolny klawisz, aby kontynuować.", 30);
        Console.ReadKey(true);
    }
}

public class Jail : SpecialLocation
{
    public Jail(Board b)
    {
        Board = b;
    }

    public override void LocationAction(Player p)
    {
        Board b = Board;
        b.ReplaceCommunicate("Odwiedzasz Więzienie.", 20);
        b.ReplaceCommunicate("Naciśnij dowolny klawisz, aby kontynuować.", 30);
        Console.ReadKey(true);
    }
}

public class FreeParking : SpecialLocation
{
    public FreeParking(Board b)
    {
        Board = b;
    }

    public override void LocationAction(Player p)
    {
        Board b = Board;
        b.ReplaceCommunicate("Odwiedzasz Bezpłatny Parking.", 20);
        b.ReplaceCommunicate("Naciśnij dowolny klawisz, aby kontynuować.", 30);
        Console.ReadKey(true);
    }
}
