using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    public float maxHealth;
    public bool isAlive;
    public Text healthCounter;
    public Image healthBar;
    public Image damagedHealthBar;
    public float damagedHealthBarSpeed;
    private float currentHealth;
    private float originalHealthBarWidth;
    private void Start()
    {
        currentHealth = maxHealth;
        originalHealthBarWidth = healthBar.rectTransform.sizeDelta.x;
        isAlive = true;
    }
    private void Update()
    {
        healthBar.rectTransform.sizeDelta = new Vector2(originalHealthBarWidth * (currentHealth / maxHealth), healthBar.rectTransform.sizeDelta.y);
        healthCounter.text = currentHealth + " / " + maxHealth;
        SetColor();
        if (healthBar.rectTransform.sizeDelta.x < damagedHealthBar.rectTransform.sizeDelta.x)
        {
            damagedHealthBar.rectTransform.sizeDelta = new Vector2(damagedHealthBar.rectTransform.sizeDelta.x - (damagedHealthBarSpeed * Time.deltaTime), healthBar.rectTransform.sizeDelta.y);
        } else if (healthBar.rectTransform.sizeDelta.x > damagedHealthBar.rectTransform.sizeDelta.x)
        {
            damagedHealthBar.rectTransform.sizeDelta = healthBar.rectTransform.sizeDelta;
        }
    }

    private void SetColor()
    {
        if ((currentHealth/maxHealth)*100 >= 80)
        {
            healthBar.color = Color.green;
        } else if ((currentHealth / maxHealth) * 100 >= 50)
        {
            healthBar.color = Color.yellow;
        }
        else
        {
            healthBar.color = Color.red;
        }
    }

    public void TakeDamage(int damage)
    {
        if (damage >= currentHealth)
        {
            currentHealth = 0;
            isAlive = false;
        }
        else
        {
            currentHealth -= damage;
        }
    }

    public void Heal(int heal)
    {
        if (heal + currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        else
        {
            currentHealth += heal;
            if(isAlive == false && currentHealth > 0)
            {
                isAlive = true;
            }
        }
    }
}
