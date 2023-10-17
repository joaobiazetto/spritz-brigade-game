using UnityEngine;

public class Character : MonoBehaviour
{
    public float maxHealth;
    public float moveSpeed;

    public float currentHealth;

    protected virtual void Awake()
    {
        currentHealth = maxHealth;
    }
}
