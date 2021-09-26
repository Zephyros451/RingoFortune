using UnityEngine;

public class Timer : MonoBehaviour
{
    private float floatTime;
    private int time;
    private bool isCounting = false;

    private void Start()
    {
        EventManager.GameStarted += StartCounting;
        EventManager.YouLose += StopCounting;
        EventManager.YouWin += StopCounting;
        EventManager.TimerSet += SetTime;
    }

    private void Update()
    {
        if (isCounting)
        {
            floatTime -= Time.deltaTime;

            if (floatTime < time)
            {                
                EventManager.TimerUpdate?.Invoke(time);
                time--;                
            }
        }
    }

    private void SetTime(int newTime)
    {
        floatTime = newTime;
        time = newTime;
    }

    private void StartCounting()
    {
        isCounting = true;

    }

    private void StopCounting()
    {
        isCounting = false;
    }
}
