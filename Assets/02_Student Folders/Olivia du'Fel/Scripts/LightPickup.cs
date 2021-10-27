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

        // torch.SetActive(true);

        var torch_player = Instantiate(torch);
        torch_player.transform.position = new Vector3(-1, 1, 1);
        torch_player.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        torch_player.transform.SetParent(player.transform, false);
        Debug.Log(torch_player.transform.position);
        m_Pickup.PlayPickupFeedback();

            Destroy(gameObject);
        
    }

}
