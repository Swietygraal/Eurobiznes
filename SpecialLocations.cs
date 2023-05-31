namespace Eurobiznes;

public class Start
{
    public Start()
    {}

    public void StartPayment(Player p)
    {
        p.setMoney(400);
    }
}

public class BlueChance
{
    private Random roll;

    public BlueChance()
    {
        roll = new Random();
    }

    public void BlueChanceAction(Player p)
    {
        int n = roll.Next(1, 17);
        switch (n)
        {
            case 1:
                p.setMoney(400);
                Console.WriteLine("Bank pomylił się na twoją korzyść, otrzymujesz 400.");
                break;
            case 2:
                p.setMoney(-400);
                Console.WriteLine("Płacisz na budowę szpitala 400.");
                if (p.getMoney() < 0)
                {
                    p.setBankrupt();
                    Console.WriteLine("Bankrutujesz.");
                }
                break;
            default:
                p.setMoney(50);
                Console.WriteLine("Bank wypłaci ci należne 7% odsetek od kapitałów - otrzymujesz 50.");
                break;
        }
    }
}

public class RedChance
{
    private Random roll;

    public RedChance()
    {
        roll = new Random();
    }

    public void RedChanceAction(Player p)
    {
        int n = roll.Next(1, 17);
        switch (n)
        {
            case 1:
                p.setMoney(100);
                Console.WriteLine("Bank wypłaca ci procenty w wysokości 100.");
                break;
            case 2:
                p.setMoney(-40);
                Console.WriteLine("Piłeś w czasie pracy, płacisz karę 40.");
                if (p.getMoney() < 0)
                {
                    p.setBankrupt();
                    Console.WriteLine("Bankrutujesz.");
                }
                break;
            default:
                p.setMoney(300);
                Console.WriteLine("Bank wypłaca ci należne odsetki w wysokości 300.");
                break;
        }
    }
}

public class GuardedParking
{
    public GuardedParking()
    {}

    public void PayForParking(Player p)
    {
        if (p.getMoney() < 400)
        {
            p.setBankrupt();
            Console.WriteLine("Nie stać cię na opłatę, bankrutujesz.");
        }
        else
        {
            p.setMoney(-400);
            Console.WriteLine("Płacisz 400 za parking.");
        }
    }
}

public class RailwayLines
{
    private string name;
    private int price;
    private int base_rent;
    private int two_railways_rent;
    private int three_railways_rent;
    private int four_railways_rent;
    private int mortgage;
    private Player? owner;

    public RailwayLines(string n, int p, int r, int r2_r, int r3_r, int r4_4, int m)
    {
        name = n;
        price = p;
        base_rent = r;
        two_railways_rent = r2_r;
        three_railways_rent = r3_r;
        four_railways_rent = r4_4;
        mortgage = m;
        owner = null;
    }
    
    private int getRent()
    {
        if (owner.ownedRailwaysNumber() == 1)
            return base_rent;
        else if (owner.ownedRailwaysNumber() == 2)
            return two_railways_rent;
        else if (owner.ownedRailwaysNumber() == 3)
            return three_railways_rent;
        return four_railways_rent;
    }

    public void railwayAction(Player p)
    {
        if (owner != null && owner != p)
        {
            int rent = this.getRent();
            if (p.getMoney() < rent)
            {
                p.setBankrupt();
                Console.WriteLine("Nie stać cię na opłatę, bankrutujesz.");
            }
            else
            {
                p.setMoney(-rent);
                owner.setMoney(rent);
                Console.WriteLine("Płacisz " + rent.ToString());
            }
        }
        else
        {
            Console.WriteLine("Czy chcesz kupić Linie kolejowe " + name + " za " + price.ToString() + "? T/N");
            ConsoleKeyInfo decision = Console.ReadKey(true);
            while (decision.Key != ConsoleKey.T && decision.Key != ConsoleKey.N)
                decision = Console.ReadKey(true);
            if (decision.Key == ConsoleKey.T)
            {
                if(p.getMoney() < price)
                    Console.WriteLine("Nie stać cię na kupno.");
                else
                {
                    owner = p;
                    p.setMoney(-price);
                    p.addRailwayLine(this);
                    Console.WriteLine("Kupiłeś Linie kolejowe " + name);
                }
            }
        }
    }
}

