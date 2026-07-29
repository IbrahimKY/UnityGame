using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    public bool isInAttackingRange = false;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) isInAttackingRange = true;

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) isInAttackingRange = false;
    }

    private void Update()
    {
        if (isInAttackingRange && Pointer.current != null && Pointer.current.press.wasPressedThisFrame)
        {
            Die();
        }
    }


    // Düşmana hasar vermek için bu fonksiyonu çağıracaksın (örneğin oyuncu kılıç sallayınca)
    /*public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            Die();
        }
    }*/

    private void Die()
    {
        Debug.LogWarning("Düşman Öldü.");
        Destroy(gameObject);
    }
}