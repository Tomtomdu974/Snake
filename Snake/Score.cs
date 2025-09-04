using Raylib_cs;

public class Score
{
    private int score = 0;

    public Score()
    {

    }
    public void ScoreUp(Apple apple, Snake snake)
    {
        if (IsCollidingApple(apple, snake))
        {
            score++;
        }

    }
    private bool IsCollidingApple(Apple apple, Snake snake)
    {
        return true;
    }
    public void Draw()
    {
        Raylib.DrawText($"Score: {score}", 10, 10, 20, Color.White);
    }
}
