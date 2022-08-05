using UnityEngine;

public class Tractor_Beam : MonoBehaviour
{
    public GameObject beam_segment;
    public float beam_strength;
    public float beam_length;
    public float segment_spacing;
    public float flux_speed;
    public float sin_max;
    private float sin_input = 1;

    // Update is called once per frame
    void Update()
    {
        //destroys previous beams
        GameObject[] previous_beam = GameObject.FindGameObjectsWithTag("Tractor_Beam");
        foreach (GameObject segment in previous_beam)
        {
            Destroy(segment);
        }
        //with player input, find nearest piece of cargo and use tractor beam on it
        if (Input.GetKey(KeyCode.LeftShift))
        {
            GameObject[] nearby_cargo = GameObject.FindGameObjectsWithTag("Cargo");
            GameObject closest_cargo = null;
            foreach (GameObject cargo in nearby_cargo)
            {
                if (closest_cargo == null)
                {
                    closest_cargo = cargo;
                }
                else if (Distance(gameObject.transform.position, cargo.transform.position) < Distance(gameObject.transform.position, closest_cargo.transform.position))
                {
                    closest_cargo = cargo;
                }
            }
            //set beam direction and position of origin
            transform.LookAt(closest_cargo.transform.position, Vector3.up);
            transform.localPosition = new Vector3(0, 0, 0);
            //move cargo
            closest_cargo.transform.position = Vector3.MoveTowards(closest_cargo.transform.position, transform.position, beam_strength * Time.deltaTime);
            closest_cargo.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            //create visual tractor beam
            CreateBeam(closest_cargo.transform.position);

        }
    }
    void CreateBeam(Vector2 target)
    {
        float random_value;
        float beam_distance = Distance(transform.position, target);
        Vector3 next_segment_coordinates = new Vector2(0, 0);
        //creates beam using smaller beam segments to cargo
        for (int i = 0; i < beam_length * beam_distance; i++)
        {
            //sin function used to make tractor beam wave back and forth
            //reset input
            if (sin_input > 500)
            {
                sin_input = 1;
            }
            sin_input += flux_speed * Time.deltaTime;
            random_value = sin_max * Mathf.Sin(sin_input);
            //places new segement and sets position and rotation
            GameObject new_segment = Instantiate(beam_segment);
            new_segment.transform.parent = transform;
            new_segment.transform.localPosition = next_segment_coordinates; 
            //new set of coordinates for next segment
            next_segment_coordinates = new Vector3(next_segment_coordinates.x - random_value, next_segment_coordinates.y, next_segment_coordinates.z + + segment_spacing);
        }
    }
    //find distance between two vectors
    private float Distance(Vector3 pointa, Vector3 pointb)
    {
        return Mathf.Sqrt(Mathf.Pow(pointb.x - pointa.x, 2) + Mathf.Pow(pointb.y - pointa.y, 2));
    }
}
