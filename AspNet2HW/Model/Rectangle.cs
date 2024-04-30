namespace AspNet2HW.Model
{
    public class Rectangle : Figure
    {
        public override double CalculateArea()
        {
            return Height * Width;
        }
    }
}
