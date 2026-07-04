using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherController : MonoBehaviour
{
    public float wind_level;
    public float wind_angle;
    private float d_wind_level;
    private float d_wind_angle;
    public float angle_random_range;
    public float level_random_range;
    public float max_wind_level;
    public float time_interval;

    //Functions
    IEnumerator Weather_Controller()
    {
        while (true)
        {
            d_wind_angle = Random.Range(-angle_random_range, angle_random_range);
            d_wind_level = Random.Range(-level_random_range, level_random_range);
            if (Mathf.Abs(wind_level + d_wind_level) <= max_wind_level)
            {
                wind_angle += d_wind_angle;
                wind_level += d_wind_level;
            }
            else
            {
                wind_angle += d_wind_angle;
            }
            yield return new WaitForSeconds(time_interval);
        }
    }

    public Vector2 GetWindDirection()
    {
        float rad = wind_angle * Mathf.Deg2Rad;

        return new Vector2(
            Mathf.Cos(rad),
            Mathf.Sin(rad)
        ).normalized;
    }

    // Start is called before the first frame update
    void Start()
    {
        wind_angle = Random.Range(0.0f, 360.0f);
        wind_level = Random.Range(0.0f, 1.5f);
        StartCoroutine(Weather_Controller());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
