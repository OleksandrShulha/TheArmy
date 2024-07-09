using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundPosition : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float camHalfHeight = Camera.main.orthographicSize;
        float camHalfWidth = Camera.main.aspect * camHalfHeight;
        transform.position = new Vector3(-camHalfWidth, -camHalfHeight, 0);
    }


}
