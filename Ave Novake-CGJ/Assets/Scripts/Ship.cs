using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public float max_speed;
    public Rigidbody2D rg;
    public Collider2D coll;
    public DistanceJoint2D dj;
    public GameObject pre_anchor;
    public List<GameObject> anchors;
    public int max_deployed_anchors;
    public int deployed_anchors;

    //Functions
    void Set_anchor()//When key "F" is pressed
    {
        if (deployed_anchors < max_deployed_anchors)
        {
            Vector3 mouse_pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            GameObject new_anchor = Instantiate(pre_anchor, mouse_pos, Quaternion.identity);
            anchors.Add(new_anchor);
            deployed_anchors += 1;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //Init
        rg = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        dj = GetComponent<DistanceJoint2D>();
        deployed_anchors = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
