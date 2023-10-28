using UnityEngine;

public class Character : MonoBehaviour
{
    [Header("Character Settings")]
    public float maxHealth;
    public float moveSpeed;
    public float currentHealth;

    protected virtual void Awake()
    {
        currentHealth = maxHealth;
    }
}
