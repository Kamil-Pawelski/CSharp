namespace Notepad;

internal interface IFiles
{
    void CreateFile(string fileName);
    void OpenFile(string fileName);
    void SaveFile();
    void DeleteFile(string fileName);
    void ShowContent();

    void SetContent(string content);
    string GetContent();
    string GetFilePath();
}
