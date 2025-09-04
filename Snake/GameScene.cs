using Raylib_cs;

public class GameScene : Scene
{

    private Grid<bool> grid;
    private Snake snake;
    private Apple apple;

    private Timer moveTimer;
    private Score score;
    private Snake_2 snake_2;

    public GameScene()
    {
        int cellSize = 32;
        grid = new Grid<bool>(Raylib.GetScreenWidth() / cellSize, Raylib.GetScreenHeight() / cellSize, cellSize, new System.Numerics.Vector2(0, 0));
        snake = new Snake(new Coordinates(5, 5), grid);
        apple = new Apple(grid);
        moveTimer = new Timer((float)snake.moveSpeed, OnMoveTimerTriggered);
        score = new Score();
        snake_2 = new Snake_2(new Coordinates(), grid);
    }

    public override void Load()
    {
        Console.WriteLine("Loading Game !");
    }

    public void OnMoveTimerTriggered()
    {
        snake.Move();
        snake_2.Move();

        if (snake.IsCollidingWithSelf() || snake.IsOutOfBounds())
        {
            Console.WriteLine("GAME OVER !");
        }

        if (snake.IsCollidingApple(apple))
        {
            Console.WriteLine("Ate apple !");
            apple.Respawn();
            snake.Grow();
            snake.SpeedUp();
            score.ScoreUp(apple, snake);
            // GameController.AddScore(1000);
        }
    }

    public override void Update(float deltaTime)
    {
        moveTimer.Update(deltaTime);


        snake.ChangeDirection(GetInputDirection());
    }

    public override void Draw()
    {
        grid.Draw();
        snake.Draw();
        apple.Draw();
        score.Draw();
        snake_2.Draw();
    }

    public override void Unload()
    {
        Console.WriteLine("Unloading Game !");
    }

    private Coordinates GetInputDirection()
    {
        Coordinates dir = Coordinates.zero;
        if (Raylib.IsKeyDown(KeyboardKey.W)) dir = Coordinates.up;
        if (Raylib.IsKeyDown(KeyboardKey.S)) dir = Coordinates.down;
        if (Raylib.IsKeyDown(KeyboardKey.A)) dir = Coordinates.left;
        if (Raylib.IsKeyDown(KeyboardKey.D)) dir = Coordinates.right;

        return dir;
    }
}