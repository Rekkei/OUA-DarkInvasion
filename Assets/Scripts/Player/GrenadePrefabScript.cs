using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadePrefabScript : MonoBehaviour
{
    public float time = 3f;
    public int grenadeDamage = 20;
    public AudioClip grenadeExplosionAudio;
    public GameObject explosionPrefab; // Patlama efekti prefab�

    private void Start()
    {
        StartCoroutine(ExplodeAfterTime(time));
    }

    private IEnumerator ExplodeAfterTime(float delay)
    {
        yield return new WaitForSeconds(delay);
        AudioSource.PlayClipAtPoint(grenadeExplosionAudio, transform.position);

        Collider[] colliders = Physics.OverlapSphere(transform.position, 100f);

        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Enemy"))
            {
                collider.GetComponent<EnemyHealth>().takeDamage(grenadeDamage);
            }
        }

        // Patlama efekti prefab�n� etkinle�tir
        GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(explosion, 3f); // Belirli bir s�re sonra patlama efektini yok et

        Destroy(gameObject);
    }
}
