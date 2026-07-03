using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject character;
    public Vector2 ship_pos;
    private float pos_x;
    private float pos_y;

    void Camera_move()//Working in progress...
    {
        ship_pos = character.transform.position;
        pos_x = (ship_pos.x - transform.position.x);
        pos_y = (ship_pos.y - transform.position.y);
        if (pos_x >= 7 || pos_x <= -7)

        {
            //
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        character = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
