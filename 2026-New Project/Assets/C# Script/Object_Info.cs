using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Info : MonoBehaviour
{
    [Header("Basic Information")]
    public string item_name;
    public int item_id;
    public int item_volume;
    public int item_class;
    public string item_sprite_path;

    // Start is called before the first frame update
    void Start()
    {
        //item_id = GameObject.FindGameObjectWithTag("Zeus").Spawn_new_item();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
