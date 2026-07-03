using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anchor : MonoBehaviour
{
    public GameObject player;
    public int player_deployed_anchors;


    void OnMouseDown()//When the anchor is pointed
    {
        player_deployed_anchors -= 1;
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        player_deployed_anchors = player.GetComponent<Ship>().max_deployed_anchors;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
