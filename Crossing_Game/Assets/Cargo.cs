using UnityEngine;

public class Cargo : MonoBehaviour
{
    public bool inside_cover = false;
    public string cover_type = "Visual_Cover";
    private string previous_frame_cover_type = "Visual_Cover";
    private void Update()
    {
        transform.parent = null;
        if (!previous_frame_cover_type.Equals(cover_type))
        {
            previous_frame_cover_type = cover_type;
            inside_cover = false;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag.Equals(cover_type))
        {
            inside_cover = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag.Equals(cover_type))
        {
            inside_cover = false;
        }
    }
}
