using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    [SerializeField] float speed = 2f;

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
        if (!go || !isHaveTarget && !isFindTarget)
        {
            AnimationHero(1);
        }
        if (go || isFindTarget && !isHaveTarget)
        {
            AnimationHero(2);
        }
        if (!go && isHaveTarget && isHaveTarget)
        {
            AnimationHero(3);
        }
    }

    public void AnimationHero(int stateHero)
    {
        anim.SetInteger("State", stateHero);
    }

    public void FindTarget()
    {
        List<GameObject> enemyes = new List<GameObject>(GameObject.FindGameObjectsWithTag("Hero"));
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
        }

    }


    public void MoveToTarget()
    {
        if (go == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(0, transform.position.y, 0), Time.deltaTime * speed);
        }

        if (isFindTarget && !isHaveTarget)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * speed);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        go = false;
        isHaveTarget = true;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        isHaveTarget = false;
    }

}
