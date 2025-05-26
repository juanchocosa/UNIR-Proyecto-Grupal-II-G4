using UnityEngine;

public class AutoRotate2D : MonoBehaviour
{
    [Header("Rotation Settings")]
    public float minAngle = -45f;      // Minimum rotation angle
    public float maxAngle = 45f;       // Maximum rotation angle
    public float speed = 30f;          // Degrees per second
    public float pauseDuration = 0.5f; // Pause at ends in seconds

    private float currentAngle;
    private bool rotatingForward = true;
    private float pauseTimer = 0f;

    void Update()
    {
        if (pauseTimer > 0f)
        {
            pauseTimer -= Time.deltaTime;
            return;
        }

        float angleStep = speed * Time.deltaTime;

        if (rotatingForward)
        {
            currentAngle += angleStep;
            if (currentAngle >= maxAngle)
            {
                currentAngle = maxAngle;
                rotatingForward = false;
                pauseTimer = pauseDuration;
            }
        }
        else
        {
            currentAngle -= angleStep;
            if (currentAngle <= minAngle)
            {
                currentAngle = minAngle;
                rotatingForward = true;
                pauseTimer = pauseDuration;
            }
        }

        transform.rotation = Quaternion.Euler(0f, 0f, currentAngle);
    }

    void Start()
    {
        currentAngle = transform.eulerAngles.z;
        if (currentAngle > 180f) currentAngle -= 360f; // Normalize angle to -180~180
    }
}
