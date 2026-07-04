using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zeus : MonoBehaviour
{
    public GameObject player;
    public GameObject pre_wooden_barrel;
    public Vector3 spawn_pos;
    private float d_distance;
    private float d_pn;
    public int score = 0;
    public int active_items;
    public int max_active_items;

    IEnumerator Items_Controller()
    {
        while (true)
        {
            yield return new WaitForSeconds(5.0f);
            yield return new WaitUntil(() => active_items < max_active_items);

            d_distance = Random.Range(20.0f, 25.0f);
            d_pn = Random.Range(0.0f, 1.5f) - Random.Range(-1.5f, 0.0f);
            spawn_pos.x = player.transform.position.x + d_distance * d_pn;
            spawn_pos.y = player.transform.position.y + d_distance * d_pn;
            spawn_pos.z = -1.0f;
            Instantiate(pre_wooden_barrel, spawn_pos, Quaternion.identity);
            active_items += 1;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        active_items = 0;
        StartCoroutine(Items_Controller());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
