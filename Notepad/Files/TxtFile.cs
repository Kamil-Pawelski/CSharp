namespace Notepad.Files;

public class TxtFile : IFiles
{
    private string _filePath = string.Empty;
    private string _content = string.Empty;

    public void CreateFile(string fileName)
    {
        _filePath = Path.Combine(Environment.CurrentDirectory, fileName);

        if (File.Exists(_filePath))
        {
            Console.WriteLine("File already exists.");
            return;
        }

        File.WriteAllText(_filePath, string.Empty);
        Console.WriteLine($"File '{fileName}' created.");
    }

    public void OpenFile(string fileName)
    {
        _filePath = Path.Combine(Environment.CurrentDirectory, fileName);

        if (!File.Exists(_filePath))
        {
            Console.WriteLine("File does not exist.");
            return;
        }

        _content = File.ReadAllText(_filePath);
        Console.WriteLine($"File '{fileName}' opened.");
    }

    public void SaveFile()
    {
        if (string.IsNullOrEmpty(_filePath))
        {
            Console.WriteLine("No file is currently open.");
            return;
        }

        File.WriteAllText(_filePath, _content);
        Console.WriteLine($"File '{_filePath}' saved.");
    }

    public void DeleteFile(string fileName)
    {
        var path = Path.Combine(Environment.CurrentDirectory, fileName);

        if (!File.Exists(path))
        {
            Console.WriteLine("File does not exist.");
            return;
        }

        File.Delete(path);
        Console.WriteLine($"File '{fileName}' deleted.");
    }

    public void ShowContent()
    {
        if (string.IsNullOrEmpty(_content))
        {
            Console.WriteLine("No content to display.");
            return;
        }

        Console.WriteLine($"\n--- Content of '{_filePath}' ---\n{_content}\n-------------------------------");
    }

    public void SetContent(string content) => _content = content;
    public string GetContent() => _content;
    public string GetFilePath() => _filePath;
}
