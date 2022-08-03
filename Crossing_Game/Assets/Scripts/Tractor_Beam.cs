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
                else if (distance(gameObject.transform.position, cargo.transform.position) < distance(gameObject.transform.position, closest_cargo.transform.position))
                {
                    closest_cargo = cargo;
                }
            }
            transform.LookAt(closest_cargo.transform);
            closest_cargo.transform.position = Vector3.MoveTowards(closest_cargo.transform.position, transform.position, beam_strength * Time.deltaTime);
            CreateBeam(closest_cargo.transform.position);
        }
    }
    void CreateBeam(Vector2 target)
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
            new_segment.transform.rotation = Quaternion.Euler(0, 0, transform.rotation.eulerAngles.x);
            new_segment.transform.position = next_segment_coordinates;
            next_segment_coordinates = new Vector3(next_segment_coordinates.x - random_value, next_segment_coordinates.y + segment_spacing, next_segment_coordinates.z) * transform.TransformDirection(Vector2.up);
        }
    }

    float DistanceFromBot(Vector2 point_b)
    {
        Vector2 point_a = transform.position;
        return Mathf.Sqrt(Mathf.Pow(point_b.x - point_a.x, 2) + Mathf.Pow(point_b.y - point_a.y, 2));
    }
    //find distance between two vectors
    private float distance(Vector3 pointa, Vector3 pointb)
    {
        return Mathf.Sqrt(Mathf.Pow(pointb.x - pointa.x, 2) + Mathf.Pow(pointb.y - pointa.y, 2));
    }
}
