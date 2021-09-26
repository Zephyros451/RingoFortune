using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int count = 0;

    private void Start()
    {
        EventManager.GemCaught += OnGemCaught;
        EventManager.GobletCaught += OnGobletCaught;
        EventManager.GameStarted += Reset;
    }

    private void Reset()
    {
        count = 0;
    }

    private void OnGemCaught(FallingObject obj)
    {
        count++;
        
        if (count > 9) 
        {
            Reset();
            EventManager.YouWin?.Invoke();
            return;
        }

        EventManager.ScoreChanged?.Invoke(count);
    }

    private void OnGobletCaught(FallingObject obj)
    {
        count--;
        if(count < 0)
        {
            Reset();
            EventManager.YouLose?.Invoke();
            return;
        }

        EventManager.ScoreChanged?.Invoke(count);
    }
}
