using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Windows;


public class Move : MonoBehaviour
{
    [SerializeField] float speed = 2f;
    //private Rigidbody2D rb;
    [SerializeField] Transform target;





    void Start()
    {
        //rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(0,0,0), Time.deltaTime * speed);
        //transform.Translate( Vector3.right* speed * Time.deltaTime);
        //rb.velocity = transform.right * speed;

        //Debug.Log(rb.velocity);
        //transform.position = Vector3.Lerp(transform.position, new Vector3(0, 0, 0), speed*Time.deltaTime);


       
    }
    //private void FixedUpdate()
    //{
    //    Vector3 m_Input = new Vector3(0, 0, 0);
    //    rb.MovePosition(transform.position+ target.position *  speed);


    //}
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    Debug.Log(collision.collider.name);
    //}
}
