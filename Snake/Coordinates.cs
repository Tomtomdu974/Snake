using System.Numerics;

public struct Coordinates
{
    public readonly int column;
    public readonly int row;

    public static Coordinates zero = new Coordinates (0, 0);
    public static Coordinates one = new Coordinates (1, 1);
    public static Coordinates up = new Coordinates(0, -1);
    public static Coordinates down = new Coordinates(0, 1);
    public static Coordinates left = new Coordinates(-1, 0);
    public static Coordinates right = new Coordinates(1, 0);

    public Vector2 ToVector()
    {
        return new Vector2(column, row);
    }
    
    public Coordinates(int column, int row)
    {
        this.column = column;
        this.row = row;
    }

    public static Coordinates operator +(Coordinates a, Coordinates b)
    {
        return new Coordinates(a.column + b.column, a.row + b.row);
    }

    public static Coordinates operator *(Coordinates a, int b)
    {
        return new Coordinates(a.column * b, a.row * b);
    }

     public static Coordinates operator *(int b, Coordinates a)
    {
        return new Coordinates(a.column * b, a.row * b);
    }

    public static Coordinates operator -(Coordinates a, Coordinates b)
    {
        return new Coordinates(a.column - b.column, a.row - b.row);
    }

    public static Coordinates operator -(Coordinates a)
    {
        return new Coordinates(-a.column , -a.row);
    }

    public static bool operator ==(Coordinates a, Coordinates b)
    {
        return a.column == b.column && a.row == b.row;
    }

    public static bool operator !=(Coordinates a, Coordinates b)
    {
        return !(a == b);
    }

    public override bool Equals(object? obj)
    {
        if (obj is Coordinates other)
        {
            return this == other;
        }
        return false;
    }
    public override string ToString()
    {
        return $"{column}, {row}";
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(column, row);
    }

    public static Coordinates Random(int maxColumn, int maxRow)
    {
        Random random = new Random();
        return new Coordinates(random.Next(maxColumn), random.Next(maxRow));
    }
}