using System;
using System.Text;
using System.Collections.Generic;
using Eurobiznes;

class Program
{
    static void Main()
    {
        Console.WriteLine("                                                                                                                                                                                                    ");
        Console.WriteLine("                                                                                                                                                                                                    ");
        Console.WriteLine("EEEEEEEEEEEEEEEEEEEEEEUUUUUUUU     UUUUUUUURRRRRRRRRRRRRRRRR        OOOOOOOOO     BBBBBBBBBBBBBBBBB   IIIIIIIIIIZZZZZZZZZZZZZZZZZZZNNNNNNNN        NNNNNNNNEEEEEEEEEEEEEEEEEEEEEE   SSSSSSSSSSSSSSS ");
        Console.WriteLine("E::::::::::::::::::::EU::::::U     U::::::UR::::::::::::::::R     OO:::::::::OO   B::::::::::::::::B  I::::::::IZ:::::::::::::::::ZN:::::::N       N::::::NE::::::::::::::::::::E SS:::::::::::::::S");
        Console.WriteLine("E::::::::::::::::::::EU::::::U     U::::::UR::::::RRRRRR:::::R  OO:::::::::::::OO B::::::BBBBBB:::::B I::::::::IZ:::::::::::::::::ZN::::::::N      N::::::NE::::::::::::::::::::ES:::::SSSSSS::::::S");
        Console.WriteLine("EE::::::EEEEEEEEE::::EUU:::::U     U:::::UURR:::::R     R:::::RO:::::::OOO:::::::OBB:::::B     B:::::BII::::::IIZ:::ZZZZZZZZ:::::Z N:::::::::N     N::::::NEE::::::EEEEEEEEE::::ES:::::S     SSSSSSS");
        Console.WriteLine("  E:::::E       EEEEEE U:::::U     U:::::U   R::::R     R:::::RO::::::O   O::::::O  B::::B     B:::::B  I::::I  ZZZZZ     Z:::::Z  N::::::::::N    N::::::N  E:::::E       EEEEEES:::::S            ");
        Console.WriteLine("  E:::::E              U:::::D     D:::::U   R::::R     R:::::RO:::::O     O:::::O  B::::B     B:::::B  I::::I          Z:::::Z    N:::::::::::N   N::::::N  E:::::E             S:::::S            ");
        Console.WriteLine("  E::::::EEEEEEEEEE    U:::::D     D:::::U   R::::RRRRRR:::::R O:::::O     O:::::O  B::::BBBBBB:::::B   I::::I         Z:::::Z     N:::::::N::::N  N::::::N  E::::::EEEEEEEEEE    S::::SSSS         ");
        Console.WriteLine("  E:::::::::::::::E    U:::::D     D:::::U   R:::::::::::::RR  O:::::O     O:::::O  B:::::::::::::BB    I::::I        Z:::::Z      N::::::N N::::N N::::::N  E:::::::::::::::E     SS::::::SSSSS    ");
        Console.WriteLine("  E:::::::::::::::E    U:::::D     D:::::U   R::::RRRRRR:::::R O:::::O     O:::::O  B::::BBBBBB:::::B   I::::I       Z:::::Z       N::::::N  N::::N:::::::N  E:::::::::::::::E       SSS::::::::SS  ");
        Console.WriteLine("  E::::::EEEEEEEEEE    U:::::D     D:::::U   R::::R     R:::::RO:::::O     O:::::O  B::::B     B:::::B  I::::I      Z:::::Z        N::::::N   N:::::::::::N  E::::::EEEEEEEEEE          SSSSSS::::S ");
        Console.WriteLine("  E:::::E              U:::::D     D:::::U   R::::R     R:::::RO:::::O     O:::::O  B::::B     B:::::B  I::::I     Z:::::Z         N::::::N    N::::::::::N  E:::::E                         S:::::S");
        Console.WriteLine("  E:::::E       EEEEEE U::::::U   U::::::U   R::::R     R:::::RO::::::O   O::::::O  B::::B     B:::::B  I::::I  ZZZ:::::Z     ZZZZZN::::::N     N:::::::::N  E:::::E       EEEEEE            S:::::S");
        Console.WriteLine("EE::::::EEEEEEEE:::::E U:::::::UUU:::::::U RR:::::R     R:::::RO:::::::OOO:::::::OBB:::::BBBBBB::::::BII::::::IIZ::::::ZZZZZZZZ:::ZN::::::N      N::::::::NEE::::::EEEEEEEE:::::ESSSSSSS     S:::::S");
        Console.WriteLine("E::::::::::::::::::::E  UU:::::::::::::UU  R::::::R     R:::::R OO:::::::::::::OO B:::::::::::::::::B I::::::::IZ:::::::::::::::::ZN::::::N       N:::::::NE::::::::::::::::::::ES::::::SSSSSS:::::S");
        Console.WriteLine("E::::::::::::::::::::E    UU:::::::::UU    R::::::R     R:::::R   OO:::::::::OO   B::::::::::::::::B  I::::::::IZ:::::::::::::::::ZN::::::N        N::::::NE::::::::::::::::::::ES:::::::::::::::SS ");
        Console.WriteLine("EEEEEEEEEEEEEEEEEEEEEE      UUUUUUUUU      RRRRRRRR     RRRRRRR     OOOOOOOOO     BBBBBBBBBBBBBBBBB   IIIIIIIIIIZZZZZZZZZZZZZZZZZZZNNNNNNNN         NNNNNNNEEEEEEEEEEEEEEEEEEEEEE SSSSSSSSSSSSSSS   ");
        Console.WriteLine("                                                                                                                                                                                                    ");
        Console.WriteLine("                                                                                                                                                                                                    ");
        Console.WriteLine("                                                                                                                                                                                                    ");
        Console.WriteLine("                                                                                                                                                                                                    ");
        Console.WriteLine("                                                                                                                                                                                                    ");
        Console.WriteLine("                                                                               PODAJ LICZBĘ GRACZY (2-4)                                                                                            ");
        ConsoleKeyInfo decision = Console.ReadKey(true);
        while (decision.Key != ConsoleKey.D2 && decision.Key != ConsoleKey.D3 && decision.Key != ConsoleKey.D4)
            decision = Console.ReadKey(true);
        Game g;
        if (decision.Key == ConsoleKey.D2)
            g = new Game(2);
        else if (decision.Key == ConsoleKey.D3)
            g = new Game(3);
        else
            g = new Game(4);
        Console.Clear();
        char winner = g.RunGame();
        Console.Clear();
        Console.WriteLine("                                                                                                                                                                                                    ");
        Console.WriteLine("                                                                                                                                                                                                    ");
        Console.WriteLine("       KKKKKKKKK    KKKKKKK     OOOOOOOOO     NNNNNNNN        NNNNNNNNIIIIIIIIIIEEEEEEEEEEEEEEEEEEEEEE       CCCCCCCCCCCCC             GGGGGGGGGGGGGRRRRRRRRRRRRRRRRR   YYYYYYY       YYYYYYY       ");
        Console.WriteLine("       K:::::::K    K:::::K   OO:::::::::OO   N:::::::N       N::::::NI::::::::IE::::::::::::::::::::E    CCC::::::::::::C          GGG::::::::::::GR::::::::::::::::R  Y:::::Y       Y:::::Y       ");
        Console.WriteLine("       K:::::::K    K:::::K OO:::::::::::::OO N::::::::N      N::::::NI::::::::IE::::::::::::::::::::E  CC:::::::::::::::C        GG:::::::::::::::GR::::::RRRRRR:::::R Y:::::Y       Y:::::Y       ");
        Console.WriteLine("       K:::::::K   K::::::KO:::::::OOO:::::::ON:::::::::N     N::::::NII::::::IIEE::::::EEEEEEEEE::::E C:::::CCCCCCCC::::C       G:::::GGGGGGGG::::GRR:::::R     R:::::RY::::::Y     Y::::::Y       ");
        Console.WriteLine("       KK::::::K  K:::::KKKO::::::O   O::::::ON::::::::::N    N::::::N  I::::I    E:::::E       EEEEEEC:::::C       CCCCCC      G:::::G       GGGGGG  R::::R     R:::::RYYY:::::Y   Y:::::YYY       ");
        Console.WriteLine("       KK::::::K  K:::::KKKO::::::O   O::::::ON::::::::::N    N::::::N  I::::I    E:::::E       EEEEEEC:::::C       CCCCCC      G:::::G       GGGGGG  R::::R     R:::::RYYY:::::Y   Y:::::YYY       ");
        Console.WriteLine("       KK::::::K  K:::::KKKO::::::O   O::::::ON::::::::::N    N::::::N  I::::I    E:::::E       EEEEEEC:::::C       CCCCCC      G:::::G       GGGGGG  R::::R     R:::::RYYY:::::Y   Y:::::YYY       ");
        Console.WriteLine("         K:::::K K:::::K   O:::::O     O:::::ON:::::::::::N   N::::::N  I::::I    E:::::E            C:::::C                   G:::::G                R::::R     R:::::R   Y:::::Y Y:::::Y          ");
        Console.WriteLine("         K:::::K K:::::K   O:::::O     O:::::ON:::::::::::N   N::::::N  I::::I    E:::::E            C:::::C                   G:::::G                R::::R     R:::::R   Y:::::Y Y:::::Y          ");
        Console.WriteLine("         K::::::K:::::K    O:::::O     O:::::ON:::::::N::::N  N::::::N  I::::I    E::::::EEEEEEEEEE  C:::::C                   G:::::G                R::::RRRRRR:::::R     Y:::::Y:::::Y           ");
        Console.WriteLine("         K:::::::::::K     O:::::O     O:::::ON::::::N N::::N N::::::N  I::::I    E:::::::::::::::E  C:::::C                   G:::::G    GGGGGGGGGG  R:::::::::::::RR       Y:::::::::Y            ");
        Console.WriteLine("         K:::::::::::K     O:::::O     O:::::ON::::::N  N::::N:::::::N  I::::I    E:::::::::::::::E  C:::::C                   G:::::G    G::::::::G  R::::RRRRRR:::::R       Y:::::::Y             ");
        Console.WriteLine("         K::::::K:::::K    O:::::O     O:::::ON::::::N   N:::::::::::N  I::::I    E::::::EEEEEEEEEE  C:::::C                   G:::::G    GGGGG::::G  R::::R     R:::::R       Y:::::Y              ");
        Console.WriteLine("         K:::::K K:::::K   O:::::O     O:::::ON::::::N    N::::::::::N  I::::I    E:::::E            C:::::C                   G:::::G        G::::G  R::::R     R:::::R       Y:::::Y              ");
        Console.WriteLine("       KK::::::K  K:::::KKKO::::::O   O::::::ON::::::N     N:::::::::N  I::::I    E:::::E       EEEEEEC:::::C       CCCCCC      G:::::G       G::::G  R::::R     R:::::R       Y:::::Y              ");
        Console.WriteLine("       K:::::::K   K::::::KO:::::::OOO:::::::ON::::::N      N::::::::NII::::::IIEE::::::EEEEEEEE:::::E C:::::CCCCCCCC::::C       G:::::GGGGGGGG::::GRR:::::R     R:::::R       Y:::::Y              ");
        Console.WriteLine("       K:::::::K    K:::::K OO:::::::::::::OO N::::::N       N:::::::NI::::::::IE::::::::::::::::::::E  CC:::::::::::::::C        GG:::::::::::::::GR::::::R     R:::::R    YYYY:::::YYYY           ");
        Console.WriteLine("       K:::::::K    K:::::K   OO:::::::::OO   N::::::N        N::::::NI::::::::IE::::::::::::::::::::E    CCC::::::::::::C          GGG::::::GGG:::GR::::::R     R:::::R    Y:::::::::::Y           ");
        Console.WriteLine("       KKKKKKKKK    KKKKKKK     OOOOOOOOO     NNNNNNNN         NNNNNNNIIIIIIIIIIEEEEEEEEEEEEEEEEEEEEEE       CCCCCCCCCCCCC             GGGGGG   GGGGRRRRRRRR     RRRRRRR    YYYYYYYYYYYYY           ");
        Console.WriteLine("                                                                                                                                                                                                    ");
        Console.WriteLine("                                                                                                                                                                                                    ");
        if(winner != '?')
            Console.WriteLine("                                                                                      ZWYCIĘZCA: {0}                                                                                                  ", winner);
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("Naciśnij dowolny klawisz, aby wyjść.");
        Console.ReadKey(true);
    }
}
