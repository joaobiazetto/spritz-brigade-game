using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public float damage;

    public float projectileSpeed;
    public float projectileLifetime;

    public Transform projectileSpawnPoint;
    public GameObject projectilePrefab;
}
