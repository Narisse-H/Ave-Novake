using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject character;
    public Vector2 ship_pos;
<<<<<<< HEAD
    public float thresholdX = 5.0f;
    public float thresholdY = 3.0f;
=======
<<<<<<< HEAD

    void Camera_move()//Working in progress...
    {
        //
        ship_pos = character.transform.position;
        if ((ship_pos.x - transform.position.x) >= 7 || (ship_pos.y - transform.position.y) >= 3.5)
=======
>>>>>>> parent of d616af2 (1)
    private float pos_x;
    private float pos_y;
    float smoothSpeed = 3f;

    void Camera_move()//Working in progress...
    {
        ship_pos = character.transform.position;
        pos_x = (ship_pos.x - transform.position.x);
        pos_y = (ship_pos.y - transform.position.y);
<<<<<<< HEAD
        Vector3 targetCamPos = transform.position;

        if (Mathf.Abs(pos_x) > thresholdX)
=======
        if (pos_x >= 7 || pos_x <= -7)
>>>>>>> parent of 15f0215 (删除原仓库文件，仅保留WindManager项目)
>>>>>>> parent of d616af2 (1)
        {
            targetCamPos.x = ship_pos.x - thresholdX * Mathf.Sign(pos_x);
        }

        if (Mathf.Abs(pos_y) > thresholdY)
        {
            targetCamPos.y = ship_pos.y - thresholdY * Mathf.Sign(pos_y);
        }

        targetCamPos.z = transform.position.z;
        transform.position = Vector3.Lerp(transform.position, targetCamPos, 1 - Mathf.Exp(-smoothSpeed * Time.deltaTime));
        
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
    void LateUpdate()
    {
        Camera_move();
    }
}
