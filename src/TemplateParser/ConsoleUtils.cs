internal class ConsoleUtils
{
    public static void WriteLine(ConsoleColor? color, string format, params object[] args)
    {
        lock (Console.Out)
        {
            var foreground = Console.ForegroundColor;
            if (color != null)
            {
                Console.ForegroundColor = color.Value;
            }

            Console.WriteLine(format, args);
            Console.ForegroundColor = foreground;
        }
    }

    public static void WriteLine(ConsoleColor? color, string message)
    {
        lock (Console.Out)
        {
            var foreground = Console.ForegroundColor;
            if (color != null)
            {
                Console.ForegroundColor = color.Value;
            }

            Console.WriteLine(message);
            Console.ForegroundColor = foreground;
        }
    }
}
