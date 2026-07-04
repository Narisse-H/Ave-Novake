using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public Rigidbody2D rb;
    public Collider2D coll;
    //public DistanceJoint2D dj;
    public float anchor_force_multip = 5.0f;
    public float anchor_distance;
    private bool anchor_active = false;
    public GameObject zs;
    public GameObject pre_anchor;
    public Vector3 anchor_pos;
    public int max_deployed_anchors;
    public int deployed_anchors;
    public float max_speed;

    //Functions
    void Set_anchor()//When key "F" is pressed
    {
        if (Input.GetKeyDown(KeyCode.F) || Input.GetMouseButton(1))
        {
            if (deployed_anchors < max_deployed_anchors)
            {
                anchor_pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                anchor_pos.z = -1.0f;
                if (Vector2.Distance(transform.position, anchor_pos) <= 2.0f)
                {
                    Instantiate(pre_anchor, anchor_pos, Quaternion.identity);
                    deployed_anchors += 1;
                }
            }
        }
    }

    void Enable_anchor_drag()
    {
        if (deployed_anchors > 0)
        {
            if (Input.GetKeyDown(KeyCode.H) && !anchor_active)
            {
                anchor_active = true;
                anchor_distance = Vector2.Distance(transform.position, anchor_pos);
            }
            else if (Input.GetKeyDown(KeyCode.H))
            {
                anchor_active = false;
            }
        }
        else
        {
            anchor_active = false;
        }
    }

    void Apply_force()
    {
        if (Vector2.Distance(transform.position, anchor_pos) >= anchor_distance && anchor_active)
        {
            rb.AddForce((Vector2)(anchor_pos - transform.position)*anchor_force_multip);
        }
    }

    void Change_distance()
    {
        if (Input.GetKey(KeyCode.E) && anchor_distance >= 0.1)
        {
            anchor_distance -= 0.001f;
        }

        if (Input.GetKey(KeyCode.Q))
        {
            anchor_distance += 0.001f;
        }
    }

    void OnTriggerEnter2D(Collider2D other)//Working in progress...
    {
        int object_class = other.GetComponent<InteractiveItems>().class_of_object;
        if (object_class == 0)//Game Over
        {
            //
        }
        else if (object_class > 0)//Add Score
        {
            zs.GetComponent<Zeus>().score += object_class;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //Init
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        zs = GameObject.FindGameObjectWithTag("GameController");
        deployed_anchors = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Set_anchor();
        Enable_anchor_drag();
        Change_distance();
    }

    void FixedUpdate()
    {
        Apply_force();
    }
}
