using System.Text;

namespace Eurobiznes;

public class Board
{
    private StringBuilder[] rows;

    public Board()
    {
        StringBuilder row0 = new StringBuilder("                                             KOLEJ                SIEĆ                        ");
        StringBuilder row1 = new StringBuilder("                RTRDAM SZANSA BRKSEL AMSTDM  PÓŁN.  MALMO GTBORG  WOD.  SZTKHM                ");
        StringBuilder row2 = new StringBuilder("         ____________________________________________________________________________         ");
        StringBuilder row3 = new StringBuilder("DARMOWY |      |      |      |      |      |      |      |      |      |      |      | IDŹ DO ");
        StringBuilder row4 = new StringBuilder("PARKING |      |      |      |      |      |      |      |      |      |      |      | WIĘŹ.  ");
        StringBuilder row5 = new StringBuilder("        |______|______|______|______|______|______|______|______|______|______|______|        ");
        StringBuilder row6 = new StringBuilder(" LONDYN |      |                                                              |      | FRNKFRT");
        StringBuilder row7 = new StringBuilder("        |      |                                                              |      |        ");
        StringBuilder row8 = new StringBuilder("        |______|                                                              |______|        ");
        StringBuilder row9 = new StringBuilder("GLASGOW |      |                                                              |      | KOLONIA");
        StringBuilder row10 = new StringBuilder("        |      |                                                              |      |        ");
        StringBuilder row11 = new StringBuilder("        |______|                                                              |______|        ");
        StringBuilder row12 = new StringBuilder(" SZANSA |      |                                                              |      | SZANSA ");
        StringBuilder row13 = new StringBuilder("        |      |                                                              |      |        ");
        StringBuilder row14 = new StringBuilder("        |______|                                                              |______|        ");
        StringBuilder row15 = new StringBuilder("LVRPOOL |      |                                                              |      | BONN   ");
        StringBuilder row16 = new StringBuilder("        |      |                                                              |      |        ");
        StringBuilder row17 = new StringBuilder("        |______|                                                              |______|        ");
        StringBuilder row18 = new StringBuilder("  KOLEJ |      |                                                              |      | KOLEJ  ");
        StringBuilder row19 = new StringBuilder("  ZACH. |      |                                                              |      | WSCH.  ");
        StringBuilder row20 = new StringBuilder("        |______|                                                              |______|        ");
        StringBuilder row21 = new StringBuilder(" MADRYT |      |                                                              |      | SZANSA ");
        StringBuilder row22 = new StringBuilder("        |      |                                                              |      |        ");
        StringBuilder row23 = new StringBuilder("        |______|                                                              |______|        ");
        StringBuilder row24 = new StringBuilder("SEWILLA |      |                                                              |      | INSBRCK");
        StringBuilder row25 = new StringBuilder("        |      |                                                              |      |        ");
        StringBuilder row26 = new StringBuilder("        |______|                                                              |______|        ");
        StringBuilder row27 = new StringBuilder("ELEKTR. |      |                                                              |      | PODATEK");
        StringBuilder row28 = new StringBuilder("ATOMOWA |      |                                                              |      | OD     ");
        StringBuilder row29 = new StringBuilder("        |______|                                                              |______| WZBOG. ");
        StringBuilder row30 = new StringBuilder("BRCLONA |      |                                                              |      | WIEDEŃ ");
        StringBuilder row31 = new StringBuilder("        |      |                                                              |      |        ");
        StringBuilder row32 = new StringBuilder("        |______|______________________________________________________________|______|        ");
        StringBuilder row33 = new StringBuilder("WZIENIE |      |      |      |      |      |      |      |      |      |      |      | START  ");
        StringBuilder row34 = new StringBuilder("        |      |      |      |      |      |      |      |      |      |      |      |        ");
        StringBuilder row35 = new StringBuilder("        |______|______|______|______|______|______|______|______|______|______|______|        ");
        StringBuilder row36 = new StringBuilder("                 RZYM  MDIOLN SZANSA NEAPOL  KOLEJ PARKNG  ATENY SZANSA SALNKI                ");
        StringBuilder row37 = new StringBuilder("                                             POŁ.  STRZEŻ.                                    ");
    
        rows = new StringBuilder[]
        {
            row0, row1, row2, row3, row4, row5, row6, row7, row8, row9, row10, row11, row12,
            row13, row14, row15, row16, row17, row18, row19, row20, row21, row22, row23, row24,
            row25, row26, row27, row28, row29, row30, row31, row32, row33, row34, row35, row36, row37
        };
    }

    public void ReplaceChar(char c, int row_ind, int char_ind)
    {
        rows[row_ind][char_ind] = c;
    }
    public void printBoard()
    {
        for (int i = 0; i < 38; i++)
        {
            Console.WriteLine(rows[i].ToString());
        }
    }

    public void MovePlayer(int old_location, int new_location, int player_nr)
    {
        if (old_location < 10)
            this.ReplaceChar(' ', 33, 79 + player_nr - old_location * 7);
        else if(old_location < 20)
            this.ReplaceChar(' ', 33 - (old_location - 10) * 3, 9 + player_nr);
        else if(old_location < 30)
            this.ReplaceChar(' ', 3, 9 + player_nr + (old_location - 20) * 7);
        else
            this.ReplaceChar(' ', 3 + (old_location - 30) * 3, 79 + player_nr);
        
        if(new_location < 10)
            this.ReplaceChar('o', 33, 79 + player_nr - new_location * 7);
        else if(new_location < 20)
            this.ReplaceChar('o', 33 - (new_location - 10) * 3, 9 + player_nr);
        else if(new_location < 30)
            this.ReplaceChar('o', 3, 9 + player_nr + (new_location - 20) * 7);
        else
            this.ReplaceChar('o', 3 + (new_location - 30) * 3, 79 + player_nr);
    }
}