using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class CharacterSkill : MonoBehaviour
{
    public Transform skillSpawnPoint;
    public GameObject skillPrefab;

    public float skillSpeed = 20;

    private bool canUseSkill = true;
    private bool isManaRefilling = false; // Yeniden dolum i�lemi devam ediyor mu?


    //public float skillCooldown = 3f;
    //private float skillTimer = 0f;

    public Animator _animator;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log(GetComponentInParent<CharacterMana>().currentMana);
            if (canUseSkill)
            {
                Debug.Log("Q tu�una bas�ld�");

                StartCoroutine(ThrowBombWithDelay(2f)); // 2 saniye gecikmeyle bomba atma i�lemini ba�lat�r
                canUseSkill = false;

                // Mana s�f�rlan�r ve a�amal� olarak yenilenmeye ba�lar
                GetComponentInParent<CharacterMana>().currentMana = 0f;
                StartCoroutine(RefillManaOverTime(0.5f, 5f)); // 5 saniyede 20 birim mana yenilenmesi
            }
            else
            {
                Debug.Log("Mana yetersiz.");
            }
        }
    }

    IEnumerator ThrowBombWithDelay(float delay)
    {
        Debug.Log("Bomba at�l�yor.");
        _animator.SetBool("Grenade", true);

        yield return new WaitForSeconds(delay);

        var skill = Instantiate(skillPrefab, skillSpawnPoint.position, skillSpawnPoint.rotation);
        skill.GetComponent<Rigidbody>().velocity = skillSpawnPoint.forward * skillSpeed;

        _animator.SetBool("Grenade", false);
    }


    IEnumerator RefillManaOverTime(float refillDuration, float refillAmount)
    {
        isManaRefilling = true;

        while (isManaRefilling)
        {
            yield return new WaitForSeconds(refillDuration);

            GetComponentInParent<CharacterMana>().currentMana += refillAmount;

            if (GetComponentInParent<CharacterMana>().currentMana >= 100f)
            {
                GetComponentInParent<CharacterMana>().currentMana = 100f;
                isManaRefilling = false;

                // Mana tamamen doldu�unda kontrol edilir ve kullan�ma a��k hale gelir
                canUseSkill = true;
            }
        }
    }
}