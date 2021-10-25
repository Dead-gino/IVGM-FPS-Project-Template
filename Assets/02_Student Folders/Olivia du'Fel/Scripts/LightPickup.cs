using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPickup : MonoBehaviour
{

    Pickup m_Pickup;

    public GameObject torch;

    // Start is called before the first frame update
    void Start()
    {
        m_Pickup = GetComponent<Pickup>();
        DebugUtility.HandleErrorIfNullGetComponent<Pickup, HealthPickup>(m_Pickup, this, gameObject);

        // Subscribe to pickup action
        m_Pickup.onPick += OnPicked;
    }

    void OnPicked(PlayerCharacterController player)
    {

        torch.SetActive(true);
        

            m_Pickup.PlayPickupFeedback();

            Destroy(gameObject);
        
    }

}
