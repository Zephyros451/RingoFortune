using System;

public static class EventManager
{
    public static Action GameStarted { get; set; }
    public static Action YouWin { get; set; }
    public static Action YouLose { get; set; }


    public static Action<int> ScoreChanged { get; set; }
    public static Action<int> TimerSet { get; set; }
    public static Action<int> TimerUpdate { get; set; }
    public static Action<FallingObject> GemCaught { get; set; }
    public static Action<FallingObject> GobletCaught { get; set; }
}
