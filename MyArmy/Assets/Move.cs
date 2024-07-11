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

    private Transform target;

    Animator anim;




    void Start()
    {

        anim = GetComponent<Animator>();

    }

    void Update()
    {
        MoveToTarget();
        FindTarget();
        Atack();
        AnimationHero();
    }

    public void Atack()
    {
        if (isFindTarget)
        {
            float dist = Vector3.Distance(target.position, transform.position);
            if (dist < 0.5)
            {
                isHaveTarget = true;
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

    public void FindTarget()
    {
        List<GameObject> enemyes = new List<GameObject>(GameObject.FindGameObjectsWithTag("Enemies"));
        if (enemyes.Count > 0)
        {
            go = false;
            float curentDist = Vector3.Distance(enemyes[0].transform.position, transform.position);
            target = enemyes[0].transform;
            foreach (GameObject go in enemyes)
            {
                float dist = Vector3.Distance(go.transform.position, transform.position);
                if (dist < curentDist)
                {
                    target = go.transform;
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
        if (go == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(0,transform.position.y,0), Time.deltaTime * speed);
        }

        if (isFindTarget && !isHaveTarget)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * speed);
        }
    }
}


