using System.Threading.Channels;
using static System.Net.Mime.MediaTypeNames;

class Program
{
    public static void Main()
    {
        string sourceFile = @"Чтение и запись\Все пользователи.txt";
        string yandexFile = @"Чтение и запись\Пользователи с почтой yandex.txt";
        string mailFile = @"Чтение и запись\Пользователь с почтой mail.txt";
        string unrecognizedFile = @"\Чтение и запись\Нераспознанные.txt";
        string resultFile = @"Чтение и запись\Результат.txt";

        int countLinesYandex = 0;
        int countLinesMail = 0;
        int unrecognized = 0;
        try
        {
            string[] lines = File.ReadAllLines(sourceFile);

            foreach (var line in lines)
            {
                if (line.Contains("@yandex.ru"))
                {
                    File.AppendAllText(yandexFile, line + Environment.NewLine);
                    countLinesYandex++;
                }
                else if (line.Contains("@mail.ru"))
                {
                    File.AppendAllText(mailFile, line + Environment.NewLine);
                    countLinesMail++;
                }
                else if (line.Contains(".com"))
                {
                    File.AppendAllText(unrecognizedFile, line + Environment.NewLine);
                    unrecognized++;
                }
            }
            int countLines = countLinesYandex + countLinesMail + unrecognized;

            string result = $"Yandex: {countLinesYandex} \nMail: {countLinesMail} \nUnrecognized: {unrecognized} \nAll Emails: {countLines}";

            File.WriteAllText(resultFile, result);

            Console.WriteLine(result);

        }
        catch (Exception ex)
        {
            Console.WriteLine(@"[File not found!]", ex.Message);       
        }
    }
}
