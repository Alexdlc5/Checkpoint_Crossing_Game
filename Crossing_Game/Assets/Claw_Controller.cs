using UnityEngine;

public class Claw_Controller : MonoBehaviour
{
    public GameObject top_claw;
    public GameObject bottom_claw;
    public float topclaw_angle = 45;
    public float bottomclaw_angle = 315;
    public float speed = 10;

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
        if (Input.GetKey(KeyCode.Space))
        { 
            top_claw.transform.RotateAround(transform.position, top_claw.transform.TransformDirection(new Vector3(0, 0, -1)), speed * Time.deltaTime);
            bottom_claw.transform.RotateAround(transform.position, bottom_claw.transform.TransformDirection(new Vector3(0, 0, 1)), speed * Time.deltaTime);
        }
        //clamps roation and position
        //bottom_claw.transform.localRotation = Quaternion.Euler(0, 0, Mathf.Clamp(bottom_claw.transform.localRotation.z, 270, 315));
        //top_claw.transform.localRotation = Quaternion.Euler(0, 0, Mathf.Clamp(top_claw.transform.localRotation.z, 270, 227));
        bottom_claw.transform.localPosition = bc_starting_coords;
        top_claw.transform.localPosition = tc_starting_coords;
    }
}
