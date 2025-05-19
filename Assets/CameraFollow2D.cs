using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraFollow2D : MonoBehaviour
{
    public Transform target;           // El personaje a seguir
    public float smoothSpeed = 0.125f; // Velocidad de suavizado
    public Vector3 offset;             // Desfase de la cámara (por ejemplo, (0, 0, -10))

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}