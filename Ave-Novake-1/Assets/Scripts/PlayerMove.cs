using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float player_speed;
    public Rigidbody2D player_rb;
    public Collider2D player_coll;
    public Animator Player_anim;

    // Start is called before the first frame update
    void Start()
    {
        player_rb = GetComponent<Rigidbody2D>();
        player_coll = GetComponent<Collider2D>();
        Player_anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
    }
    void PlayerMove()
    {
        float horizontal_num = Input.GetAxis("Horizontal");
        float face = Input.GetAxisRaw("Horizontal");
        if (face != 0)
        {
            transform.localScale = new Vector3(-face, transform.localScale.y, transform.localScale.z);
        }
        player_rb.velocity = new Vector2(player_speed * horizontal_num, player_rb.velocity.y);
        Player_anim.SetFloat("run",Mathf.Abs(player_speed * horizontal_num));
    }
}
