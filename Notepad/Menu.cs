namespace Notepad;

internal static class Menu
{
    private static readonly Notepad Notepad = new();

    public static void ControlMenu()
    {
        while (true)
        {
            ShowMenu();
            Console.WriteLine("Select an option:");
            string? input = Console.ReadLine();
            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("Invalid input. Please try again.");
                continue;
            }
            if (!int.TryParse(input, out int option) || option < 1 || option > 8)
            {
                Console.WriteLine("Invalid option. Please try again.");
                continue;
            }
            switch (option)
            {
                case 1:
                    Notepad.CreateFile();
                    break;
                case 2:
                    Notepad.OpenFile();
                    break;
                case 3:
                    Notepad.SaveFile();
                    break;
                case 4:
                    Notepad.DeleteFile();
                    break;
                case 5:
                    Notepad.ShowContent();
                    break;
                case 6:
                    ShowTextActions();
                    break;
                case 7:
                    ShowStatisticsActions();
                    break;
                case 8:
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }
    private static void ShowMenu()
    {
        Console.WriteLine("1. Create File");
        Console.WriteLine("2. Open File");
        Console.WriteLine("3. Save File");
        Console.WriteLine("4. Delete File");
        Console.WriteLine("5. Show Content");
        Console.WriteLine("6. Text Actions");
        Console.WriteLine("7. Statistics Actions");
        Console.WriteLine("8. Exit");
    }

    private static void ShowTextActions()
    {
        Console.WriteLine("Add Text");
        Console.WriteLine("Remove Text");
        Console.WriteLine("Replace Text");
    }

    private static void ShowStatisticsActions()
    {
        Console.WriteLine("Count Words");
        Console.WriteLine("Count Lines");
        Console.WriteLine("Count Characters");
    }
}
