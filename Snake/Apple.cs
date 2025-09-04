using System.Numerics;
using Raylib_cs;

public class Apple
{
    public Coordinates coordinates { get; private set; }
    private Grid<bool> grid;

    public Apple(Grid<bool> grid)
    {
        this.grid = grid;
        coordinates = Coordinates.Random(grid.columns, grid.rows);
    }

    public void Respawn()
    {
        coordinates = Coordinates.Random(grid.columns, grid.rows);
    }

    public void Draw()
    {
        Vector2 worldPosition = grid.GridToWorld(coordinates);
        worldPosition += new Vector2(grid.cellSize, grid.cellSize) * .5f;
        Raylib.DrawCircle((int)worldPosition.X, (int)worldPosition.Y, grid.cellSize * .5f, Color.Red);
    }
}