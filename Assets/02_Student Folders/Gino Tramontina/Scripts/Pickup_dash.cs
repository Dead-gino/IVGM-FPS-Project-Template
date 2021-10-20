using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Pickup))]
public class Pickup_dash : MonoBehaviour
{

    Pickup m_Pickup;
    
    // Start is called before the first frame update
    void Start()
    {
        m_Pickup = GetComponent<Pickup>();
        //DebugUtility.HandleErrorIfNullGetComponent<Pickup, WeaponPickup>(m_Pickup, this, gameObject);

        // Subscribe to pickup action
        m_Pickup.onPick += OnPicked;
    }

    void OnPicked(PlayerCharacterController byPlayer)
    {
        Dashing dasher = byPlayer.GetComponent<Dashing>();
        if (dasher)
        {
            if (dasher.Enable())
            {
                m_Pickup.PlayPickupFeedback();

                Destroy(gameObject);
            }
        }
    }
}
