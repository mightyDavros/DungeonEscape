using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private bool canDamage = true;
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Hit:" + other.name);
        IDamageable hit = other.GetComponent<IDamageable>();

        if (hit!=null && canDamage == true)
        {
            hit.Damage();
            StartCoroutine(CanDamageCooldown());
        }
    }

    IEnumerator CanDamageCooldown()
    {
        canDamage = false;
        yield return new WaitForSeconds(0.5f);
        canDamage = true;
    }
}
