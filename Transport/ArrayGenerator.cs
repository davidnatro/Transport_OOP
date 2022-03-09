using System;
using EKRLib;

namespace Transport
{
    /// <summary>
    /// Класс обладащюий функционалом для создания массива и заполнения его объектами.
    /// </summary>
    public class ArrayGenerator
    {
        private static Random random = new Random();

        internal EKRLib.Transport[] transports = new EKRLib.Transport[random.Next(6, 10)];

        /// <summary>
        /// Метод заполняющий массив - член класса.
        /// </summary>
        internal void FillArray()
        {
            for (int i = 0; i < transports.Length; i++)
            {
                if (transports[i] != null) continue;

                try
                {
                    uint randomPower = (uint)random.Next(10, 100);
                    string randomModel = GenerateModel();

                    // Заполняет массив объектами, имеющими шансы генерации 50% на 50%;
                    // PS На самом деле никакой криптостойкой генерации нет:)
                    transports[i] = random.Next(2) == 0 ? new Car(randomModel, randomPower) :
                        new MotorBoat(randomModel, randomPower);

                    Console.WriteLine(transports[i].StartEngine());
                }
                catch (TransportException ex)
                {
                    Console.WriteLine(ex.Message);
                    // При некорректно созданном транспорте цикл совершает ещё одну попытку.
                    i -= 1;
                }
            }
        }

        /// <summary>
        /// Генерация названия модели.
        /// </summary>
        /// <returns>Название модели.</returns>
        private string GenerateModel()
        {
            string result = string.Empty;

            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            for (int i = 0; i < 5; i++)
                result += alphabet[random.Next(alphabet.Length)];


            return result;
        }
    }
}
