using lab15sem3;

public class FileObserver : IFileSystemObserver
{
    public void OnFileChanged(string filePath)
    {
        Console.WriteLine($"Файл изменен: {filePath}");
    }

    public void OnFileCreated(string filePath)
    {
        Console.WriteLine($"Файл создан: {filePath}");
    }

    public void OnFileDeleted(string filePath)
    {
        Console.WriteLine($"Файл удален: {filePath}");
    }
}
class Program
{
    static void Main()
    {
        var watcher = new SimpleFileSystemWatcher(@"C:/users/nikav", 1000);
        var observer = new FileObserver();

        watcher.Subscribe(observer);

        Console.WriteLine("Нажмите Enter для выхода...");
        Console.ReadLine();

        watcher.Unsubscribe(observer);
    }
}
