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
        //if (Input.GetKey(KeyCode.UpArrow))
        //{
        //    rotateToAngle(0, rotation_speed);
        //}
        //else if (Input.GetKey(KeyCode.DownArrow))
        //{
        //    rotateToAngle(180, rotation_speed);
        //}
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.RotateAround(transform.position, transform.TransformDirection(new Vector3(0, 0, 1)), rotation_speed);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.RotateAround(transform.position, transform.TransformDirection(new Vector3(0, 0, -1)), rotation_speed);
        }
    }
    //void rotateToAngle(float angle, float rotation_speed)
    //{
    //    float tolerance = 2;
    //    Vector3 direction;
    //    float high_point_distance = Vector3.Distance(transform.rotation.eulerAngles, new Vector3(0, 0, angle));
    //    if (high_point_distance > 180)
    //    {
    //       float temp = high_point_distance + transform.rotation.eulerAngles.z;
    //       high_point_distance = 360 - temp;
    //    }
    //    float low_point_distance = Vector3.Distance(new Vector3(0, 0, transform.rotation.eulerAngles.z - 1), new Vector3(0, 0, angle));
    //    if (low_point_distance > 180)
    //    {
    //        float temp = low_point_distance + transform.rotation.eulerAngles.z;
    //        low_point_distance = 360 - temp;
    //    }
    //    if (high_point_distance < low_point_distance)
    //    {
    //        direction = new Vector3(0, 0, 1);
    //    }
    //    else
    //    {
    //        direction = new Vector3(0, 0, -1);
    //    }
    //    //if near angle
    //    if (Vector3.Distance(transform.rotation.eulerAngles, new Vector3(0,0,angle)) > tolerance)
    //    {
    //        t.RotateAround(transform.position, direction, rotation_speed);
    //    }
    //}
}