public class Jail
{
    public Jail()
    {}
}

public class PowerStation
{
    private int price;
    private int mortgage;
    private Player? owner;

    public PowerStation()
    {
        price = 300;
        mortgage = 150;
        owner = null;
    }

    public void powerStationAction(Player p, int roll)
    {
        if (owner != null && owner != p)
        {
            int rent = roll * 10;
            if (owner.OwnsWaterSupplyNetwork())
                rent *= 2;
            if (p.getMoney() < rent)
            {
                p.setBankrupt();
                Console.WriteLine("Nie stać cię na opłatę, bankrutujesz.");
            }
            else
            {
                p.setMoney(-rent);
                owner.setMoney(rent);
                Console.WriteLine("Płacisz " + rent.ToString());
            }
        }
        else
        {
            Console.WriteLine("Czy chcesz kupić Elektrownię Atomową za " + price.ToString() + "? T/N");
            ConsoleKeyInfo decision = Console.ReadKey(true);
            while (decision.Key != ConsoleKey.T && decision.Key != ConsoleKey.N)
                decision = Console.ReadKey(true);
            if (decision.Key == ConsoleKey.T)
            {
                if(p.getMoney() < price)
                    Console.WriteLine("Nie stać cię na kupno.");
                else
                {
                    owner = p;
                    p.setMoney(-price);
                    p.SetPowerStationOwner();
                    Console.WriteLine("Kupiłeś Elektrownię Atomową.");
                }
            }
        }
    }
}

public class FreeParking
{
    public FreeParking()
    {}
}

public class WaterSupplyNetwork
{
    private int price;
    private int mortgage;
    private Player? owner;

    public WaterSupplyNetwork()
    {
        price = 300;
        mortgage = 150;
        owner = null;
    }

    public void waterSupplyNetworkAction(Player p, int roll)
    {
        if (owner != null && owner != p)
        {
            int rent = roll * 10;
            if (owner.OwnsPowerStation())
                rent *= 2;
            if (p.getMoney() < rent)
            {
                p.setBankrupt();
                Console.WriteLine("Nie stać cię na opłatę, bankrutujesz.");
            }
            else
            {
                p.setMoney(-rent);
                owner.setMoney(rent);
                Console.WriteLine("Płacisz " + rent.ToString());
            }
        }
        else
        {
            Console.WriteLine("Czy chcesz kupić Sieć Wodociągową za " + price.ToString() + "? T/N");
            ConsoleKeyInfo decision = Console.ReadKey(true);
            while (decision.Key != ConsoleKey.T && decision.Key != ConsoleKey.N)
                decision = Console.ReadKey(true);
            if (decision.Key == ConsoleKey.T)
            {
                if(p.getMoney() < price)
                    Console.WriteLine("Nie stać cię na kupno.");
                else
                {
                    owner = p;
                    p.setMoney(-price);
                    p.SetWaterSupplyNetworkOwner();
                    Console.WriteLine("Kupiłeś Sieć Wodociągową.");
                }
            }
        }
    }
}

public class GoToJail
{
    public GoToJail()
    {}

    public void addJailTime(Player p)
    {
        p.goToJail(2);
    }
}

public class WealthTax
{
    public WealthTax()
    {}

    public void payTax(Player p)
    {
        if (p.getMoney() < 200)
        {
            p.setBankrupt();
            Console.WriteLine("Nie stać cię na opłatę, bankrutujesz.");
        }
        else
        {
            p.setMoney(-200);
            Console.WriteLine("Płacisz 200 podatku.");
        }
    }
}