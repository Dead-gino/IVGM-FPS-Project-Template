using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dashing : MonoBehaviour
{

    // player position
    public GameObject player;

    //CharecterContoller responsible for controlling the movement of the player
    CharacterController m_Controller;

    // speed of dash (1000 translates about 3m per frame)
    public float dash_speed = 10;

    //length of dash in ms
    public float dash_length = 200;

    //length of dash in seconds
    float dash_length_s;

    //timer for how long the player is dashing
    float dash_time;

    //boolean to keep track if the player is dashing
    bool in_dash = false;

    //bool whether the player has the powerup on start
    public bool dash_enabled_on_start = false;
    bool can_dash = false;

    // Start is called before the first frame update
    void Start()
    {
        //fetch the CharacterController to be able to move the player
        m_Controller = GetComponent<CharacterController>();

        //get the dash time length in seconds
        dash_length_s = dash_length / 1000;

        //create a timer for how long the player dashes
        dash_time = 0f;

        //if the player should be able to dash on start, make them dash
        if (dash_enabled_on_start)
        {
            can_dash = true;
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        //if the player has the dash powerup
        if (can_dash)
        {
            //get the player's rotation
            Quaternion rot = player.GetComponent<Transform>().rotation;

            //crate a vector in the relative, positive X direction of the player
            Vector3 dir = Vector3.forward;
            dir = rot * dir;

            // when dash key is presssed and not already dashing
            if (Input.GetKeyDown(KeyCode.LeftControl) && in_dash == false)
            {
                Debug.Log("Dash key pressed.");
                // make the player dash
                in_dash = true;
            }
            //if the player is dashing and dash is not over yet
            if (in_dash && dash_time < dash_length_s)
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
                dash_time = 0f;
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
