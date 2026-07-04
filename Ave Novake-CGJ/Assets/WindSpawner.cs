using System.Collections;
using UnityEngine;

public class WindSpawner : MonoBehaviour
{
    [Header("引用")]
    public Transform player;
    public WeatherController wind;

    [Header("漂浮物")]
    public GameObject[] prefabs;

    [Header("生成")]
    public float spawnDistance ;      // 在玩家多远生成
    public float spawnWidth ;         // 生成带宽
    public float destroyDistance ;    // 删除距离
    public float spawnInterval ;

    public int maxObjects ;

    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            GameObject[] objs = GameObject.FindGameObjectsWithTag("Floating");

            if (objs.Length < maxObjects)
            {
                SpawnOne();
            }

            DestroyFar();

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnOne()
    {
        // 当前风向
        Vector2 windDir = wind.GetWindDirection();

        // 从风吹来的反方向生成
        Vector2 spawnCenter =
            (Vector2)player.position
            - windDir * spawnDistance;

        // 与风垂直方向
        Vector2 perpendicular =
            new Vector2(-windDir.y, windDir.x);

        // 在一条线上随机
        float offset = Random.Range(-spawnWidth / 2f,
                                     spawnWidth / 2f);

        Vector2 spawnPos =
            spawnCenter + perpendicular * offset;

        int index = Random.Range(0, prefabs.Length);

        Instantiate(prefabs[index],
                    spawnPos,
                    Quaternion.identity);
    }

    void DestroyFar()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Floating");

        foreach (GameObject obj in objs)
        {
            if (Vector2.Distance(player.position,
                                 obj.transform.position)
                > destroyDistance)
            {
                Destroy(obj);
            }
        }
    }
}