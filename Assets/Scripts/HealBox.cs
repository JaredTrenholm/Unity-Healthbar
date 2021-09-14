using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealBox : MonoBehaviour
{
    public float timeBetweenHeals;
    public int heal;
    private float currentTimeBetweenHeals;
    private bool readyToHeal = true;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "player")
        {
            if (readyToHeal == true)
            {
                other.gameObject.GetComponent<HealthSystem>().Heal(heal);
                readyToHeal = false;
            }
            else
            {
                currentTimeBetweenHeals += Time.deltaTime;
            }

            if (currentTimeBetweenHeals >= timeBetweenHeals)
            {
                readyToHeal = true;
                currentTimeBetweenHeals = 0;
            }
        }
    }
}
