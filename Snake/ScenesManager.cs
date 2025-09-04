// "?" veut dire qu'on est pas oblig" de faire un "if" pour la condition.

public static class ScenesManager
{
    private static Scene? currentScene;

    public static void Load<TScene>() where TScene : Scene, new()
    {
        currentScene?.Unload();
        currentScene = new TScene();
        currentScene.Load();
    }

    public static void Update(float deltaTime)
    {
        currentScene?.Update(deltaTime);
    }

    public static void Draw()
    {
        currentScene?.Draw();
    }
}