using UnityEngine;

public class WindManager : MonoBehaviour
{
    [Header("风向设置")]
    public float currentDirection =0f;   // 当前风向（度）
    public float targetDirection = 0f;    // 目标风向（度）
    public float directionChangeRange = 20f; // 每次最多变化 ±20°
    public float directionRotateSpeed = 20f; // 风向变化速度（度/秒）
    public float directionChangeInterval = 1f; // 每隔几秒随机一次

    [Header("风速设置")]
    public float currentSpeed = 5f;
    public float targetSpeed = 5f;
    public float speedChangeRange = 1f;
    public float speedChangeInterval = 5f;
    public float speedChangeSpeed = 1f;

    private float directionTimer;
    private float speedTimer;

    void Update()
    {
        UpdateDirection();
        UpdateSpeed();
    }

    // 更新风向
    void UpdateDirection()
    {
        directionTimer += Time.deltaTime;

        // 每隔几秒重新选择一个目标方向
        if (directionTimer >= directionChangeInterval)
        {
            directionTimer = 0;

            // 随机左(-1)或右(+1)
            float sign = Random.Range(0, 2) == 0 ? -1f : 1f;

            // 随机旋转角度（5°~20°）
            float randomAngle = Random.Range(5f, 20f);

            // 更新目标方向
            targetDirection += sign * randomAngle;

            // 保持在0~360°
            targetDirection = Mathf.Repeat(targetDirection, 360f);

            Debug.Log("新的目标风向：" + targetDirection);
        }

        // 平滑旋转到目标方向
        currentDirection = Mathf.MoveTowardsAngle(
            currentDirection,
            targetDirection,
            directionRotateSpeed * Time.deltaTime
        );
    }

    // 更新风速
    void UpdateSpeed()
    {
        speedTimer += Time.deltaTime;

        if (speedTimer >= speedChangeInterval)
        {
            speedTimer = 0;

            targetSpeed += Random.Range(-speedChangeRange, speedChangeRange);

            // 限制风速
            targetSpeed = Mathf.Clamp(targetSpeed, 2f, 8f);
        }

        currentSpeed = Mathf.MoveTowards(
            currentSpeed,
            targetSpeed,
            speedChangeSpeed * Time.deltaTime
        );
    }

    // 返回风向单位向量
    public Vector2 GetWindDirection()
    {
        float rad = currentDirection * Mathf.Deg2Rad;

        return new Vector2(
            Mathf.Cos(rad),
            Mathf.Sin(rad)
        ).normalized;
    }

    // 返回最终风力
    public Vector2 GetWindForce()
    {
        return GetWindDirection() * currentSpeed;
    }
}