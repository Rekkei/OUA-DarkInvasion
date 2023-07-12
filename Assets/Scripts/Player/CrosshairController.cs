using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrosshairController : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public Transform crosshair;

    void Update()
    {
        // Mermi ate�leme y�n�n� hesapla
        Vector3 fireDirection = bulletSpawnPoint.forward + bulletSpawnPoint.up * Mathf.Tan(Mathf.Deg2Rad * (15f - Camera.main.transform.eulerAngles.x));

        // Mermi spawn noktas�n�n pozisyonunu g�ncelle
        bulletSpawnPoint.position = crosshair.position;

        // Mermi ate�leme y�n�n� g�ncelle
        bulletSpawnPoint.rotation = Quaternion.LookRotation(fireDirection, Vector3.up);
    }
}