namespace EKRLib
{
    /// <summary>
    /// Абстрактный класс транспорта.
    /// </summary>
    public abstract class Transport
    {
        /// <summary>
        /// Название модели.
        /// </summary>
        private string model;
        public string Model
        {
            get => model;
            set => model = IsModelCorrect(value) ? value : throw new TransportException($"Недопустмиая модель: {value}");
        }

        /// <summary>
        /// Лошадиные силы.
        /// </summary>
        private uint power;
        public uint Power
        {
            get => power;
            set => power = value >= 20 ? value : throw new TransportException("Мощность не может быть меньше 20 л.с.");
        }

        public Transport(string model, uint power)
        {
            Model = model;
            Power = power;
        }

        /// <summary>
        /// Предусмотрена последующая реализация.
        /// </summary>
        /// <returns>Звук транспортного средства.</returns>
        public abstract string StartEngine();

        /// <summary>
        /// Проверка названия модели.
        /// </summary>
        /// <param name="model">Название модели.</param>
        /// <returns>Верно ли название.</returns>
        private bool IsModelCorrect(string model)
        {
            foreach (char letter in model)
            {
                if (!((letter >= 'A' && letter <= 'Z') || int.TryParse(letter.ToString(), out int x)))
                {
                    return false;
                }
            }

            return model.Length == 5;
        }

        public override string ToString()
        {
            return $"Model: {Model}, Power: {Power}";
        }
    }
}
