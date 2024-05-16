using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pileczka : MonoBehaviour
{
    public float speed = 7.5f;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Vector3 initVel = Random.insideUnitCircle;
        initVel.y = Mathf.Abs(initVel.y);
        initVel.x = Mathf.Clamp(initVel.x, -0.3f, 0.3f);
        initVel.Normalize();
        Debug.Log(initVel.magnitude);
        rb.velocity = initVel * speed;
    }
}
