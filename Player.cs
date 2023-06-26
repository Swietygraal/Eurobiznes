using System.Data;

namespace Eurobiznes;

public class Player
{
    private int player_nr;
    private int money;
    private char symbol;
    private int location;
    private List<BuyableLocation> owned_locations;
    private int value_of_owned_properties;
    private int owned_railways;
    private int rem_turns_in_jail;
    private bool is_bankrupt;
    private int power_and_water_owned;
    private bool has_jail_card;
    private int houses_built;
    private int hotels_built;

    public Player(char sym, int nr)
    {
        player_nr = nr;
        money = 3000;
        symbol = sym;
        location = 0;
        value_of_owned_properties = 0;
        owned_locations = new List<BuyableLocation>();
        owned_railways = 0;
        rem_turns_in_jail = 0;
        is_bankrupt = false;
        power_and_water_owned = 0;
        has_jail_card = false;
        houses_built = 0;
        hotels_built = 0;
    }

    public int Money
    {
        get => money;
        set => money = value;
    }

    public bool IsBankrupt
    {
        get => is_bankrupt;
    }

    public int InJail
    {
        get => rem_turns_in_jail;
        set => rem_turns_in_jail = value;
    }

    public int PlayerLocation
    {
        get => location;
        set => location = value;
    }

    public int ValueOfProperties
    {
        get => value_of_owned_properties;
        set => value_of_owned_properties = value;
    }

    public int PowerAndWaterOwned
    {
        get => power_and_water_owned;
        set => power_and_water_owned = value;
    }

    public char Symbol
    {
        get => symbol;
    }

    public int PlayerNr
    {
        get => player_nr;
    }

    public int OwnedRailways
    {
        get => owned_railways;
        set => owned_railways = value;
    }

    public bool JailCard
    {
        get => has_jail_card;
        set => has_jail_card = value;
    }

    public int HousesBuilt
    {
        get => houses_built;
        set => houses_built = value;
    }

    public int HotelsBuilt
    {
        get => hotels_built;
        set => hotels_built = value;
    }

    public void AddLocation(BuyableLocation p)
    {
        owned_locations.Add(p);
    }

    public void RemoveLocation(BuyableLocation p)
    {
        owned_locations.Remove(p);
    }

    public void Lose(Board b)
    {
        money = 0;
        foreach (BuyableLocation l in owned_locations)
            l.Owner = null;
        owned_locations.Clear();
        value_of_owned_properties = 0;
        owned_railways = 0;
        is_bankrupt = true;
        power_and_water_owned = 0;
        houses_built = 0;
        hotels_built = 0;
        symbol = ' ';
        b.MovePlayer(location, location, this);
    }
}
