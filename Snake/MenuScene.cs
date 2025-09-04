using Raylib_cs;


public class MenuScene : Scene
{
    public override void Load()
    {
        Console.WriteLine("Loading Menu Scene...");
    }

    public override void Update(float deltaTime)
    {
        if (Raylib.IsKeyPressed(KeyboardKey.Space))
        {
            ScenesManager.Load<GameScene>();
        }
    }

    public override void Draw()
    {
        Console.WriteLine("Drawing Menu Scene...");
    }

    public override void Unload()
    {
        Console.WriteLine("Unloading Menu Scene...");
    }
}