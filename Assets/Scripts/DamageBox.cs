using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBox : MonoBehaviour
{
    public int damage;
    public float timeBetweenHits;
    private float currentTimeBetweenHits;
    private bool readyToHit = true;
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "player")
        {
            if(readyToHit == true)
            {
                other.gameObject.GetComponent<HealthSystem>().TakeDamage(damage);
                readyToHit = false;
            } else
            {
                currentTimeBetweenHits += Time.deltaTime;
            }

            if(currentTimeBetweenHits >= timeBetweenHits)
            {
                readyToHit = true;
                currentTimeBetweenHits = 0;
            }
        }
    }
}
