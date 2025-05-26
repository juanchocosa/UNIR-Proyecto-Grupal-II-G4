using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(LineRenderer))]
public class VisionCone2D : MonoBehaviour
{
    [Header("Ray Settings")]
    public float rayLength = 10f;
    public LayerMask collisionMask;
    public bool fixedCamera = false;
    public Vector2 fixedDirection = Vector2.up;

    [Header("Line Appearance")]
    public float startWidth = 0.0f;
    public float endWidth = 0.5f;

    [Header("Alarm Settings")]
    public float alarmCooldown = 1.0f;

    private LineRenderer lineRenderer;
    private Vector2 lastPosition;
    private Vector2 movementDirection;
    private int alarmCounter = 0;
    private float alarmTimer = 0f;
    private RaycastHit2D hit;
    private Vector2 endPoint;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
        lineRenderer.startWidth = startWidth;
        lineRenderer.endWidth = endWidth;
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.startColor = Color.red;
        lineRenderer.endColor = Color.red;

        lastPosition = transform.position;
    }

    void Update()
    {
        Vector2 currentPosition = transform.position;
        movementDirection = (currentPosition - lastPosition).normalized;
        lastPosition = currentPosition;

        //Vector2 direction = fixedCamera ? fixedDirection.normalized : movementDirection;
        Vector2 direction = fixedCamera ? (Vector2)transform.up : movementDirection;

        if (direction != Vector2.zero)
        {
            hit = Physics2D.Raycast(currentPosition, direction, rayLength, collisionMask);
            endPoint = hit.collider ? hit.point : currentPosition + direction * rayLength;

            lineRenderer.SetPosition(0, currentPosition);
            lineRenderer.SetPosition(1, endPoint);

            if (hit.collider)
            {
                OnRayHit(hit.collider, hit.point);
            }
        }
        else
        {
            lineRenderer.SetPosition(0, currentPosition);
            lineRenderer.SetPosition(1, currentPosition); // Hide the ray
        }

        if (alarmTimer > 0)
            alarmTimer -= Time.deltaTime;
    }

    void OnRayHit(Collider2D collider, Vector2 point)
    {
        if (collider.CompareTag("Player") && alarmTimer <= 0f)
        {
            /*
            alarmCounter++;
            alarmTimer = alarmCooldown;
            Debug.Log("Alerta: " + alarmCounter);

            if (alarmCounter >= maxAlarmCount)
            {
                Debug.Log("¡ALERTA! El jugador ha sido detectado demasiadas veces.");
                alarmCounter = 0;
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            */
            AlarmManager.Instance.AddAlarm(1);
        }
    }
}



/*
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(LineRenderer))]
public class VisionCone2D : MonoBehaviour
{
    public float rayLength = 10f;
    public LayerMask collisionMask;
    public bool fixedCamera = false; // If true, the ray will not update its direction based on movement
    public float startWidth = 0.0f; // Start width of the ray
    public float endWidth = 0.5f; // End width of the ray

    private LineRenderer lineRenderer;
    private Vector2 lastPosition;
    private Vector2 movementDirection;
    private int alarmCounter = 0;
    const int maxAlarmCount = 1000; // Maximum number of times the alarm can be triggered
    private RaycastHit2D hit;
    private Vector2 endPoint;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
        lineRenderer.startWidth = startWidth;
        lineRenderer.endWidth = endWidth;
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.startColor = UnityEngine.Color.red;
        lineRenderer.endColor = UnityEngine.Color.red;

        lastPosition = transform.position;
    }

    void Update()
    {
        Vector2 currentPosition = transform.position;
        movementDirection = (currentPosition - lastPosition).normalized;
        lastPosition = currentPosition;

        if (movementDirection != Vector2.zero || fixedCamera)
        {
            //Debug.Log("Raycasting from: " + currentPosition + " in direction: " + (fixedCamera ? "left" : movementDirection));

            
            hit = Physics2D.Raycast(currentPosition, movementDirection, rayLength, collisionMask);
            endPoint = hit.collider ? hit.point : currentPosition + movementDirection * rayLength;
        

            lineRenderer.SetPosition(0, currentPosition);
            lineRenderer.SetPosition(1, endPoint);

            if (hit.collider)
            {
                OnRayHit(hit.collider, hit.point);
            }
        }
        else
        {
            // If not moving and camera is not fixed, we can hide the ray
            lineRenderer.SetPosition(0, currentPosition);
            lineRenderer.SetPosition(1, currentPosition); // Hide the ray
        }
    }

    void OnRayHit(Collider2D collider, Vector2 point)
    {
        // Debug.Log(collider.name + " detected at point: " + point);
        if (collider.tag == "Player")
        {
            alarmCounter++;
            Debug.Log("Alerta: " + alarmCounter);

            if (alarmCounter >= maxAlarmCount)
            {
                // Trigger alarm logic here
                Debug.Log("¡ALERTA! El jugador ha sido detectado demasiadas veces.");
                // Reset the counter or implement further logic as needed
                alarmCounter = 0; // Reset the counter after triggering the alarm
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

    }
}
*/