namespace Notepad
{
    internal sealed class Program
    {
        private static void Main(string[] args)
        {
            Notepad notepad = new();
            do
            {
                ShowMenu();
                Console.WriteLine("Select an option:");
                string? input = Console.ReadLine();

                if (input == null)
                    continue;

                Console.WriteLine();
                switch (input)
                {
                    case "1":
                        notepad.CreateFile();
                        break;
                    case "2":
                        notepad.OpenFile();
                        break;
                    case "3":
                        notepad.SaveFile();
                        break;
                    case "4":
                        notepad.DeleteFile();
                        break;
                    case "5":
                        notepad.ShowContent();
                        break;
                    case "6":
                        ShowTextActions();
                        Console.WriteLine("Select a text action:");
                        string? textAction = Console.ReadLine();
                        if (textAction == null)
                        {
                            Console.WriteLine("Invalid action. Try again.");
                            continue;
                        }                           
                        notepad.DoTextAction(textAction);
                        break;
                    case "7":
                        ShowStatisticsActions();
                        Console.WriteLine("Select a statistics action:");
                        string? statAction = Console.ReadLine();
                        if (statAction == null)
                        {
                            Console.WriteLine("Invalid action. Try again.");
                            continue;
                        }
                        notepad.DoStatAction(statAction);
                        break;
                    case "8":
                        Console.WriteLine("Exiting Notepad...");
                        return;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }

                Console.WriteLine();
            } while (true);
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
}