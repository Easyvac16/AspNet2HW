
namespace AspNet2HW.Model
{
    public abstract class Figure
    {
        public double Width { get; set; }
        public double Height { get; set; }
        public abstract double CalculateArea();
        public override string ToString()
        {
            return $"Widht:{Width} Height:{Height}";
        }
    }
}
