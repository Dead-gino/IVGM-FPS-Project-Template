using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Dashing : MonoBehaviour
{

    // player position
    public Transform player;

    // speed/distance covered of dash
    public float dash_speed = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // when dash key is presssed
        if (Input.GetKeyDown(KeyCode.LeftControl)) {
            Debug.Log("Dash key pressed.");
            
        }
    }
}
