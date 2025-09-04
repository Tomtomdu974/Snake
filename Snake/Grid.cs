using System.Numerics;
using Raylib_cs;

public class Grid<TCell>
{
    public readonly int columns;
    public readonly int rows;
    public readonly int cellSize;
    public readonly Vector2 origin;

    private TCell[,] cells;

    public Grid(int columns, int rows, int cellSize, Vector2 origin) // Constructeur
    {
        this.columns = columns;
        this.rows = rows;
        this.cellSize = cellSize;
        this.origin = origin;
        cells = new TCell[columns, rows];
    }

    public TCell? GetCell(Coordinates coordinates)
    {
        if (coordinates.column < 0 || coordinates.column >= columns)
        {
            throw new ArgumentOutOfRangeException(nameof(coordinates.column), "Column index is out of range.");
        }
        if (coordinates.row < 0 || coordinates.row >= rows)
        {
            throw new ArgumentOutOfRangeException(nameof(coordinates.row), "Row index is out of range.");
        }

        return cells[coordinates.column, coordinates.row];
    }

    public void SetCell(Coordinates coordinates, TCell value)
    {
        if (coordinates.column < 0 || coordinates.column >= columns)
        {
            throw new ArgumentOutOfRangeException(nameof(coordinates.column), "Column index is out of range.");
        }
        if (coordinates.row < 0 || coordinates.row >= rows)
        {
            throw new ArgumentOutOfRangeException(nameof(coordinates.row), "Row index is out of range.");
        }

        cells[coordinates.column, coordinates.row] = value;
    }

    public Vector2 GridToWorld(Coordinates coordinates)
    {
        coordinates *= cellSize;
        return coordinates.ToVector() + origin;
    }

    public Coordinates WorldToGrid(Vector2 position)
    {
        position -= origin;
        position /= cellSize;
        return new Coordinates((int)position.X, (int)position.Y);
    }

    public void Draw()
    {
        for (int column = 0; column < columns; column++)
        {
            for (int row = 0; row < rows; row++)
            {
                Vector2 cellPos = GridToWorld(new Coordinates(column, row));
                Raylib.DrawRectangleLines((int)cellPos.X, (int)cellPos.Y, cellSize, cellSize, Raylib_cs.Color.Black);
            }
        }
    }
}