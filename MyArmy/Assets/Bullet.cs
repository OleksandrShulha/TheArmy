using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] bool isPhysical;
    [SerializeField] float powerAtack;
    [SerializeField] GameObject targetToMoveEnemy;

    void Start()
    {
        
    }

    public void SettargetToMoveEnemy(GameObject value)
    {
        targetToMoveEnemy = value;
    }

    public void SetisPhysical(bool value)
    {
        isPhysical = value;
    }

    public void SetPowerAtack(float value)
    {
        powerAtack = value;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetToMoveEnemy.transform.position , Time.deltaTime * 1f);
    }
}
