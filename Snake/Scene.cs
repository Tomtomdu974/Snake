using System.Runtime;
using System.Runtime.CompilerServices;
using Raylib_cs;

public abstract class Scene
{
    public abstract void Load();
    public abstract void Update(float deltaTime);
    public abstract void Draw();
    public abstract void Unload();
}