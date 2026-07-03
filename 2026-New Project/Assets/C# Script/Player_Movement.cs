using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    //Basic Component
    public Rigidbody2D player_rb;
    public Collider2D player_coll;

    //Basic Attributes
    public float hp;
    public float speed;
    public float moving_horizontal;
    public float moving_vertical;

    // Start is called before the first frame update
    void Start()
    {
        player_rb = GetComponent<Rigidbody2D>();
        player_coll = GetComponent<Collider2D>();
        //Working in progress...
    }

    // Update is called once per frame
    void Update()
    {
        Player_move();
        //Working in progress...
    }

    void Player_move()//Working in progress...
    {
        moving_horizontal = Input.GetAxis("Horizontal");
        moving_vertical = Input.GetAxis("Vertical");

        float face = Input.GetAxisRaw("Horizontal");
        if (face != 0)
        {
            transform.localScale = new Vector3(-face, transform.localScale.y, transform.localScale.z);
        }

        player_rb.velocity = new Vector2(speed * moving_horizontal, speed * moving_vertical);
        //Working in progress...
    }
}
