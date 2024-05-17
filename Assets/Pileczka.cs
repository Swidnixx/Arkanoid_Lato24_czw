using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pileczka : MonoBehaviour
{
    public float speed = 7.5f;
    Rigidbody rb;

    Vector3 startPos;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPos = transform.position;
        BallReady();
    }

    public void BallReady()
    {
        transform.position = startPos;
        GetComponent<Renderer>().enabled = true;
    }

    public void StartBall()
    {
        Vector3 initVel = Vector2.zero;
        initVel.y = 1;
        initVel.x = 0;
        initVel = 
            Quaternion.AngleAxis(Random.Range(0, 2)==0?-30:30, 
            Vector3.forward) 
            * initVel;
        initVel.Normalize();
        Debug.Log(initVel.magnitude);
        rb.velocity = initVel * speed;
    }

    public void StopBall()
    {
        rb.velocity = Vector3.zero; 
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Dead"))
        {
            StopBall();
            GameManager.Instance.Dead();
        }
    }
}
