using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class Claw_Controller : MonoBehaviour
{
    //public
    public GameObject top_claw;
    public GameObject bottom_claw;
    public Contact_Point[] contact_points;
    public float speed = 115;
    public float min = 270;
    public float max = 315;
    //private
    private Vector3 tc_starting_coords;
    private Vector3 bc_starting_coords;
    private bool clamped = false;

    GameObject contacted_cargo;
    private void Start()
    {
        contact_points = top_claw.GetComponentsInChildren<Contact_Point>().Concat(bottom_claw.GetComponentsInChildren<Contact_Point>()).ToArray();
        tc_starting_coords = top_claw.transform.localPosition;
        bc_starting_coords = bottom_claw.transform.localPosition;
    }
    // Update is called once per frame
    void Update()
    {
        int top_contacts = 0;
        int bottom_contacts = 0;
        //finds if contact points on bottom and top are contacting something
        foreach (Contact_Point contact_point in contact_points)
        {
            if (contact_point.contact)
            {
                if (contact_point.isTop)
                {
                    top_contacts++;
                }
                else
                {
                    bottom_contacts++;
                }
                //if so, stop movement of object
                if (top_contacts > 0 && bottom_contacts > 0)
                {
                    clamped = true;
                    contacted_cargo = contact_point.contacted_object;
                    contacted_cargo.transform.parent = transform;
                    contacted_cargo.GetComponent<Rigidbody2D>().velocity = transform.parent.parent.GetComponent<Rigidbody2D>().velocity;
                }
                else if (contacted_cargo != null) 
                {
                    contacted_cargo.transform.parent = null;
                }
            }
        }
        if (Input.GetKeyUp(KeyCode.Space) || clamped == false && contacted_cargo != false)
        {
            contacted_cargo.transform.parent = null;  
        }
        if (clamped & Input.GetKey(KeyCode.Space))
        {
            //reset clamp and reset claw
            clamped = false;
            if (Vector3.Distance(top_claw.transform.localRotation.eulerAngles, new Vector3(0, 0, min)) > 2)
            {
                top_claw.transform.RotateAround(transform.position, top_claw.transform.TransformDirection(new Vector3(0, 0, 1)), speed * Time.deltaTime);
                bottom_claw.transform.RotateAround(transform.position, bottom_claw.transform.TransformDirection(new Vector3(0, 0, -1)), speed * Time.deltaTime);
            }
        }
        //close claw
        if (Input.GetKey(KeyCode.Space) && Vector3.Distance(top_claw.transform.localRotation.eulerAngles, new Vector3(0, 0, max)) > 2)
        { 
            top_claw.transform.RotateAround(transform.position, top_claw.transform.TransformDirection(new Vector3(0, 0, -1)), speed * Time.deltaTime);
            bottom_claw.transform.RotateAround(transform.position, bottom_claw.transform.TransformDirection(new Vector3(0, 0, 1)), speed * Time.deltaTime);
        }
        //open claw
        else if (Vector3.Distance(top_claw.transform.localRotation.eulerAngles, new Vector3(0, 0, min)) > 2)
        {
            top_claw.transform.RotateAround(transform.position, top_claw.transform.TransformDirection(new Vector3(0, 0, 1)), speed * Time.deltaTime);
            bottom_claw.transform.RotateAround(transform.position, bottom_claw.transform.TransformDirection(new Vector3(0, 0, -1)), speed * Time.deltaTime);
        }
        //clamps position
        bottom_claw.transform.localPosition = bc_starting_coords;
        top_claw.transform.localPosition = tc_starting_coords;
    }

}
