using System;

namespace Transport
{
    class Program
    {

        /// <summary>
        /// Точка входа.
        /// </summary>
        /// <param name="args">Аргументы.</param>
        static void Main(string[] args)
        {
            do
            {
                FileWriter fileWriter = new FileWriter();
                fileWriter.WriteInFiles();

                Console.WriteLine($"\nНу что~ж.\n Если всё сделано правильно, то вот здесь {Environment.CurrentDirectory}\n" +
                    $"должны были быть сгенерированы 4 файла: Cars.txt и MotorBoats.txt;\n" +
                    $"А так же CarsUTF16.txt и MotorBoatsUTF16.txt;\n" +
                    $"Первые 2 были созданы для удобства чтения проверяющим:)\n" +
                    $"Проверь, пожалуйста! И если вдруг захочешь проделать это ещё раз ~~~ жми любую кнопку!\n" +
                    $"Так же можешь легко удалять файлы во время работы программы(она не упадет)!\n" +
                    $"А надоест и захочешь выйти? ESCAPE!\n");

            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}