using UnityEngine;
using TMPro;

public class TimerView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timer;

    private void Start()
    {
        EventManager.TimerSet += UpdateTimer;
        EventManager.TimerUpdate += UpdateTimer;
    }

    private void UpdateTimer(int newTime)
    {
        timer.text = newTime.ToString();

        if (newTime == 0)
        {
            EventManager.YouLose?.Invoke();
        }
    }
}
