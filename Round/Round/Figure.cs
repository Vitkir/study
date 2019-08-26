namespace Round
{
    abstract public class Figure
    {
        abstract public Point Point { get; set; }
        abstract public double Area { get; }
        abstract public double Perimeter { get; }
    }
}
