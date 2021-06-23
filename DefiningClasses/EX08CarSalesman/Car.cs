using System.Text;

namespace EX08CarSalesman
{
    public class Car
    {
        public string Model { get; set; }

        public Engine Engine { get; set; }

        public int Weight { get; set; }

        public string Color { get; set; }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine($"{Model}:");
            result.AppendLine($"  {Engine.Model}:");
            result.AppendLine($"    Power: {Engine.Power}");

            result.AppendLine(Engine.Displacement == 0
                ? $"    Displacement: n/a"
                : $"    Displacement: {Engine.Displacement}");

            result.AppendLine(Engine.Efficiency == null
                ? $"    Efficiency: n/a"
                : $"    Efficiency: {Engine.Efficiency}");

            result.AppendLine(Weight == 0
                ? $"  Weight: n/a"
                : $"  Weight: {Weight}");

            result.Append(Color == null
                ? $"  Color: n/a"
                : $"  Color: {Color}");

            return result.ToString();
        }
    }
}
