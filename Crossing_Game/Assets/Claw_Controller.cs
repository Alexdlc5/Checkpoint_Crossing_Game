using UnityEngine;

public class Claw_Controller : MonoBehaviour
{
    public GameObject top_claw;
    public GameObject bottom_claw;
    public float speed = 115;
    public float min = 270;
    public float max = 315;
    private Vector3 tc_starting_coords;
    private Vector3 bc_starting_coords;

    private void Start()
    {
        tc_starting_coords = top_claw.transform.localPosition;
        bc_starting_coords = bottom_claw.transform.localPosition;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && Vector3.Distance(top_claw.transform.localRotation.eulerAngles, new Vector3(0, 0, max)) > 2)
        { 
            top_claw.transform.RotateAround(transform.position, top_claw.transform.TransformDirection(new Vector3(0, 0, -1)), speed * Time.deltaTime);
            bottom_claw.transform.RotateAround(transform.position, bottom_claw.transform.TransformDirection(new Vector3(0, 0, 1)), speed * Time.deltaTime);
        }
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
