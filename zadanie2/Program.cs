using zadanie2;

class Program
{
    static void Main()
    {
        // Запись в текстовый файл
        ILoggerRepository textLogger = new TextFileLoggerRepository("log.txt");
        MyLogger logger1 = new MyLogger(textLogger);
        logger1.Log("Это сообщение для текстового файла.");

        // Запись в JSON-файл
        ILoggerRepository jsonLogger = new JsonFileLoggerRepository("log.json");
        MyLogger logger2 = new MyLogger(jsonLogger);
        logger2.Log("Это сообщение для JSON-файла.");

        Console.WriteLine("Логи записаны. Нажмите Enter для выхода...");
        Console.ReadLine();
    }
}