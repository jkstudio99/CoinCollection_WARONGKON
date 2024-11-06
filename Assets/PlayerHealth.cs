using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    public int damagePerSecond = 10;
    public float invulnerabilityDuration = 2f;
    private bool isInvulnerable = false;

    void Start()
    {
        currentHealth = maxHealth;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DangerZone") && !isInvulnerable)
        {
            StartCoroutine(ApplyDamageOverTime());
        }
    }

    private IEnumerator ApplyDamageOverTime()
    {
        isInvulnerable = true;
        while (isInvulnerable && currentHealth > 0)
        {
            currentHealth -= damagePerSecond;
            Debug.Log("Player Health: " + currentHealth);

            if (currentHealth <= 0)
            {
                Debug.Log("Player is dead!");
                break;
            }

            yield return new WaitForSeconds(1f);
        }

        yield return new WaitForSeconds(invulnerabilityDuration);
        isInvulnerable = false;
    }
}
