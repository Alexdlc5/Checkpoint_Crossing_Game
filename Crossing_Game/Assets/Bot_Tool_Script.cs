using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Bot_Tool_Script : MonoBehaviour
{
    public float speed;
    private Transform t;
    // Start is called before the first frame update
    void Start()
    {
        t = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        float rotation_speed = speed * Time.deltaTime;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.RotateAround(transform.position, transform.TransformDirection(new Vector3(0, 0, 1)), rotation_speed);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.RotateAround(transform.position, transform.TransformDirection(new Vector3(0, 0, -1)), rotation_speed);
        }
    }
    
}
