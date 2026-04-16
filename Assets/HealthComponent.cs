using System;
using System.Collections;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    public int maxHealth = 100;
    public float invincibilityTime = 2f;
    private bool canReciveDamage = true;
    private float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }
    
    public void ReceiveDamage(float amount)
    {
        if (canReciveDamage)
        {
            canReciveDamage = false;
            currentHealth -= amount;
            StartCoroutine(RunInvincibilityTimer(invincibilityTime, RefreshInvincibility));
            Debug.Log(currentHealth);
        }
    }

    public void AddHealth(float amount)
    {
        currentHealth += amount;
        Debug.Log(currentHealth);
    }

    IEnumerator RunInvincibilityTimer(float waitTime, Action callback)
    {
        yield return new WaitForSeconds(waitTime);
        callback.Invoke();
    }

    private void RefreshInvincibility()
    {
        canReciveDamage = true;
        Debug.Log("Reset");
    }
}
