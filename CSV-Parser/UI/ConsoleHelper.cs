using Spectre.Console;
namespace CSV_Parser.UI;

public static class ConsoleHelper
{
     public static int MultipleChoice(bool canCancel, params string[] options)
    {
        const int startX = 45;
        const int startY = 5;
        const int optionsPerLine = 1;
        const int spacingPerLine = 14;
        var currentSelection = 0;
        Console.CursorVisible = false;
        ConsoleKey key;

        do 
        {
            Console.WriteLine();
            AnsiConsole.Write(new Calendar(DateTime.Now).AddCalendarEvent(DateTime.Today)
                .BorderColor(Color.DarkOliveGreen2));
            for (var optionCounter = 0; optionCounter < options.Length; optionCounter++)
            {
                
                Console.CursorVisible = false;
                Console.SetCursorPosition(startX + (optionCounter % optionsPerLine) * spacingPerLine, startY + optionCounter / optionsPerLine);
                if (optionCounter == currentSelection)
                    Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(options[optionCounter]);
                Console.ResetColor();
            }
            for (var optionCounter = 0; optionCounter < options.Length; optionCounter++)
            {
                Console.CursorVisible = false;
                Console.SetCursorPosition(startX + (optionCounter % optionsPerLine) * spacingPerLine, startY + optionCounter / optionsPerLine);
                if (optionCounter == currentSelection)
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write(options[optionCounter]);
                Console.ResetColor();
            }
            key = Console.ReadKey(true).Key;
            switch (key)
            {
                case ConsoleKey.LeftArrow:
                {
                    if (currentSelection % optionsPerLine > 0)
                        currentSelection--;
                    break;
                }
                case ConsoleKey.RightArrow:
                {
                    if (currentSelection % optionsPerLine < optionsPerLine - 1)
                        currentSelection++;
                    break;
                }
                case ConsoleKey.UpArrow:
                {
                    if (currentSelection >= optionsPerLine)
                        currentSelection -= optionsPerLine;
                    break;
                }
                case ConsoleKey.DownArrow:
                {
                    if (currentSelection + optionsPerLine < options.Length)
                        currentSelection += optionsPerLine;
                    break;
                }
                case ConsoleKey.Escape:
                {
                    if (canCancel)
                        return -1;
                    break;
                }
            }
            Console.Clear();
        } while (key != ConsoleKey.Enter);
        Console.CursorVisible = true;
        return currentSelection;
    }
}