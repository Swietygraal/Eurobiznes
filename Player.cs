using System.Data;

namespace Eurobiznes;

public class Player
{
    private int money;
    private string color;
    private int location;
    private List<Property> owned_properties;
    private List<RailwayLines> owned_railway_lines;
    private int rem_turns_in_jail;
    private bool is_bankrupt;
    private bool owns_power_station;
    private bool owns_water_supply_network;

    public Player(string c)
    {
        money = 3000;
        color = c;
        location = 0;
        owned_properties = new List<Property>();
        owned_railway_lines = new List<RailwayLines>();
        rem_turns_in_jail = 0;
        is_bankrupt = false;
        owns_power_station = false;
        owns_water_supply_network = false;
    }

    public bool inJail()
    {
        return (rem_turns_in_jail > 0);
    }

    public bool isBankrupt()
    {
        return is_bankrupt;
    }

    public void newLocation(int n)
    {
        location += n;
        if (location > 39)
            location -= 40;
    }

    public int getLocation()
    {
        return location;
    }

    public void goToJail(int turns)
    {
        rem_turns_in_jail += turns;
        location = 10;
    }

    public int getMoney()
    {
        return money;
    }

    public void setBankrupt()
    {
        is_bankrupt = true;
    }

    public void setMoney(int amount)
    {
        money += amount;
    }

    public void addProperty(Property p)
    {
        owned_properties.Add(p);
    }

    public void addRailwayLine(RailwayLines r)
    {
        owned_railway_lines.Add(r);
    }

    public int ownedRailwaysNumber()
    {
        return owned_railway_lines.Count;
    }

    public bool OwnsPowerStation()
    {
        return owns_power_station;
    }

    public bool OwnsWaterSupplyNetwork()
    {
        return owns_water_supply_network;
    }

    public void SetPowerStationOwner()
    {
        owns_power_station = true;
    }

    public void SetWaterSupplyNetworkOwner()
    {
        owns_water_supply_network = true;
    }
}
