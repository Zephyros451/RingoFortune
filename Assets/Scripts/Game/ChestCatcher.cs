using UnityEngine;

public class ChestCatcher : MonoBehaviour
{
    private string gem = "Gem";
    private string goblet = "Goblet";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag(gem))
        {
            EventManager.GemCaught?.Invoke(collision.GetComponent<FallingObject>());
            Debug.Log(gem);
        }

        if (collision.CompareTag(goblet))
        {
            EventManager.GobletCaught?.Invoke(collision.GetComponent<FallingObject>());
            Debug.Log(goblet);
        }
    }
}
