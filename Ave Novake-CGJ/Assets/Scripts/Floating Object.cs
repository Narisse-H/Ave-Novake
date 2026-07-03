using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingObject : MonoBehaviour
{
    //
    public Rigidbody2D rg;
    public Collider2D coll;
    public float max_speed;
    public int class_of_object;
    // Start is called before the first frame update
    public void Apply_wind_force()
    {
        //Vector2 to_anchor = 
    }
    void Start()
    {
        rg = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
