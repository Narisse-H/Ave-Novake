using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zeus : MonoBehaviour
{
    public GameObject player;
    public int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
