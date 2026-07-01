using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;

public class Player_Data : MonoBehaviour
{
    public Player_Data player_data;

    [System.Serializable]
    public struct Player
    {
        public Vector3 pstn;
        public Player_Data plyr_dt;
    }


    // Start is called before the first frame update
    void Start()
    {
        player_data = GetComponent<Player_Data>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Save()//Working in progress...
    {
        string output_json;
        Player player;
        player = new Player
        {
            pstn = transform.position,
            plyr_dt = player_data
        };
        output_json = JsonUtility.ToJson(player);
        Debug.Log(output_json); //Debug
    }

    public void Pick_up(GameObject touched)
    {
        //
    }

    void Save_package()
    {
        //Working in progress...
    }
}
