using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class FacingCamera : MonoBehaviour
{
    public float rayLength = 10f;
    public float angleOffset = 0f; // Degrees to tweak the facing direction
    public LayerMask collisionMask;

    private LineRenderer lineRenderer;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
        lineRenderer.startWidth = 0.0f;
        lineRenderer.endWidth = 0.5f;
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.startColor = Color.red;
        lineRenderer.endColor = Color.red;
    }

    void Update()
    {
        Vector2 origin = transform.position;

        // Calculate facing direction with offset
        float angle = transform.eulerAngles.z + angleOffset;
        Vector2 direction = AngleToVector2(angle);

        RaycastHit2D hit = Physics2D.Raycast(origin, direction, rayLength, collisionMask);
        Vector2 endPoint = hit.collider ? hit.point : origin + direction * rayLength;

        lineRenderer.SetPosition(0, origin);
        lineRenderer.SetPosition(1, endPoint);

        if (hit.collider)
        {
            OnRayHit(hit.collider, hit.point);
        }
    }

    Vector2 AngleToVector2(float angleDegrees)
    {
        float rad = angleDegrees * Mathf.Deg2Rad;
        return new Vector2(Mathf.Cos(rad), Mathf.Sin(rad)).normalized;
    }

    void OnRayHit(Collider2D collider, Vector2 point)
    {
        // Logic when something is hit
        Debug.Log($"Ray hit {collider.name} at {point}");
    }
}
