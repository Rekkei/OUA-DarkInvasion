using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairController : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public RectTransform crosshair;

    private void Update()
    {
        // BulletSpawnPoint'�n d�nya koordinatlar�n� ekran koordinatlar�na d�n��t�r.
        Vector3 screenPos = Camera.main.WorldToScreenPoint(bulletSpawnPoint.position);

        // Crosshair'in konumunu g�ncelle.
        crosshair.position = screenPos;
    }
}
