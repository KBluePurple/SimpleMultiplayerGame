using System;

public static class MainThread
{
    public static void Invoke(Action action)
    {
        MonoEventManager.QueueAction(action);
    }
}