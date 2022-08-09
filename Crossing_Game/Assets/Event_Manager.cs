using UnityEngine;
using TMPro;

public class Event_Manager : MonoBehaviour
{
    public int fails = 0;
    public float timer = 10;
    public string next_cover_type;
    public string[] cover_types;

    public TextMeshProUGUI time;
    public TextMeshProUGUI fail;
    public TextMeshProUGUI cover;

    // Update is called once per frame
    void Update()
    {
        time.text = "Time: " + timer;
        fail.text = "Fails: " + fails;
        cover.text = "Cover: " + next_cover_type;
        if (timer <= 0)
        {
            timer = 10;
            GameObject[] cargo_gameobjects = GameObject.FindGameObjectsWithTag("Cargo");
            next_cover_type = cover_types[Random.Range(0, cover_types.Length)];
            foreach (GameObject cargo in cargo_gameobjects)
            {
                //checks if cargo is in cover 
                Cargo cargo_script = cargo.GetComponent<Cargo>();
                if (!cargo_script.inside_cover)
                {
                    fails++;
                }
                //changes cover type randomly
                cargo_script.cover_type = next_cover_type;
            }
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }
}
