using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

public class TimerSpin : MonoBehaviour
{
    [SerializeField] private float rotationDuration;
    [SerializeField] private int sectorsCount;
    [SerializeField] private RectTransform wheel;

    private float sectorAngle;
    private int randomSector;

    private void Start()
    {
        sectorAngle = 360f / (float)sectorsCount;
    }

    public void Spin()
    {
        randomSector = Mathf.RoundToInt(Random.Range(0f, sectorsCount-1));
        float randomAngle = randomSector * sectorAngle + 1350;
            
        var sequence = DOTween.Sequence();
        sequence.Append(
            wheel.DORotate(new Vector3(0f, 0f, -randomAngle), rotationDuration, RotateMode.FastBeyond360));
        sequence.AppendCallback(Evaluate);
    }

    private void Evaluate()
    {
        int time = 20 + randomSector * 10;
        EventManager.TimerSet?.Invoke(time);
        EventManager.GameStarted.Invoke();
    }
}