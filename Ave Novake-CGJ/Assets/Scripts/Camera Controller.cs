using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject character;
    public Vector2 ship_pos;

    void Camera_move()//Working in progress...
    {
        //
        ship_pos = character.transform.position;
        if ((ship_pos.x - transform.position.x) >= 7 || (ship_pos.y - transform.position.y) >= 3.5)
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
