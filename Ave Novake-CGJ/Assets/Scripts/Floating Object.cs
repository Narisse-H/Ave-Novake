using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingObject : MonoBehaviour
{
    //
    public Rigidbody2D rb;
    public Collider2D coll;
    public GameObject zs;
    public WeatherController wind_controller;
    public float angle_rad;
    public float wind_level;
    public float max_speed;

    // Start is called before the first frame update
    public void Apply_wind_force()
    {
        angle_rad = wind_controller.wind_angle * Mathf.Deg2Rad;
        wind_level = wind_controller.wind_level;
        Vector2 direction = new Vector2(Mathf.Cos(angle_rad), Mathf.Sin(angle_rad));
        rb.AddForce(direction * wind_level);
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        zs = GameObject.FindGameObjectWithTag("GameController");
        wind_controller = GameObject.FindGameObjectWithTag("WeatherController").GetComponent<WeatherController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (rb.velocity.magnitude < max_speed)
        {
            Apply_wind_force();
        }
    }
}
