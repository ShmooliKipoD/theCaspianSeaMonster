
using theCaspianSeaMonster;

try
{
    using GameMain game = new();
        game.Run();
}
catch (Exception ex)
{
    Console.WriteLine($"{ex.Message} : \b {ex.StackTrace}");
}
