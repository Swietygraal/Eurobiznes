namespace Eurobiznes;
using System;

public class Game
{
    private Board b;
    private Location[] l;
    private List<Player> players;
    private Random dice;
    private int turn;
    private int players_in_game;

    public Game(int players_num)
    {
        players_in_game = players_num;
        turn = 0;
        b = new Board();
        l = new Location[]
        {
            new Start(b),
            new City("Saloniki", 120, new List<int>(){10, 40, 120, 360, 640, 900}, 60, 100, 100, b),
            new BlueChance(b),
            new City("Ateny", 120, new List<int>(){10, 40, 120, 360, 640, 900}, 60, 100, 100, b),
            new GuardedParking(b),
            new RailwayLine("Linie Kolejowe Południowe", 400, new List<int>(){50, 100, 200, 400}, 200, b),
            new City("Neapol", 200, new List<int>(){15, 60, 180, 540, 800, 1100}, 100, 100, 100, b),
            new RedChance(b),
            new City("Mediolan", 200, new List<int>(){15, 60, 180, 540, 800, 1100}, 100, 100, 100, b),
            new City("Rzym", 240, new List<int>(){20, 80, 200, 600, 900, 1200}, 120, 100, 100, b),
            new Jail(b),
            new City("Barcelona", 280, new List<int>(){20, 100, 300, 900, 1250, 1500}, 140, 200, 200, b),
            new PowerAndWater("Elektrownia Atomowa", 300, new List<int>(){}, 150, b),
            new City("Sewilla", 280, new List<int>(){20, 100, 300, 900, 1250, 1500}, 140, 200, 200, b),
            new City("Madryt", 320, new List<int>(){25, 120, 360, 1000, 1400, 1800}, 160, 200, 200, b),
            new RailwayLine("Linie Kolejowe Zachodnie", 400, new List<int>(){50, 100, 200, 400}, 200, b),
            new City("Liverpool", 360, new List<int>(){30, 140, 400, 1100, 1500, 1900}, 180, 200, 200, b),
            new BlueChance(b),
            new City("Glasgow", 360, new List<int>(){30, 140, 400, 1100, 1500, 1900}, 180, 200, 200, b),
            new City("Londyn", 400, new List<int>(){35, 160, 440, 1200, 1600, 2000}, 200, 200, 200, b),
            new FreeParking(b),
            new City("Rotterdam", 440, new List<int>(){35, 180, 500, 1400, 1750, 2100}, 220, 300, 300, b),
            new RedChance(b),
            new City("Bruksela", 440, new List<int>(){35, 180, 500, 1400, 1750, 2100}, 220, 300, 300, b),
            new City("Amsterdam", 480, new List<int>(){40, 200, 600, 1500, 1850, 2200}, 240, 300, 300, b),
            new RailwayLine("Linie Kolejowe Północne", 400, new List<int>(){50, 100, 200, 400}, 200, b),
            new City("Malmo", 520, new List<int>(){45, 220, 660, 1600, 1950, 2300}, 260, 300, 300, b),
            new City("Goteborg", 520, new List<int>(){45, 220, 660, 1600, 1950, 2300}, 260, 300, 300, b),
            new PowerAndWater("Sieć Wodociągów", 300, new List<int>(){}, 150, b),
            new City("Sztokholm", 560, new List<int>(){50, 240, 720, 1700, 2050, 2400}, 280, 300, 300, b),
            new GoToJail(b),
            new City("Frankfurt", 600, new List<int>(){55, 260, 780, 1900, 2200, 2550}, 300, 400, 400, b),
            new City("Kolonia", 600, new List<int>(){55, 260, 780, 1900, 2200, 2550}, 300, 400, 400, b),
            new BlueChance(b),
            new City("Bonn", 640, new List<int>(){60, 300, 900, 2000, 2400, 2800}, 320, 400, 400, b),
            new RailwayLine("Linie Kolejowe Wschodnie", 400, new List<int>(){50, 100, 200, 400}, 200, b),
            new RedChance(b),
            new City("Innsbruck", 700, new List<int>(){70, 350, 1000, 2200, 2600, 3000}, 350, 400, 400, b),
            new WealthTax(b),
            new City("Wiedeń", 800, new List<int>(){100, 400, 1200, 2800, 3400, 4000}, 400, 400, 400, b)
        };
        players = new List<Player>();
        dice = new Random();
        char[] symbols = {'O', 'X', '$', '#'};
        for (int i = 0; i < players_num; i++)
        {
            players.Add(new Player(symbols[i], i));
            b.ReplaceChar(symbols[i], 33, 79+i);
        }
    }

    public char RunGame()
    {
        b.SetCurrents(0, players[0]);
        b.PrintBoard();
        while (players_in_game > 1)
        {
            for (int i = 0; i < players.Count; i++)
            {
                if (players_in_game == 1)
                    break;
                b.SetCurrents(turn, players[i]);
                b.PrintBoard();
                if (players[i].InJail == 0 && !(players[i].IsBankrupt))
                {
                    ConsoleKeyInfo decision = Console.ReadKey(true);
                    while(decision.Key != ConsoleKey.L && decision.Key != ConsoleKey.X)
                        decision = Console.ReadKey(true);
                    if (decision.Key == ConsoleKey.L)
                    {
                        int old_l = players[i].PlayerLocation;
                        int roll1 = dice.Next(1, 7);
                        int roll2 = dice.Next(1, 7);
                        b.ReplaceCommunicate("Wylosowano " + roll1 + " i " + roll2, 15);
                        int roll3 = 0;
                        int roll4 = 0;
                        if (roll1 == roll2)
                        {
                            b.ReplaceCommunicate("Losuj ponownie.", 16);
                            while (Console.ReadKey(true).Key != ConsoleKey.L)
                                continue;
                            roll3 = dice.Next(1, 7);
                            roll4 = dice.Next(1, 7);
                            b.ReplaceCommunicate("Wylosowano " + roll3 + " i " + roll4, 17);
                            if (roll3 == roll4)
                                l[30].LocationAction(players[i]);
                        }

                        if (players[i].InJail == 0)
                        {
                            players[i].PlayerLocation = (players[i].PlayerLocation + roll1 + roll2 + roll3 + roll4) % 40;
                            if (old_l > players[i].PlayerLocation && players[i].PlayerLocation != 0)
                            {
                                l[0].LocationAction(players[i]);
                                b.ClearCommunicates();
                            }
                            b.MovePlayer(old_l, players[i].PlayerLocation, players[i]);
                            l[players[i].PlayerLocation].LocationAction(players[i]);
                        }

                        if (players[i].IsBankrupt)
                            players_in_game--;
                    }
                    else if (decision.Key == ConsoleKey.X)
                    {
                        players[i].Lose(b);
                        players_in_game--;
                    }
                }
                else if (players[i].InJail > 0)
                {
                    b.ReplaceCommunicate("Jesteś w Więzieniu, nie ruszasz się.", 20);
                    b.ReplaceCommunicate("Naciśnij dowolny klawisz, aby kontynuować.", 30);
                    players[i].InJail -= 1;
                    Console.ReadKey(true);
                }
                b.ClearCommunicates();
            }
            turn++;
        }

        foreach (Player p in players)
        {
            if (!p.IsBankrupt)
                return p.Symbol;
        }

        return '?';
    }
}