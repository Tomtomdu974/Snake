using System.Numerics;
using Raylib_cs;

public class Snake
{
    Grid<bool> grid;

    Queue<Coordinates> body = new Queue<Coordinates>();
    Coordinates direction = Coordinates.right;
    Coordinates nextDirection;

    public Coordinates head => body.Last();
    public double moveSpeed { get; private set; } = .5;
    private bool isGrowing = false;

    public Snake(Coordinates start, Grid<bool> grid, int startSize = 3)
    {
        this.grid = grid;

        for (int i = startSize - 1; i >= 0; i--)
        {
            body.Enqueue(start - direction * i);
        }

        nextDirection = direction;
    }

    public void Move()
    {
        direction = nextDirection;
        body.Enqueue(body.Last() + direction);
        if (!isGrowing) body.Dequeue();
        else isGrowing = false;
    }

    public void Draw()
    {
        foreach (var segment in body)
        {
            Vector2 position = grid.GridToWorld(segment);
            Raylib.DrawRectangle((int)position.X, (int)position.Y, grid.cellSize, grid.cellSize, Color.Green);
        }
    }

    public bool IsCollidingApple(Apple apple)
    {
        return head == apple.coordinates;
    }

    public bool IsCollidingWithSelf()
    {
        return body.Count != body.Distinct().Count(); // Check le nombre d'élément distinct et si aucun ne se touche c'est OK !
    }

    public bool IsOutOfBounds()
    {
        return head.column < 0 || head.column >= grid.columns || head.row < 0 || head.row >= grid.rows;
    }

    public void Grow()
    {
        isGrowing = true;
    }

    public void SpeedUp()
    {
        moveSpeed *= 0.9;
    }

    public void ChangeDirection(Coordinates newDirection)
    {
        if (newDirection == -direction) return; // Prevent reversing direction
        if (newDirection == Coordinates.zero) return; // Prevent no direction change
        nextDirection = newDirection;
    }
}