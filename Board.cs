using System.Text;

namespace Eurobiznes;

public class Board
{
    private StringBuilder[] rows;
    private int curr_turn;
    private Player curr_player;

    public Board()
    {
        int n = 5;
        StringBuilder row0 = new StringBuilder("                                             KOLEJ                SIEĆ                                  ");
        StringBuilder row1 = new StringBuilder("                RTRDAM SZANSA BRKSEL AMSTDM  PÓŁN.  MALMO GTBORG  WOD.  SZTKHM                          ");
        StringBuilder row2 = new StringBuilder("         ____________________________________________________________________________                   ");
        StringBuilder row3 = new StringBuilder("DARMOWY |      |      |      |      |      |      |      |      |      |      |      | IDŹ DO           ");
        StringBuilder row4 = new StringBuilder("PARKING |      |      |      |      |      |      |      |      |      |      |      | WIĘŹ.            ");
        StringBuilder row5 = new StringBuilder("        |______|______|______|______|______|______|______|______|______|______|______|                  ");
        StringBuilder row6 = new StringBuilder(" LONDYN |      |       B E N E L U X                      S Z W E C J A       |      | FRNKFRT          TURA ");
        StringBuilder row7 = new StringBuilder("        |      |                                                              |      |                  ");
        StringBuilder row8 = new StringBuilder("        |______|                                                              |______|                  GRACZ: ");
        StringBuilder row9 = new StringBuilder("GLASGOW |      |  A                                                           |      | KOLONIA          STAN KONTA: ");
        StringBuilder row10 = new StringBuilder("        |      |  N                                                        R  |      |                  WARTOŚĆ NIERUCHOMOŚCI: ");
        StringBuilder row11 = new StringBuilder("        |______|  G                                                        F  |______|                  ");
        StringBuilder row12 = new StringBuilder(" SZANSA |      |  L                                                        N  |      | SZANSA           Wybierz opcję:");
        StringBuilder row13 = new StringBuilder("        |      |  I                                                           |      |                  L  Losuj");
        StringBuilder row14 = new StringBuilder("        |______|  A                                                           |______|                  X  Poddaj się");
        StringBuilder row15 = new StringBuilder("LVRPOOL |      |                                                              |      | BONN             ");
        StringBuilder row16 = new StringBuilder("        |      |                                                              |      |                  ");
        StringBuilder row17 = new StringBuilder("        |______|                                                              |______|                  ");
        StringBuilder row18 = new StringBuilder("  KOLEJ |      |                                                              |      | KOLEJ            ");
        StringBuilder row19 = new StringBuilder("  ZACH. |      |                                                              |      | WSCH.            ");
        StringBuilder row20 = new StringBuilder("        |______|                                                              |______|                  ");
        StringBuilder row21 = new StringBuilder(" MADRYT |      |                                                              |      | SZANSA           ");
        StringBuilder row22 = new StringBuilder("        |      |  H                                                           |      |                  ");
        StringBuilder row23 = new StringBuilder("        |______|  I                                                           |______|                  ");
        StringBuilder row24 = new StringBuilder("SEWILLA |      |  S                                                        A  |      | INSBRCK          ");
        StringBuilder row25 = new StringBuilder("        |      |  Z                                                        U  |      |                  ");
        StringBuilder row26 = new StringBuilder("        |______|  P                                                        S  |______|                  ");
        StringBuilder row27 = new StringBuilder("ELEKTR. |      |  A                                                        T  |      | PODATEK          ");
        StringBuilder row28 = new StringBuilder("ATOMOWA |      |  N                                                        R  |      | OD               ");
        StringBuilder row29 = new StringBuilder("        |______|  I                                                        I  |______| WZBOG.           ");
        StringBuilder row30 = new StringBuilder("BRCLONA |      |  A                                                        A  |      | WIEDEŃ           ");
        StringBuilder row31 = new StringBuilder("        |      |         W Ł O C H Y                         G R E C J A      |      |                  ");
        StringBuilder row32 = new StringBuilder("        |______|______________________________________________________________|______|                  ");
        StringBuilder row33 = new StringBuilder("WZIENIE |      |      |      |      |      |      |      |      |      |      |      | START            ");
        StringBuilder row34 = new StringBuilder("        |      |      |      |      |      |      |      |      |      |      |      |                  ");
        StringBuilder row35 = new StringBuilder("        |______|______|______|______|______|______|______|______|______|______|______|                  ");
        StringBuilder row36 = new StringBuilder("                 RZYM  MDIOLN SZANSA NEAPOL  KOLEJ PARKNG  ATENY SZANSA SALNKI                          ");
        StringBuilder row37 = new StringBuilder("                                             POŁ.  STRZEŻ.                                              ");
    
        rows = new StringBuilder[]
        {
            row0, row1, row2, row3, row4, row5, row6, row7, row8, row9, row10, row11, row12,
            row13, row14, row15, row16, row17, row18, row19, row20, row21, row22, row23, row24,
            row25, row26, row27, row28, row29, row30, row31, row32, row33, row34, row35, row36, row37
        };
    }

