using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] float damage;

    public float projectileSpeed;
    public float projectileLifetime;

    public Transform projectileSpawnPoint;
    public GameObject projectilePrefab;
}
