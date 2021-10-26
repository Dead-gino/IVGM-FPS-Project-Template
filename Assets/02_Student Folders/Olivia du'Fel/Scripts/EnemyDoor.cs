using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDoor : MonoBehaviour
{
    int number = 3;

    public float speed = 2f;

    bool isOpen = false;
    bool opening = false;
    bool closing = false;
    float timer;
    float timerLength = 3f;

    public Transform Edoor1;

    public Transform Edoor2;

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
            Edoor1.Translate(-Vector3.forward * Time.deltaTime * speed);

            Edoor2.Translate(Vector3.forward * Time.deltaTime * speed);
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
            Edoor1.Translate(Vector3.forward * Time.deltaTime * speed);

            Edoor2.Translate(-Vector3.forward * Time.deltaTime * speed);
            timer -= Time.deltaTime;
        }
        else if (closing && timer <= 0f)
        {
            closing = false;
            timer = timerLength;
            isOpen = false;
        }
    }

    void OnTriggerEnter(Collider third)
    {
    
        if (!isOpen)
        {
            isOpen = true;
            timer = timerLength;
            opening = true;

        }
    }
}
