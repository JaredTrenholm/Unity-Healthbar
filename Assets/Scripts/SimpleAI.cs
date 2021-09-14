using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleAI : MonoBehaviour
{
    public float baseSpeed;
    public int damage;
    private float currentSpeed;
    public float timeBetweenHits;
    private float currentTimeBetweenHits;
    void Update()
    {
        currentSpeed = baseSpeed * Time.deltaTime;
        this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z + currentSpeed);
        if(this.gameObject.GetComponent<SimpleAIHealth>().isAlive == false)
        {
            this.gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "player")
        {
            collision.gameObject.GetComponent<HealthSystem>().TakeDamage(damage);
            this.gameObject.GetComponent<SimpleAIHealth>().TakeDamage(damage);
        }
        baseSpeed *= -1;
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "player")
        {
            if (currentTimeBetweenHits >= timeBetweenHits)
            {
                collision.gameObject.GetComponent<HealthSystem>().TakeDamage(damage);
                this.gameObject.GetComponent<SimpleAIHealth>().TakeDamage(damage);
                currentTimeBetweenHits = 0;
            } else
            {
                currentTimeBetweenHits += Time.deltaTime;
            }
        }
    }
}
