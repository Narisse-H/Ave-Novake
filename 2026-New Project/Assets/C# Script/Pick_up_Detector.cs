using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pick_up_Detector : MonoBehaviour
{
    Player_Data player_data;
    // Start is called before the first frame update
    void Start()
    {
        player_data = GetComponentInParent<Player_Data>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (player_data != null)
        {
            player_data.Pick_up(other.gameObject);
        }
    }
}
