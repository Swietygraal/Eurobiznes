using System.Xml.Schema;

namespace Eurobiznes;
using System;

public class Game
{
    private Board b;
    private Locations l;
    private List<Player> players;
    private Random dice;

    public Game(int players_num)
    {
        b = new Board();
        l = new Locations();
        players = new List<Player>();
        dice = new Random();
        string[] colors = { "red", "green", "blue", "yellow" };
        for (int i = 0; i < players_num; i++)
        {
            players.Add(new Player(colors[i]));
            b.ReplaceChar('o', 33, 79+i);
        }
    }

    public void runGame()
    {
        b.printBoard();
        while (true)
        {
            for (int i = 0; i < players.Count; i++)
            {
                if (!(players[i].inJail()) && !(players[i].isBankrupt()))
                {
                    Console.WriteLine("1. Losuj");
                    while(Console.ReadKey(true).Key != ConsoleKey.D1)
                        continue;
                    int old_l = players[i].getLocation();
                    int roll1 = dice.Next(1, 7);
                    int roll2 = dice.Next(1, 7);
                    Console.WriteLine("Wylosowano " + roll1.ToString() + " i " + roll2.ToString());
                    int roll3 = 0;
                    int roll4 = 0;
                    if (roll1 == roll2)
                    { 
                        Console.WriteLine("Losuj ponownie");
                        while (Console.ReadKey(true).Key != ConsoleKey.D1) 
                            continue;
                        roll3 = dice.Next(1, 7);
                        roll4 = dice.Next(1, 7);
                        Console.WriteLine("Wylosowano " + roll3.ToString() + " i " + roll4.ToString());
                        if (roll3 == roll4)
                        { 
                            ((GoToJail)l.getLocation(30)).addJailTime(players[i]); 
                            Console.WriteLine("Idziesz do więzienia.");
                        }
                    }
                    if (!players[i].inJail()) 
                        players[i].newLocation(roll1 + roll2 + roll3 + roll4);
                    while (!Console.KeyAvailable)
                        continue;
                    int new_l = players[i].getLocation();
                    b.MovePlayer(old_l, new_l, i);
                    Console.Clear();
                    b.printBoard();
                    if ((l.getType(new_l)).Equals("Property"))
                        ((Property)l.getLocation(new_l)).propertyAction(players[i]);
                    else if ((l.getType(new_l)).Equals("GuardedParking"))
                        ((GuardedParking)l.getLocation(new_l)).PayForParking(players[i]);
                    else if ((l.getType(new_l)).Equals("GoToJail"))
                    {
                        ((GoToJail)l.getLocation(30)).addJailTime(players[i]);
                        Console.WriteLine("Idziesz do więzienia.");
                    }
                    else if ((l.getType(new_l)).Equals("WealthTax"))
                        ((WealthTax)l.getLocation(new_l)).payTax(players[i]);
                    else if ((l.getType(new_l)).Equals("RailwayLines"))
                        ((RailwayLines)l.getLocation(new_l)).railwayAction(players[i]);
                    else if ((l.getType(new_l)).Equals("PowerStation"))
                        ((PowerStation)l.getLocation(new_l)).powerStationAction(players[i], roll1+roll2+roll3+roll4);
                    else if ((l.getType(new_l)).Equals("WaterSupplyNetwork"))
                        ((WaterSupplyNetwork)l.getLocation(new_l)).waterSupplyNetworkAction(players[i], roll1+roll2+roll3+roll4);
                    else if ((l.getType(new_l)).Equals("Start"))
                        ((Start)l.getLocation(new_l)).StartPayment(players[i]);
                    else if ((l.getType(new_l)).Equals("Jail"))
                        Console.WriteLine("Odwiedzasz więzienie.");
                    else if ((l.getType(new_l)).Equals("FreeParking"))
                        Console.WriteLine("Odwiedzasz darmowy parking.");
                    else if ((l.getType(new_l)).Equals("RedChance"))
                        ((RedChance)l.getLocation(new_l)).RedChanceAction(players[i]);
                    else if ((l.getType(new_l)).Equals("BlueChance"))
                        ((BlueChance)l.getLocation(new_l)).BlueChanceAction(players[i]);
                    while (!Console.KeyAvailable) 
                        continue;
                }
                else if (players[i].inJail())
                {
                    Console.WriteLine("Jesteś w więzieniu, nie ruszasz się.");
                    players[i].goToJail(-1);
                }
            }
        }
    }
}