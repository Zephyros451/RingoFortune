using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class FallingObjectsManager : MonoBehaviour
{
    [SerializeField] FallingObject[] fallingObjects;

    private List<FallingObject> pool;

    private float leftCorner;
    private float rightCorner;
    private float cornerOffset;

    private void Start()
    {
        EventManager.GemCaught += ShrinkObject;
        EventManager.GobletCaught += ShrinkObject;
        EventManager.GameStarted += OnGameStarted;
        EventManager.YouLose += OnGameStopped;
        EventManager.YouWin += OnGameStopped;

        leftCorner = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).x;
        rightCorner = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x;
        cornerOffset = rightCorner * 0.25f;
        leftCorner += cornerOffset;
        rightCorner -= cornerOffset;
        
        Initialize();        
    }

    private void Update()
    {
        Pooling();
    }

    private void Pooling()
    {
        foreach(var obj in fallingObjects)
        {
            if (obj.transform.position.y < -12)
            {
                if (!pool.Contains(obj))
                {
                    obj.Reset();
                    pool.Add(obj);
                }
            }
        }
    }    

    private void Initialize()
    {
        pool = new List<FallingObject>(fallingObjects);
        foreach (var obj in fallingObjects)
        {
            obj.Initialize(leftCorner, rightCorner);
            obj.Reset();
        }
    }

    private IEnumerator Releasing()
    {
        while (true)
        {
            if (pool.Count > 0)
            {
                int randomIndex = Random.Range(0, pool.Count);
                pool[randomIndex].Release();
                pool.Remove(pool[randomIndex]);
            }
            yield return new WaitForSeconds(Random.Range(1, 2));
        }
    }

    private void ShrinkObject(FallingObject fallingObject)
    {
        foreach(var obj in fallingObjects)
        {
            if(obj == fallingObject)
            {
                obj.Shrink();
                pool.Add(obj);
            }
        }
    }

    private void OnGameStarted()
    {
        StartCoroutine(Releasing());
    }

    private void OnGameStopped()
    {
        StopAllCoroutines();
        Initialize();
    }
}