    public void SetCurrents(int turn, Player p)
    {
        curr_turn = turn;
        curr_player = p;
    }

    public void ReplaceChar(char c, int row_ind, int char_ind)
    {
        rows[row_ind][char_ind] = c;
    }

    public void ReplaceCommunicate(string new_comm, int row_ind)
    {
        rows[row_ind].Remove(104, rows[row_ind].Length - 104);
        rows[row_ind].Append(new_comm);
        PrintBoard();
    }

    public void ClearCommunicates()
    {
        rows[6].Remove(109, rows[6].Length - 109);
        rows[6].Append("                                                  ");
        rows[8].Remove(111, rows[8].Length - 111);
        rows[8].Append("                                                  ");
        rows[9].Remove(116, rows[9].Length - 116);
        rows[9].Append("                                                  ");
        rows[10].Remove(127, rows[10].Length - 127);
        rows[10].Append("                                                  ");
        for (int i = 15; i < rows.Length; i++)
        {
            rows[i].Remove(104, rows[i].Length - 104);
            rows[i].Append("                                                                                                         ");
        }

        PrintBoard(true);
    }
    
    public void PrintBoard(bool clear = false)
    {
        Console.SetCursorPosition(0, 0);
        for (int i = 0; i < 38; i++)
        {
            if (!clear)
            {
                if (i == 6)
                {
                    rows[6].Remove(109, rows[6].Length - 109);
                    rows[6].Append(curr_turn);
                }
                else if (i == 8)
                {
                    rows[8].Remove(111, rows[8].Length - 111);
                    rows[8].Append(curr_player.Symbol);
                }
                else if (i == 9)
                {
                    rows[9].Remove(116, rows[9].Length - 116);
                    rows[9].Append(curr_player.Money);
                }
                else if (i == 10)
                {
                    rows[10].Remove(127, rows[10].Length - 127);
                    rows[10].Append(curr_player.ValueOfProperties);
                }
            }

            Console.WriteLine(rows[i]);
        }
    }

    public void MovePlayer(int old_location, int new_location, Player player)
    {
        if (old_location < 10)
            this.ReplaceChar(' ', 33, 79 + player.PlayerNr - old_location * 7);
        else if(old_location < 20)
            this.ReplaceChar(' ', 33 - (old_location - 10) * 3, 9 + player.PlayerNr);
        else if(old_location < 30)
            this.ReplaceChar(' ', 3, 9 + player.PlayerNr + (old_location - 20) * 7);
        else
            this.ReplaceChar(' ', 3 + (old_location - 30) * 3, 79 + player.PlayerNr);
        
        if(new_location < 10)
            this.ReplaceChar(player.Symbol, 33, 79 + player.PlayerNr - new_location * 7);
        else if(new_location < 20)
            this.ReplaceChar(player.Symbol, 33 - (new_location - 10) * 3, 9 + player.PlayerNr);
        else if(new_location < 30)
            this.ReplaceChar(player.Symbol, 3, 9 + player.PlayerNr + (new_location - 20) * 7);
        else
            this.ReplaceChar(player.Symbol, 3 + (new_location - 30) * 3, 79 + player.PlayerNr);
        PrintBoard();
    }
}