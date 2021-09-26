using UnityEngine;
using TMPro;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI score;

    private void Start()
    {
        EventManager.ScoreChanged += OnScoreChanged;
        EventManager.YouLose += Reset;
        EventManager.YouWin += Reset;
    }

    private void OnScoreChanged(int newScore)
    {
        score.text = newScore + "/10";
    }

    private void Reset()
    {
        score.text = "0/10";
    }
}
