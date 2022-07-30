using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public GameObject target;
    public bool isWallbot = false;
    public bool x = false;
    public bool y = false;
    private Animator animator;
    private void Start()
    {
        if (isWallbot)
            animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        if (isWallbot)
        {
            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow) )
            {
                animator.SetFloat("Speed", 1);
            }
            else
            {
                animator.SetFloat("Speed", 0);
            }
        }
        Vector2 target_coords = new Vector2(transform.position.x, transform.position.y);
        if (x)
        {
            target_coords.x = target.transform.position.x;
        }
        if (y)
        {
            target_coords.y = target.transform.position.y;
        }
        transform.position = target_coords;
    }
    float DistanceFromBot(Vector2 point_b)
    {
        Vector2 point_a = transform.position;
        return Mathf.Sqrt(Mathf.Pow(point_b.x - point_a.x, 2) + Mathf.Pow(point_b.y - point_a.y, 2));
    }
}
