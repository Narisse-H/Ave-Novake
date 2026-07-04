using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingObject : MonoBehaviour
{
    //
    public Rigidbody2D rg;
    public Collider2D coll;
    public GameObject zs;
    public GameObject wind_controller;
    public float max_speed;
    public float wind_level;

    // Start is called before the first frame update
    public void Apply_wind_force()
    {
        //Vector2 to_anchor = 
    }

    void Start()
    {
        rg = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        zs = GameObject.FindGameObjectWithTag("GameController");
        wind_controller = GameObject.FindGameObjectWithTag("WeatherController");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
