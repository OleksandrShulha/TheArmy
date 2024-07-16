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

    private Vector3 targetToMoveBase;
    private Transform targetToMoveEnemy;
    private GameObject enemyBase;


    private Animator anim;


    void Start()
    {
        anim = GetComponent<Animator>();

        enemyBase = GameObject.FindGameObjectWithTag("EnemyBase");
        targetToMoveBase = new Vector3(enemyBase.transform.position.x, (Random.Range(-2.5f, 0.8f)), 0f);
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
            float dist = Vector3.Distance(targetToMoveEnemy.position, transform.position);
            if (dist < 0.5)
            {
                isHaveTarget = true;
            }
            else
            {
                isHaveTarget = false;
            }

        }
        if(!isFindTarget && enemyBase != null)
        {
            float dist = Vector3.Distance(targetToMoveBase, transform.position);
            if (dist < 1.5f)
            {
                isHaveTarget = true;
            }
            else
            {
                isHaveTarget = false;
            }
        }


        if(!isFindTarget && enemyBase == null)
        {
            isHaveTarget = false;
        }
    }

    public void AnimationHero()
    {
        if (hp <= 0)
        {
            //Dead
            anim.SetInteger("State", 4);
        }
        if (!go && hp >0)
        {
            //Idle
            anim.speed = 1F;
            anim.SetInteger("State", 1);
        }
        if(go && !isHaveTarget && hp >0)
        {
            //Move
            anim.speed = 1F;
            anim.SetInteger("State", 2);
        }
        if (go && isHaveTarget && hp > 0)
        {
            //Atack
            anim.speed = 1F;
            anim.SetInteger("State", 3);
        }
    }

    public void FindTargetEnemy()
    {
        List<GameObject> enemyes = new List<GameObject>(GameObject.FindGameObjectsWithTag("Enemies"));
        if (enemyes.Count > 0)
        {

            go = true;
            float curentDist = Vector3.Distance(enemyes[0].transform.position, transform.position);
            targetToMoveEnemy = enemyes[0].transform;
            foreach (GameObject enemy in enemyes)
            {
                float dist = Vector3.Distance(enemy.transform.position, transform.position);
                if (dist < curentDist)
                {
                    targetToMoveEnemy = enemy.transform;
                    curentDist = dist;
                }
            }
            isFindTarget = true;
        }
        else
        {
            enemyBase = GameObject.FindGameObjectWithTag("EnemyBase");
            isFindTarget = false;
            if(enemyBase != null)
            {
                go = true;
            }
            else
            {
                go = false;
            }
        }

    }


    public void MoveToTarget()
    {
        if (!isFindTarget && !isHaveTarget && enemyBase != null && hp>0)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetToMoveBase, Time.deltaTime * speed);
            if(transform.position.x > targetToMoveBase.x)
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);
            }
            else
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
        }

        if (isFindTarget && !isHaveTarget && hp > 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetToMoveEnemy.position, Time.deltaTime * speed);
            if (transform.position.x > targetToMoveEnemy.position.x)
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);
            }
            else
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
        }
    }
}


