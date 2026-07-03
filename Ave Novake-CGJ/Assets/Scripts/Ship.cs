using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public float max_speed;
    public Rigidbody2D rg;
    public Collider2D coll;
    public DistanceJoint2D dj;
    public GameObject zs;
    public GameObject pre_anchor;
    public Vector2 anchor_pos;
    public int max_deployed_anchors;
    public int deployed_anchors;

    //Functions
    void Set_anchor()//When key "F" is pressed
    {
        if (Input.GetKeyDown(KeyCode.F) || Input.GetMouseButton(1))
        {
            if (deployed_anchors < max_deployed_anchors)
            {
                anchor_pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Instantiate(pre_anchor, anchor_pos, Quaternion.identity);
                deployed_anchors += 1;
            }
        }
    }

    void Enable_anchor_drag()
    {
        if (deployed_anchors > 0)
        {
            if (Input.GetKeyDown(KeyCode.H) && !dj.enabled)
            {
                dj.enabled = true;
                dj.anchor = anchor_pos;
            }
            else if (Input.GetKeyDown(KeyCode.H))
            {
                dj.enabled = false;
            }
        }
        else
        {
            dj.enabled = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)//Working in progress...
    {
        int object_class = other.GetComponent<FloatingObject>().class_of_object;
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
        rg = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        dj = GetComponent<DistanceJoint2D>();
        zs = GameObject.FindGameObjectWithTag("GameController");
        deployed_anchors = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Set_anchor();
        Enable_anchor_drag();
    }
}
