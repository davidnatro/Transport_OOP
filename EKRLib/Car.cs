namespace EKRLib
{
    /// <summary>
    /// Класс машины.
    /// </summary>
    public class Car : Transport
    {
        public Car(string model, uint power) : base(model, power) { }

        /// <summary>
        /// Воспроизведение звука модели.
        /// </summary>
        /// <returns>Звук изданный моделью.</returns>
        public override string StartEngine() => $"{Model}: Vroom";

        public override string ToString() => $"Car. {base.ToString()}";
    }
}
