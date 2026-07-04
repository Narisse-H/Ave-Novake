using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anchor : MonoBehaviour
{
    public GameObject player;

    void OnMouseDown()//No need to call in Update; Unity calls it automatically.
    {
        player.GetComponent<Ship>().deployed_anchors -= 1;
        Destroy(gameObject);
    }

    void Recycle()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            player.GetComponent<Ship>().deployed_anchors -= 1;
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Recycle();
    }
}
