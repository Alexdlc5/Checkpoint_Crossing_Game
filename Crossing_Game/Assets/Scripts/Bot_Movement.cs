using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot_Movement : MonoBehaviour
{
    //Movement Variables
    //--------------------------------
    public float speed;
    public float reverse_speed;
    private Rigidbody2D rb;
    //time going one direction 
    private float time_horizontal;
    private float time_vertical;
    //previous keys
    private int? previous_vertical;
    private int? previous_horizontal;
    //--------------------------------

    //Beam Variables
    //--------------------------------
    public GameObject beam_segment;
    public float beam_length;
    public float segment_spacing;
    public float flux_speed;
    public float sin_max;
    public GameObject beam_up_target;
    public GameObject beam_down_target;
    public GameObject beam_left_target;
    public GameObject beam_right_target;

    private float sin_input = 1;
    //--------------------------------

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
        
        //destroys previous beams
        GameObject[] previous_beam = GameObject.FindGameObjectsWithTag("Beam");
        foreach (GameObject segment in previous_beam)
        {
            Destroy(segment);
        }

        CreateBeam(beam_up_target.transform.position, "Up");
        CreateBeam(beam_down_target.transform.position, "Down");
        CreateBeam(beam_left_target.transform.position, "Left");
        CreateBeam(beam_right_target.transform.position, "Right");
    }


    void CreateBeam(Vector2 target, string direction)
    {
        float random_value;

        float beam_distance = DistanceFromBot(target);

        Vector3 next_segment_coordinates = new Vector2(transform.position.x, transform.position.y);

        for (int i = 0; i < beam_length * beam_distance; i++)
        {
            //reset input
            if (sin_input > 500)
            {
                sin_input = 1;
            }
            sin_input += flux_speed * Time.deltaTime;
            random_value = sin_max * Mathf.Sin(sin_input);
            //places new wall with new coords and changes the coords for the next wall
            GameObject new_segment = Instantiate(beam_segment);
            //flip beam segment if horizontal
            if (direction.Equals("Left") || direction.Equals("Right"))
            {
                new_segment.transform.rotation = Quaternion.Euler(new Vector3(new_segment.transform.rotation.eulerAngles.x,new_segment.transform.rotation.eulerAngles.y, 90));
            }
            new_segment.transform.position = next_segment_coordinates;
            //create beam in correct direction
            if (direction.Equals("Up"))
            {
                next_segment_coordinates = new Vector3(next_segment_coordinates.x - random_value, next_segment_coordinates.y + segment_spacing, next_segment_coordinates.z);
            }
            else if (direction.Equals("Down"))
            {
                next_segment_coordinates = new Vector3(next_segment_coordinates.x - random_value, next_segment_coordinates.y - segment_spacing, next_segment_coordinates.z);
            }
            else if (direction.Equals("Left"))
            {
                next_segment_coordinates = new Vector3(next_segment_coordinates.x - segment_spacing, next_segment_coordinates.y - random_value, next_segment_coordinates.z);
            }
            else if (direction.Equals("Right"))
            {
                next_segment_coordinates = new Vector3(next_segment_coordinates.x + segment_spacing, next_segment_coordinates.y - random_value, next_segment_coordinates.z);
            }
        }
    }

    float DistanceFromBot(Vector2 point_b)
    {
        Vector2 point_a = transform.position;
        return Mathf.Sqrt(Mathf.Pow(point_b.x - point_a.x, 2) + Mathf.Pow(point_b.y - point_a.y, 2));
    }
    //move bot with player input
    void Move()
    {
        float travelDistance = speed * Time.deltaTime;

        //one vertical input allowed
        if (Input.GetKey(KeyCode.W))
        {
            if (previous_vertical == 0 || previous_vertical == null)
            {
                rb.AddForce(Vector2.up * travelDistance * (time_vertical * reverse_speed));
                previous_vertical = 1;
                time_vertical = 0;
            }
            else
            {
                rb.AddForce(Vector2.up * travelDistance);
                time_vertical += Time.deltaTime;
            }
        }
        else if (Input.GetKey(KeyCode.S))
        {
            if (previous_vertical == 1 || previous_vertical == null)
            {
                rb.AddForce(Vector2.up * -travelDistance * (time_vertical * reverse_speed));
                previous_vertical = 0;
                time_vertical = 0;
            }
            else
            {
                rb.AddForce(Vector2.up * -travelDistance);
                time_vertical += Time.deltaTime;
            }
        }
        //one horizontal input allowed
        if (Input.GetKey(KeyCode.D))
        {
            if (previous_horizontal == 0 || previous_horizontal == null)
            {
                rb.AddForce(Vector2.right * travelDistance * (time_horizontal * reverse_speed));
                previous_horizontal = 1;
                time_horizontal = 0;
            }
            else
            {
                rb.AddForce(Vector2.right * travelDistance);
                time_horizontal += Time.deltaTime;
            }
        }
        else if (Input.GetKey(KeyCode.A))
        {
            if (previous_horizontal == 1 || previous_horizontal == null)
            {
                rb.AddForce(Vector2.right * -travelDistance * (time_horizontal * reverse_speed));
                previous_horizontal = 0;
                time_horizontal = 0;
            }
            else
            {
                rb.AddForce(Vector2.right * -travelDistance);
                time_horizontal += Time.deltaTime;
            }
        }
    }
}
