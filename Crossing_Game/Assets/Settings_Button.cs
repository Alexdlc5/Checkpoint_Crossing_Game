using UnityEngine.UI;
using UnityEngine;

public class Settings_Button : MonoBehaviour
{
    public Button button;
    public Vector2 button_target_left;
    public Vector2 button_target_right;
    private bool isRight = true;
    public float speed = 2;
    public GameObject title;
    public GameObject main_menu_buttons;

    private bool moving = false;

    void OpenSettingsMenu()
    {
         moving = true;  
    }

    private void Update()
    {
        button.onClick.AddListener(OpenSettingsMenu);

        if (moving)
        {
            Vector2 buttons_position = (Vector2) main_menu_buttons.transform.position;
            if (isRight)
            {
                if (buttons_position == button_target_left)
                {
                    isRight = false;
                    moving = false;
                }
                else
                {
                    main_menu_buttons.transform.position = Vector2.MoveTowards(main_menu_buttons.transform.position, button_target_left, speed * Time.deltaTime);
                }
            }
            else 
            {
                if (buttons_position == button_target_right)
                {
                    isRight = true;
                    moving = false;
                }
                else
                {
                    main_menu_buttons.transform.position = Vector2.MoveTowards(main_menu_buttons.transform.position, button_target_right, speed * Time.deltaTime);
                }
            }
        }
    }
}
