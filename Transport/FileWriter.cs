using System;
using System.IO;
using System.Text;
using System.Linq;
using EKRLib;

namespace Transport
{
    /// <summary>
    /// Класс обладающий функционалом для записи в файлы.
    /// </summary>
    public class FileWriter
    {
        private readonly ArrayGenerator arrayGenerator = new ArrayGenerator();

        private readonly string carsPath = "Cars.txt";
        private readonly string motorBoatsPath = "MotorBoats.txt";

        /// <summary>
        /// Записывает транспорт из массива в ArrayGenerator в файлы Cars и MotoBoats; выбирает нужный файл
        /// и переводит строку для записи в кодировку UTF-16.
        /// </summary>
        internal void WriteInFiles()
        {
            arrayGenerator.FillArray();

            SetSolutionDirectory(Environment.CurrentDirectory);

            foreach (var transport in arrayGenerator.transports)
            {
                try
                {
                    if (transport is Car)
                    {
                        File.AppendAllText(carsPath, transport.ToString() + "\n", Encoding.Unicode);
                        File.AppendAllText("CarsUTF16.txt",
                            WriteFilesInUTF16(transport.ToString()) + "\n", Encoding.Unicode);
                    }
                    else
                    {
                        File.AppendAllText(motorBoatsPath, transport.ToString() + "\n", Encoding.Unicode);
                        File.AppendAllText("MotorBoatsUTF16.txt",
                            WriteFilesInUTF16(transport.ToString()) + "\n", Encoding.Unicode);
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Неопознанная ошибка!");
                }
            }
        }

        /// <summary>
        /// Переводит строку из UTF-8 в UTF-16.
        /// </summary>
        /// <param name="input">Строка UTF-8.</param>
        /// <returns>Строка UTF-16.</returns>
        private string WriteFilesInUTF16(string input)
        {
            string result = string.Empty;

            Encoding utf8 = Encoding.UTF8;
            Encoding unicode = Encoding.Unicode;

            byte[] utf8Bytes = utf8.GetBytes(input);

            byte[] unicodeBytes = Encoding.Convert(utf8, unicode, utf8Bytes);

            for (int i = 0; i < unicodeBytes.Length; i++)
            {
                result += unicodeBytes[i] + " ";
            }

            return result;
        }

        /// <summary>
        /// Ищет файл с решением и устанавливает путь до него текущей директорией.
        /// </summary>
        /// <param name="currentPath">Текущая директория.</param>
        private void SetSolutionDirectory(string currentPath = null)
        {
            try
            {
                var directory = new DirectoryInfo(currentPath ?? Directory.GetCurrentDirectory());

                while (directory != null && !directory.GetFiles("*.sln").Any())
                {
                    directory = directory.Parent;
                    if (directory == null) { Console.WriteLine("Не прячь файл с решением!"); return; }
                }

                Directory.SetCurrentDirectory(directory.ToString());
            }
            catch (Exception)
            {
                Console.WriteLine("Не прячь файл решения!");
            }
        }
    }
}
