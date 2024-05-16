using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paletka : MonoBehaviour
{
    public float speed = 1;
    public float maxPosX = 5;

    private void Update()
    {
        if(Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += 
                Vector3.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += 
                Vector3.left * speed * Time.deltaTime;
        }

        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -maxPosX, maxPosX);
        transform.position = pos;
    }
}
