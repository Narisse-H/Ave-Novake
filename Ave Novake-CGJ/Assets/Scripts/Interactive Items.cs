using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveItems : MonoBehaviour
{
    public int class_of_object;
    public GameObject zs;
    public GameObject player;

    void OnTriggerEnter2D(Collider2D other)//Working in progress...
    {
        if (other.tag == "Player")
        {
            Destroy(gameObject);
        }
    }

    void Distance_limit()
    {
        if (Vector2.Distance(player.transform.position, transform.position) >= 25.0f)
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        zs = GameObject.FindGameObjectWithTag("GameController");
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Distance_limit();
    }
}
