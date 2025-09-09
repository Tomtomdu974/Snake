using System.Numerics;
using Raylib_cs;

public class Snake_2
{
    Grid<bool> grid;

    public Queue<Coordinates> body = new Queue<Coordinates>();
    Coordinates direction = Coordinates.right;
    Coordinates nextDirection;

    public Coordinates head => body.Last();
    public double moveSpeed { get; private set; } = .5;
    private bool isGrowing = false;
    private int moveCounter = 0;
    private Random random = new Random();

    public Snake_2(Coordinates start, Grid<bool> grid, int startSize = 5)
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
        Coordinates nextHead = body.Last() + direction;

        if (nextHead.column < 0 || nextHead.column >= grid.columns)
        {
            nextDirection = new Coordinates(-direction.column, direction.row);
            nextHead = body.Last() + nextDirection;
        }

        if (nextHead.row < 0 || nextHead.row >= grid.rows)
        {
            nextDirection = new Coordinates(direction.column, -direction.row);
            nextHead = body.Last() + nextDirection;
        }

        direction = nextDirection;

        body.Enqueue(body.Last() + direction);
        if (!isGrowing) body.Dequeue();
        else isGrowing = false;

        moveCounter++;
        if (moveCounter % 6 == 0)
        {
            ChangeDirection(GetRandomDirection());
        }
    }


    public void Draw()
    {
        foreach (var segment in body)
        {
            Vector2 position = grid.GridToWorld(segment);
            Raylib.DrawRectangle((int)position.X, (int)position.Y, grid.cellSize, grid.cellSize, Color.Yellow);
        }
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

    public Coordinates GetRandomDirection()
    {
        Coordinates[] directions = new[] { Coordinates.up, Coordinates.down, Coordinates.left, Coordinates.right };
        Coordinates[] validDirections = directions.Where(d => d != -direction).ToArray();
        return validDirections[random.Next(validDirections.Length)];
    }

    public void SpawnSnake()
    {
        
    }
}