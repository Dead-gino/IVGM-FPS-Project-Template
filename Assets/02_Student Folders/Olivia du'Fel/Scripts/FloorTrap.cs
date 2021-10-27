using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorTrap : MonoBehaviour
{
    int number = 3;

    private float speed = 20f;

    bool isOpen = false;
    bool opening = false;
    bool closing = false;
    float timer;
    float timerLength = 25f;

    public Transform floor1;

   

    Collider triggerZone;
    // Start is called before the first frame update
    void Start()
    {

        triggerZone = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()

    {
        if (opening && timer > 0f)
        {
            floor1.Translate(Vector3.down * Time.deltaTime * speed);

           
            timer -= Time.deltaTime;
        }
        else if (opening && timer <= 0f)
        {
            opening = false;
            timer = timerLength;
            closing = true;

        }

        if (closing && timer > 0f)
        {
            floor1.Translate(-Vector3.down * Time.deltaTime * speed);

            
            timer -= Time.deltaTime;
        }
        else if (closing && timer <= 0f)
        {
            closing = false;
            timer = timerLength;
            isOpen = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (!isOpen)
        {
            isOpen = true;
            timer = timerLength;
            opening = true;

        }
    }
}
