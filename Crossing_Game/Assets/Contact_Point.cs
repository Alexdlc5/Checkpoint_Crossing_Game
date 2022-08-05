using UnityEngine;

public class Contact_Point : MonoBehaviour
{
    public bool isTop = false;
    public bool contact = false;
    public GameObject contacted_object;
    private int contacts = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Cargo"))
        {
            contacts++;
            contact = true;
            contacted_object = collision.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag.Equals("Cargo"))
        {
            contacts--;
            if (contacts == 0)
            {
                contact = false;
            }
        }
    }
}
