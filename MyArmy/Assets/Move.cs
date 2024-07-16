using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Windows;



public class Move : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private float hp = 200f;

    public bool go = true;
    public bool isHaveTarget = false;
    public bool isFindTarget = false;

    private Vector3 targetPointToMove;

    private Transform targetToMove;
    private Transform targetToBaseMove;

    private Animator anim;




    void Start()
    {

        anim = GetComponent<Animator>();

        GameObject enemyBase = GameObject.FindGameObjectWithTag("EnemyBase");
        targetPointToMove = new Vector3(enemyBase.transform.position.x, (Random.Range(-2.5f, 0.8f)), 0f);
    }

    void Update()
    {
        MoveToTarget();
        FindTargetEnemy();
        Atack();
        AnimationHero();
    }

    public void Atack()
    {
        if (isFindTarget)
        {
            float dist = Vector3.Distance(targetToMove.position, transform.position);
            if (dist < 0.5)
            {
                isHaveTarget = true;
                go = false;
            }
            else
            {
                isHaveTarget = false;
            }
        }
    }

    public void AnimationHero()
    {
        if (!go || !isHaveTarget && !isFindTarget && hp>0)
        {
            anim.speed = 1F;
            anim.SetInteger("State", 1);
        }
        if (go || isFindTarget && !isHaveTarget && hp > 0)
        {
            anim.speed = 1F;
            anim.SetInteger("State", 2);
        }
        if (!go && isHaveTarget && isFindTarget && hp > 0)
        {
            anim.speed = 1F;
            anim.SetInteger("State", 3);
        }
        if (hp <= 0)
        {
            anim.SetInteger("State", 4);
        }
    }

    public void FindTargetEnemy()
    {
        List<GameObject> enemyes = new List<GameObject>(GameObject.FindGameObjectsWithTag("Enemies"));
        if (enemyes.Count > 0)
        {
            float curentDist = Vector3.Distance(enemyes[0].transform.position, transform.position);
            targetToMove = enemyes[0].transform;
            foreach (GameObject enemy in enemyes)
            {
                float dist = Vector3.Distance(enemy.transform.position, transform.position);
                if (dist < curentDist)
                {
                    targetToMove = enemy.transform;
                    curentDist = dist;
                }
            }
            isFindTarget = true;
        }
        else
        {
            isFindTarget = false;
            isHaveTarget = false;
        }

    }


    public void MoveToTarget()
    {
        if (!isFindTarget && !isHaveTarget)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPointToMove, Time.deltaTime * speed);
        }

        if (isFindTarget && !isHaveTarget)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetToMove.position, Time.deltaTime * speed);
        }





        //if (go)
        //{
        //    transform.position = Vector3.MoveTowards(transform.position, targetToMove.position, Time.deltaTime * speed);
        //}

        //if(!go && !isFindTarget)
        //{
        //    GameObject enemyBase = GameObject.FindGameObjectWithTag("EnemyBase");
        //    transform.position = Vector3.MoveTowards(transform.position, enemyBase.transform.position, Time.deltaTime * speed);
        //}
        
    }
}


