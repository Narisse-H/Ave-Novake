using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherController : MonoBehaviour
{
    //
    public float wind_level;
    public float wind_angle;
    private float d_wind_level;
    private float d_wind_angle;
    public float angle_random_range;
    public float level_random_range;
    public float time_interval;

    //Functions
    IEnumerator Weather_Controller()
    {
        while (true)
        {
            d_wind_angle = Random.Range(-angle_random_range, angle_random_range);
            d_wind_level = Random.Range(-level_random_range, level_random_range);
            wind_angle += d_wind_angle;
            wind_level += d_wind_level;
            yield return new WaitForSeconds(time_interval);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        wind_angle = Random.Range(0.0f, 360.0f);
        wind_level = Random.Range(0.0f, 3.0f);
        StartCoroutine(Weather_Controller());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
