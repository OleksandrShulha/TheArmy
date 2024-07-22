using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHero : MonoBehaviour
{
    [SerializeField] public GameObject enemy;

    void Start()
    {
        
    }


    void Update()
    {
        //Тест
        if (Input.GetKeyDown(KeyCode.A))
        {
            SpawnKnight1();
        }
    }

    public void SpawnKnight1()
    {
        GameObject inst = Instantiate(enemy, transform.position,Quaternion.identity) as GameObject;
    }
}
