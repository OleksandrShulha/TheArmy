using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBaseToSide : MonoBehaviour
{
    [SerializeField] bool onRight = true;

    void Start()
    {
        MoveToSide();
    }

    private void MoveToSide()
    {
        float camHalfHeight = Camera.main.orthographicSize;

        float camHalfWidth = Camera.main.aspect * camHalfHeight;

        if(onRight)
            transform.position = new Vector3(camHalfWidth, 0, 0);
        else
            transform.position = new Vector3(-camHalfWidth, 0, 0);
    }


}
