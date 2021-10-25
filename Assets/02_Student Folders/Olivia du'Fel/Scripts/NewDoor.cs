using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewDoor : MonoBehaviour
{
    int number = 3;

    public float speed = 1f;

    bool isOpen = false;
    bool opening = false;
    bool closing = false;
    float timer;
    float timerLength = 1f;

    public Transform door1;

    public Transform door2;

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
            door1.Translate(Vector3.forward * Time.deltaTime * speed);

            door2.Translate(-Vector3.forward * Time.deltaTime * speed);
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
            door1.Translate(-Vector3.forward * Time.deltaTime * speed);

            door2.Translate(Vector3.forward * Time.deltaTime * speed);
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
