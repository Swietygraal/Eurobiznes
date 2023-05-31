namespace Eurobiznes;

public class Locations
{
    private object[] fields;
    private string[] field_types;

    public Locations()
    {
        Start start = new Start();
        Property saloniki = new Property("Saloniki", 120, 100, 100, 10, 40, 120, 360, 640, 900, 60);
        BlueChance bchance1 = new BlueChance();
        Property ateny = new Property("Ateny", 120, 100, 100, 10, 40, 120, 360, 640, 900, 60);
        GuardedParking guardedParking = new GuardedParking();
        RailwayLines poludniowe = new RailwayLines("południowe", 400, 50, 100, 200, 400, 200);
        Property neapol = new Property("Neapol", 200, 100, 100, 15, 60, 180, 540, 800, 1100, 100);
        RedChance rchance1 = new RedChance();
        Property mediolan = new Property("Mediolan", 200, 100, 100, 15, 60, 180, 540, 800, 1100, 100);
        Property rzym = new Property("Rzym", 240, 100, 100, 20, 80, 200, 600, 900, 1200, 120);
        Jail jail = new Jail();
        Property barcelona = new Property("Barcelona", 280, 200, 200, 20, 100, 300, 900, 1250, 1500, 140);
        PowerStation powerStation = new PowerStation();
        Property sewilla = new Property("Sewilla", 280, 200, 200, 20, 100, 300, 900, 1250, 1500, 140);
        Property madryt = new Property("Madryt", 320, 200, 200, 25, 120, 360, 1000, 1400, 1800, 160);
        RailwayLines zachodnie = new RailwayLines("zachodnie", 400, 50, 100, 200, 400, 200);
        Property liverpool = new Property("Liverpool", 360, 200, 200, 30, 140, 400, 1100, 1500, 1900, 180);
        BlueChance bchance2 = new BlueChance();
        Property glasgow = new Property("Glasgow", 360, 200, 200, 30, 140, 400, 1100, 1500, 1900, 180);
        Property londyn = new Property("Londyn", 400, 200, 200, 35, 160, 440, 1200, 1600, 2000, 200);
        FreeParking freeParking = new FreeParking();
        Property rotterdam = new Property("Rotterdam", 440, 300, 300, 35, 180, 500, 1400, 1750, 2100, 220);
        RedChance rchance2 = new RedChance();
        Property bruksela = new Property("Bruksela", 440, 300, 300, 35, 180, 500, 1400, 1750, 2100, 220);
        Property amsterdam = new Property("Amsterdam", 480, 300, 300, 40, 200, 600, 1500, 1850, 2200, 240);
        RailwayLines polnocne = new RailwayLines("północne", 400, 50, 100, 200, 400, 200);
        Property malmo = new Property("Malmo", 520, 300, 300, 45, 220, 660, 1600, 1950, 2300, 260);
        Property goteborg = new Property("Goteborg", 520, 300, 300, 45, 220, 660, 1600, 1950, 2300, 260);
        WaterSupplyNetwork waterSupplyNetwork = new WaterSupplyNetwork();
        Property sztokholm = new Property("Sztokholm", 560, 300, 300, 50, 240, 720, 1700, 2050, 2400, 280);
        GoToJail gtjail = new GoToJail();
        Property frankfurt = new Property("Frankfurt", 600, 400, 400, 55, 260, 780, 1900, 2200, 2550, 300);
        Property kolonia = new Property("Kolonia", 600, 400, 400, 55, 260, 780, 1900, 2200, 2550, 300);
        BlueChance bchance3 = new BlueChance();
        Property bonn = new Property("Bonn", 640, 400, 400, 60, 300, 900, 2000, 2400, 2800, 320);
        RailwayLines wschodnie = new RailwayLines("wschodnie", 400, 50, 100, 200, 400, 200);
        RedChance rchance3 = new RedChance();
        Property innsbruck = new Property("Innsbruck", 700, 400, 400, 70, 350, 1000, 2200, 2600, 3000, 350);
        WealthTax wealthTax = new WealthTax();
        Property wieden = new Property("Wiedeń", 800, 400, 400, 100, 400, 1200, 2800, 3400, 4000, 400);

        fields = new object[]
        {
            start, saloniki, bchance1, ateny, guardedParking, poludniowe, neapol, rchance1, mediolan, rzym,
            jail, barcelona, powerStation, sewilla, madryt, zachodnie, liverpool, bchance2, glasgow, londyn,
            freeParking, rotterdam, rchance2, bruksela, amsterdam, polnocne, malmo, goteborg, waterSupplyNetwork,
            sztokholm, gtjail, frankfurt, kolonia, bchance3, bonn, wschodnie, rchance3, innsbruck, wealthTax, wieden
        };
        field_types = new string[]
        {
            "Start", "Property", "BlueChance", "Property", "GuardedParking", "RailwayLines", "Property", "RedChance",
            "Property", "Property", "Jail", "Property", "PowerStation", "Property", "Property", "RailwayLines",
            "Property", "BlueChance", "Property", "Property", "FreeParking", "Property", "RedChance", "Property",
            "Property", "RailwayLines", "Property", "Property", "WaterSupplyNetwork", "Property", "GoToJail",
            "Property", "Property", "BlueChance", "Property", "RailwayLines", "RedChance", "Property", "WealthTax",
            "Property"
        };
    }

    public object getLocation(int i)
    {
        return fields[i];
    }

    public string getType(int i)
    {
        return field_types[i];
    }
}