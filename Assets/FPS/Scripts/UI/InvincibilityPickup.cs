using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvincibilityPickup : MonoBehaviour
{

    Pickup m_Pickup;


    // Start is called before the first frame update
    void Start()
    {
        m_Pickup = GetComponent<Pickup>();
        DebugUtility.HandleErrorIfNullGetComponent<Pickup, InvincibilityPickup>(m_Pickup, this, gameObject);

        // Subscribe to pickup action
        m_Pickup.onPick += OnPicked;
    }
    
    void OnPicked(PlayerCharacterController player)
    {
        Health playerHealth = player.GetComponent<Health>();
        if (playerHealth && playerHealth.invincible == false)
        {
            playerHealth.invincible = true;
            m_Pickup.PlayPickupFeedback();
            Destroy(gameObject);

        }
        else 
        {
            playerHealth.invincible = false;
            m_Pickup.PlayPickupFeedback();
            Destroy(gameObject);

        }
    }


}
