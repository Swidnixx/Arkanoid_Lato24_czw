using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Klocek : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Ball"))
        {
            Destroy(gameObject);
        }
    }
}
