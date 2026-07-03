using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public float max_speed;
    public Rigidbody2D rg;
    public Collider2D coll;
    public DistanceJoint2D dj;
    // Start is called before the first frame update
    void Start()
    {
        //Init
        rg = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        dj = GetComponent<DistanceJoint2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
