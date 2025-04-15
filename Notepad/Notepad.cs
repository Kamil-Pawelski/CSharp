using Notepad.Files;

namespace Notepad;

internal sealed class Notepad
{
    private readonly IFiles _fileHandler = new TxtFile();

    private readonly Dictionary<string, Func<string>> _textActions;
    private readonly Dictionary<string, Func<int>> _statActions;

    public Notepad()
    {
        _textActions = new()
        {
            { "Add Text", AddText },
            { "Remove Text", RemoveText },
            { "Replace Text", ReplaceText }
        };

        _statActions = new()
        {
            { "Count Words", CountWords },
            { "Count Lines", CountLines },
            { "Count Characters", CountCharacters }
        };
    }

    public void CreateFile()
    {
        string name = Prompt("Enter file name:");
        _fileHandler.CreateFile(name);
    }

    public void OpenFile()
    {
        string name = Prompt("Enter file name:");
        _fileHandler.OpenFile(name);
    }

    public void SaveFile()
    {
        _fileHandler.SaveFile();
    }

    public void DeleteFile()
    {
        string name = Prompt("Enter file name:");
        _fileHandler.DeleteFile(name);
    }

    public void ShowContent()
    {
        _fileHandler.ShowContent();
    }

    public void DoTextAction(string actionName)
    {
        if (_textActions.TryGetValue(actionName, out var action))
        {
            _fileHandler.SetContent(action());
            Console.WriteLine($"Text action '{actionName}' performed.");
        }
        else
        {
            Console.WriteLine($"Unknown text action: '{actionName}'.");
        }
    }

    public void DoStatAction(string actionName)
    {
        if (_statActions.TryGetValue(actionName, out var action))
        {
            int result = action();
            Console.WriteLine($"Stat action '{actionName}' result: {result}");
        }
        else
        {
            Console.WriteLine($"Unknown stat action: '{actionName}'.");
        }
    }

    private string AddText()
    {
        string text = Prompt("Enter text to add:");
        return _fileHandler.GetContent() + text;
    }

    private string RemoveText()
    {
        string text = Prompt("Enter text to remove:");
        return _fileHandler.GetContent().Replace(text, string.Empty);
    }

    private string ReplaceText()
    {
        string oldText = Prompt("Enter text to replace:");
        string newText = Prompt("Enter new text:");
        return _fileHandler.GetContent().Replace(oldText, newText);
    }

    private int CountWords() =>
        _fileHandler.GetContent().Split(new[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).Length;

    private int CountLines() =>
        _fileHandler.GetContent().Split(new[] { '\n' }, StringSplitOptions.None).Length;

    private int CountCharacters() => _fileHandler.GetContent().Length;

    private string Prompt(string message)
    {
        Console.WriteLine(message);
        return Console.ReadLine()?.Trim() ?? string.Empty;
    }
}
