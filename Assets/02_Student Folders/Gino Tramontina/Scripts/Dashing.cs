using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dashing : MonoBehaviour
{

    // player object
    public GameObject player;

    //CharecterContoller and PlayerCharacterContoller responsible for controlling the player
    CharacterController m_Controller;
    PlayerCharacterController p_Controller;

    //cooldown bar of the dash
    public Image cooldown;

    // speed of dash (1000 translates about 3m per frame)
    public float dash_speed = 10;

    //length of dash in ms
    public float dash_length = 200;

    //length of dash in seconds
    float dash_length_s;

    //length of delay between dashes in ms;
    public float dash_delay = 1000;

    float dash_delay_s;

    //timer for how long the player is dashing
    float dash_time;

    //timer for how long the delay has been active
    float delay_time;

    //storage for gravityDownForce variable
    float gravity;

    //boolean to keep track if the player is dashing or in cooldown
    bool in_dash = false;
    bool in_cooldown = false;

    //bool whether the player has the powerup on start
    public bool dash_enabled_on_start = false;
    bool can_dash = false;

    // Start is called before the first frame update
    void Start()
    {
        //fetch the CharacterController to be able to move the player
        m_Controller = GetComponent<CharacterController>();
        p_Controller = player.GetComponent<PlayerCharacterController>();

        gravity = p_Controller.gravityDownForce;

        //get the dash time length in seconds
        dash_length_s = dash_length / 1000;
        dash_delay_s = dash_delay / 1000;

        //create a timer for how long the player dashes
        dash_time = 0f;
        delay_time = 0f;

        //if the player should be able to dash on start, make them dash
        if (dash_enabled_on_start)
        {
            can_dash = true;
            delay_time = 1f;
        }
       
    }

    // Update is called once per frame
    void Update()
    { 
        //if the player has the dash powerup
        if (can_dash)
        {
            //the cooldown bar is full when player just dashed/is dashing
            //cooldown bar empties until player can dash again
            float fill = delay_time / dash_delay_s;
            cooldown.fillAmount = 1 - fill;

            //get the player's rotation
            Quaternion rot = player.GetComponent<Transform>().rotation;
            

            //crate a vector in the relative, positive X direction of the player
            Vector3 dir = Vector3.forward;
            dir = rot * dir;

            // when dash key is presssed and not already dashing
            if (Input.GetKeyDown(KeyCode.LeftControl) && !in_dash && !in_cooldown)
            {
                Debug.Log("Dash key pressed.");
                // make the player dash
                in_dash = true;
                delay_time = 0f;
                p_Controller.gravityDownForce = 0;
            }

            // if the dash is on cooldown
            if (in_cooldown && delay_time < dash_delay_s)
            {
                delay_time += Time.deltaTime;
            }
            // if the cooldown of the dash is over
            else if (in_cooldown && delay_time >= dash_delay_s)
            {
                in_cooldown = false;
            }
            //if the player is dashing and dash is not over yet
            else if (in_dash && dash_time < dash_length_s)
            {
                //move the player forward
                m_Controller.Move(dir * dash_speed * Time.deltaTime);
                //add time passed in dash to timer
                dash_time += Time.deltaTime;
            }
            //if the player should be finished dashing
            else if (in_dash && dash_time >= dash_length_s)
            {
                //end dash and reset timer
                in_dash = false;
                in_cooldown = true;
                dash_time = 0f;
                p_Controller.gravityDownForce = gravity;
            }
            else
            {
                delay_time = 1f;
            }
        }
    }

    //enable dash powerup
    public bool Enable()
    {
        can_dash = true;
        return true;
    }
}
