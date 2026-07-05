using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Zeus : MonoBehaviour
{
    public GameObject player;
    public GameObject pre_wooden_barrel;
    public TextMeshProUGUI scoreboard;
    public Vector3 spawn_pos;
    private float d_distance;
    public int score = 0;
    public int active_items;
    public int max_active_items;

    IEnumerator Items_Controller()
    {
        while (true)
        {
            yield return new WaitForSeconds(2.0f);
            yield return new WaitUntil(() => active_items < max_active_items);

            d_distance = Random.Range(15.0f, 20.0f);
            if (Random.Range(-1.0f, 1.0f) < 0)
            {
                spawn_pos.x = player.transform.position.x - d_distance;
                spawn_pos.y = player.transform.position.y - d_distance;
            }
            else
            {
                spawn_pos.x = player.transform.position.x + d_distance;
                spawn_pos.y = player.transform.position.y + d_distance;
            }
            if (Mathf.Abs(spawn_pos.x) < 75.0f && Mathf.Abs(spawn_pos.y) < 75.0f)
            {
                spawn_pos.z = -1.0f;
                Instantiate(pre_wooden_barrel, spawn_pos, Quaternion.identity);
                active_items += 1;
            }
        }
    }

    void Update_scoreboard()
    {
        scoreboard.text = "得分:" + score;
    }

    void Back_main_interface()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Main Interface");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        scoreboard = GameObject.FindGameObjectWithTag("Scoreboard").GetComponent<TextMeshProUGUI>();
        active_items = 0;
        StartCoroutine(Items_Controller());
    }

    // Update is called once per frame
    void Update()
    {
        Back_main_interface();
        Update_scoreboard();
    }
}
