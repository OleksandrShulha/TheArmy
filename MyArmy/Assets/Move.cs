using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;




public class Move : MonoBehaviour
{
    //Paladin Stats
    public float Speed { get; set; } = 2f;
    public float Hp { get; set; } = 1487f;
    public float MDef { get; set; } = 366f;
    public float PDef { get; set; } = 370f;
    public float PAtack { get; set; } = 320f;
    public float CritChanсe { get; set; } = 44f;
    public float AtackSpeed { get; set; } = 416f;
    [SerializeField] private bool isPhysical = true;


    public bool go = true;
    public bool isHaveTarget = false;
    public bool isFindTarget = false;

    private Vector3 targetToMoveBase;
    private Transform targetToMoveEnemy;
    private GameObject enemyBase;

    StatsLVL statsLVL;


    private Animator anim;


    //Завдання
    //Функція смерті
    //Створення пулі під час атаки
    //Залежність хотьби і атаки від статів
    //Бафи і апгрейди


    void Start()
    {
        anim = GetComponent<Animator>();
        statsLVL = FindAnyObjectByType<StatsLVL>();
        enemyBase = GameObject.FindGameObjectWithTag("EnemyBase");

        //Target point on base to move
        targetToMoveBase = new Vector3(enemyBase.transform.position.x, (Random.Range(-2.5f, 0.8f)), 0f);

        LoadStats();
    }

    void Update()
    {
        if(Hp > 0)
        {
            MoveToTarget();
            FindTargetEnemy();
            Atack();
        }

        AnimationHero();

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Hp += 200;
            Debug.Log(Hp);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            Hp -= 1000;
            Debug.Log(Hp);
        }


    }

    public void LoadStats()
    {

        Hp = Hp * Mathf.Pow(1.0347f, statsLVL.HpLVL-1);
        MDef = MDef * Mathf.Pow(1.0223f, statsLVL.MDefLVL - 1);
        PDef = PDef * Mathf.Pow(1.0301f, statsLVL.PDefLVL - 1);
        PAtack = PAtack * Mathf.Pow(1.0189f, statsLVL.PAtackLVL - 1);
        Debug.Log("hp = " + Hp);
        Debug.Log("mDef = " + MDef);
        Debug.Log("pDef = " + PDef);
        Debug.Log("pAtack = " + PAtack);
        Debug.Log("speed = " + Speed);
        Debug.Log("сritChanсe = " + CritChanсe);
        Debug.Log("atackSpeed = " + AtackSpeed);
        
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
        if (Hp <= 0)
        {
            //Dead
            anim.SetInteger("State", 4);
        }
        if (!go && Hp >0)
        {
            //Idle
            anim.speed = 1F;
            anim.SetInteger("State", 1);
        }
        if(go && !isHaveTarget && Hp >0)
        {
            //Move
            anim.speed = 1F;
            anim.SetInteger("State", 2);
        }
        if (go && isHaveTarget && Hp > 0)
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
        if (!isFindTarget && !isHaveTarget && enemyBase != null && Hp>0)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetToMoveBase, Time.deltaTime * Speed);
            if(transform.position.x > targetToMoveBase.x)
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);
            }
            else
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
        }

        if (isFindTarget && !isHaveTarget && Hp > 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetToMoveEnemy.position, Time.deltaTime * Speed);
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


