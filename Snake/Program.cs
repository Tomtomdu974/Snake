using Raylib_cs;


Raylib.InitWindow(1600, 900, "Hello World");
Raylib.SetTargetFPS(60);

ScenesManager.Load<GameScene>();

while (!Raylib.WindowShouldClose())
{
    ScenesManager.Update(Raylib.GetFrameTime());

    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.Black);
     ScenesManager.Draw();

    Raylib.EndDrawing();
}

Raylib.CloseWindow();