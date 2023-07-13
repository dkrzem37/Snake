namespace Snake.Core;

public static class Program
{
    public static void Main(){
    using var game = new Snake.Core.Game1();
    game.Run();
    }
}
