
using System;
using theCaspianSeaMonster;

try
{
    using Game1 game = new ();
    game.Run();
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
