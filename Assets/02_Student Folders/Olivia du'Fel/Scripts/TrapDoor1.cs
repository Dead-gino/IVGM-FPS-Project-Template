using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapDoor1 : MonoBehaviour
{

    public Transform wall1;
    public Transform wall2;
    public Transform wall3;

    bool opening = true;
    bool closing = false;
    float timer;
    float timer_length = 1f;
    float speed = 7f;


    // Start is called before the first frame update
    void Start()
    {
        timer = timer_length;
    }

    // Update is called once per frame
    void Update()
    {
        if (opening && timer > 0f)
        {
            wall1.Translate(-Vector3.down * Time.deltaTime * speed);
            wall2.Translate(Vector3.down * Time.deltaTime * speed);
            wall3.Translate(-Vector3.down * Time.deltaTime * speed);
            timer -= Time.deltaTime;
        }
        else if (opening && timer <= 0f)
        {
            opening = false;
            timer = timer_length;
            closing = true;
        }

        if (closing && timer > 0f)
        {
            wall1.Translate(Vector3.down * Time.deltaTime * speed);
            wall2.Translate(-Vector3.down * Time.deltaTime * speed);
            wall3.Translate(Vector3.down * Time.deltaTime * speed);
            timer -= Time.deltaTime;
        }
        else if (closing && timer <= 0f)
        {
            opening = true;
            timer = timer_length;
            closing = false;
        }
    }
}