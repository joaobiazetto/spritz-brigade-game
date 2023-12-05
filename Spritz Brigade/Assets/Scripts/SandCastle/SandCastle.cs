using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandCastle : MonoBehaviour
{
    public int maxHealth = 50;
    public float currentHealth;

    protected virtual void Awake()
    {
        currentHealth = maxHealth;
    }
}
