namespace Notepad;

internal sealed class Notepad
{
    private string Content { get; set; } = string.Empty;
    private string FilePath { get; set; } = string.Empty;
    private readonly Dictionary<string, TextAction> _textAction = [];
    private readonly Dictionary<string, TextStatAction> _statAction = [];

    public Notepad()
    {
        _textAction.Add("Add Text", AddText);
        _textAction.Add("Remove Text", RemoveText);
        _textAction.Add("Replace Text", ReplaceText);

        _statAction.Add("Count Words", CountWords);
        _statAction.Add("Count Lines", CountLines);
        _statAction.Add("Count Characters", CountCharacters);
    }

    public void CreateFile()
    {
        Console.WriteLine("Enter file name:");
        string fileName = Console.ReadLine() ?? string.Empty;

        if (string.IsNullOrEmpty(fileName))
        {
            Console.WriteLine("File name cannot be empty.");
            return;
        }

        FilePath = Path.Combine(Environment.CurrentDirectory, fileName);

        if (File.Exists(FilePath))
        {
            Console.WriteLine("File already exists.");
            return;
        }

        using var fileStream = File.Create(FilePath);
        Console.WriteLine($"File {fileName} created.");
    }

    public void OpenFile()
    {
        Console.WriteLine("Enter file name:");
        string fileName = Console.ReadLine() ?? string.Empty;
        if (string.IsNullOrEmpty(fileName))
        {
            Console.WriteLine("File name cannot be empty.");
            return;
        }

        FilePath = Path.Combine(Environment.CurrentDirectory, fileName);

        if (!File.Exists(FilePath))
        {
            Console.WriteLine("File does not exist.");
            return;
        }

        Content = File.ReadAllText(FilePath);
        Console.WriteLine($"File {fileName} opened.");
    }

    public void SaveFile()
    {
        if (string.IsNullOrEmpty(FilePath))
        {
            Console.WriteLine("No file is open.");
            return;
        }
        File.WriteAllText(FilePath, Content);
        Console.WriteLine($"File {FilePath} saved.");
    }

    public void ShowContent()
    {
        if (string.IsNullOrEmpty(Content))
        {
            Console.WriteLine("No content to display.");
            return;
        }
        Console.WriteLine($"Content of {FilePath}:\n{Content}");
    }

    public void DeleteFile()
    {
        Console.WriteLine("Enter file name:");
        string fileName = Console.ReadLine() ?? string.Empty;
        if (string.IsNullOrEmpty(fileName))
        {
            Console.WriteLine("File name cannot be empty.");
            return;
        }
        FilePath = Path.Combine(Environment.CurrentDirectory, fileName);
        if (!File.Exists(FilePath))
        {
            Console.WriteLine("File does not exist.");
            return;
        }
        File.Delete(FilePath);
        Console.WriteLine($"File {fileName} deleted.");
    }

    public void DoTextAction(string actionName)
    {
        if (_textAction.ContainsKey(actionName))
        {
            Content = _textAction[actionName]();
            Console.WriteLine($"Text action {actionName} performed.");
        }
        else
        {
            Console.WriteLine($"Text action {actionName} not found.");
        }
    }

    public void DoStatAction(string actionName)
    {
        if (_statAction.ContainsKey(actionName))
        {
            int result = _statAction[actionName]();
            Console.WriteLine($"Stat action {actionName} performed. Result: {result}");
        }
        else
        {
            Console.WriteLine($"Stat action {actionName} not found.");
        }
    }

    private string AddText()
    {
        Console.WriteLine("Enter text to add:");
        string text = Console.ReadLine() ?? string.Empty;
        if (string.IsNullOrEmpty(text))
        {
            Console.WriteLine("Text to add cannot be empty.");
            return Content;
        }
        return Content + text;
    }

    private string RemoveText()
    {
        Console.WriteLine("Enter text to remove:");
        string text = Console.ReadLine() ?? string.Empty;

        if (string.IsNullOrEmpty(text))
        {
            Console.WriteLine("Text to remove cannot be empty.");
            return Content;
        }

        return Content.Replace(text, string.Empty);
    }

    private string ReplaceText()
    {
        Console.WriteLine("Enter text to replace:");

        string oldText = Console.ReadLine() ?? string.Empty;

        if (string.IsNullOrEmpty(oldText))
        {
            Console.WriteLine("Text to replace cannot be empty.");
            return Content;
        }

        Console.WriteLine("Enter new text:");

        string newText = Console.ReadLine() ?? string.Empty;

        if (string.IsNullOrEmpty(newText))
        {
            Console.WriteLine("New text cannot be empty.");
            return Content;
        }
        return Content.Replace(oldText, newText);
    }

    private int CountWords()
    {
        if (string.IsNullOrEmpty(Content))
        {
            Console.WriteLine("No content to count words.");
            return 0;
        }
        return Content.Split([' ', '\n'], StringSplitOptions.RemoveEmptyEntries).Length;
    }

    private int CountLines()
    {
        if (string.IsNullOrEmpty(Content))
        {
            Console.WriteLine("No content to count lines.");
            return 0;
        }
        return Content.Split('\n').Length;
    }

    private int CountCharacters()
    {
        if (string.IsNullOrEmpty(Content))
        {
            Console.WriteLine("No content to count characters.");
            return 0;
        }
        return Content.Length;
    }
}
