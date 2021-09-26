using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestMovement : MonoBehaviour
{
    private float sensitivity = 5f;

    private void Update()
    {
        if(Input.GetMouseButton(0))
        {
            Vector3 newPosition = transform.position;
            newPosition.x = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
            transform.position = Vector3.Lerp(transform.position, newPosition, sensitivity * Time.deltaTime);
        }
    }
}
