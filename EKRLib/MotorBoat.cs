namespace EKRLib
{
    /// <summary>
    /// Класс судна.
    /// </summary>
    public class MotorBoat : Transport
    {
        public MotorBoat(string model, uint power) : base(model, power) { }

        /// <summary>
        /// Воспроизведение звука модели.
        /// </summary>
        /// <returns>Звук изданный моделью.</returns>
        public override string StartEngine() => $"{Model}: Brrrbrr";

        public override string ToString() => $"MotorBoat. {base.ToString()}";
    }
}
