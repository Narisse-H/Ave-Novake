using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NewWindManager : MonoBehaviour
{
    public float currentDirection =0f;
    public float targetDirection = 0f;
    public float directionChangeRange = 20f;
    public float directionRotateSpeed = 20f;
    public float directionChangeInterval = 1f;
    public float currentSpeed = 5f;
    public float targetSpeed = 5f;
    public float speedChangeRange = 1f;
    public float speedChangeInterval = 5f;
    public float speedChangeSpeed = 1f;
    private float directionTimer;
    private float speedTimer;

    public List<GameObject> floating_objects;

    void UpdateDirection()
    {
        directionTimer += Time.deltaTime;

        if (directionTimer >= directionChangeInterval)
        {
            directionTimer = 0;

            float sign = Random.Range(0, 2) == 0 ? -1f : 1f;

            float randomAngle = Random.Range(5f, 20f);

            targetDirection += sign * randomAngle;

            targetDirection = Mathf.Repeat(targetDirection, 360f);
        }

        currentDirection = Mathf.MoveTowardsAngle
        (
            currentDirection,
            targetDirection,
            directionRotateSpeed * Time.deltaTime
        );
    }

    void UpdateSpeed()
    {
        speedTimer += Time.deltaTime;

        if (speedTimer >= speedChangeInterval)
        {
            speedTimer = 0;

            targetSpeed += Random.Range(-speedChangeRange, speedChangeRange);

            targetSpeed = Mathf.Clamp(targetSpeed, 2f, 8f);
        }

        currentSpeed = Mathf.MoveTowards
        (
            currentSpeed,
            targetSpeed,
            speedChangeSpeed * Time.deltaTime
        );
    }

    public Vector2 GetWindDirection()
    {
        float rad = currentDirection * Mathf.Deg2Rad;

        return new Vector2(
            Mathf.Cos(rad),
            Mathf.Sin(rad)
        ).normalized;
    }

    public Vector2 GetWindForce()
    {
        return GetWindDirection() * currentSpeed;
    }

    void Start()
    {
        floating_objects = GameObject.FindGameObjectsWithTag("Player").ToList();
    }
    void Update()
    {
        UpdateDirection();
        UpdateSpeed();
    }
}
