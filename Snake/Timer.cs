using System.Diagnostics;

public class Timer
{
    private float elapsedTime = 0f;
    public float duration { get; private set; }
    public bool isLooping;
    public bool isRunning { get; private set; }

    public Action? Callback { private get; set; }

    public Timer(float duration, Action? callback = null, bool isLooping = true)
    {
        this.duration = duration;
        this.isLooping = isLooping;
        this.Callback = callback;
        elapsedTime = 0f;
        isRunning = true;
    }

    public void Update(float deltaTime)
    {
        if (!isRunning) return;
        elapsedTime += deltaTime;

        if (elapsedTime >= duration)
        {
            Callback?.Invoke();
            if (isLooping)
                elapsedTime = 0f;
            else
                Stop();
        }
    }

    public void Start()
    {
        elapsedTime = 0f;
        isRunning = true;
    }

    public void Pause()
    {
        isRunning = false;
    }

    public void Stop()
    {
        isRunning = false;
    }

    public void Reset()
    {
        elapsedTime = 0f;
    }

    public void SetDuration(float newDuration)
    {
        duration = newDuration;
    }

    public bool isFinished()
    {
        return elapsedTime >= duration;
    }
}