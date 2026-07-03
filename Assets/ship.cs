using UnityEngine;

public class Boat : MonoBehaviour
{
    public WindManager wind;
    public float windForce = 5f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        wind=FindObjectOfType<WindManager>();   
    }

    void FixedUpdate()
    {
        rb.velocity = wind.GetWindDirection() * windForce;
    }
}