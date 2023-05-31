namespace Eurobiznes;

public class Property
{
    private string name;
    private int price;
    private int house_price;
    private int hotel_price;
    private int base_rent;
    private int one_house_rent;
    private int two_houses_rent;
    private int three_houses_rent;
    private int four_houses_rent;
    private int hotel_rent;
    private int mortgage;
    private int number_of_houses;
    private bool has_hotel;
    private bool is_mortgaged;
    private Player? owner;

    public Property(string n, int p, int h_p, int ht_p, int r, int h1_r, int h2_r, int h3_r, int h4_r, int ht_r, int m)
    {
        name = n;
        price = p;
        house_price = h_p;
        hotel_price = ht_p;
        base_rent = r;
        one_house_rent = h1_r;
        two_houses_rent = h2_r;
        three_houses_rent = h3_r;
        four_houses_rent = h4_r;
        hotel_rent = ht_r;
        mortgage = m;
        number_of_houses = 0;
        has_hotel = false;
        is_mortgaged = false;
        owner = null;
    }

    private int getRent()
    {
        if (has_hotel)
            return hotel_rent;
        else if (number_of_houses == 0)
            return base_rent;
        else if (number_of_houses == 1)
            return one_house_rent;
        else if (number_of_houses == 2)
            return two_houses_rent;
        else if (number_of_houses == 3)
            return three_houses_rent;
        return four_houses_rent;
    }

    public void propertyAction(Player p)
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
            Console.WriteLine("Czy chcesz kupić " + name + " za " + price.ToString() + "? T/N");
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
                    p.addProperty(this);
                    Console.WriteLine("Kupiłeś " + name);
                }
            }
        }
    }
}