using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SI_ShootFromInput : MonoBehaviour, SI_IShoot
{
    [Header("Variables")]
    [SerializeField] private SI_ObjectsPool bulletObjectsPool = null;
    [SerializeField] private float shootCooldown = 0.5f;

    private bool isShooting = false;
    private float shootTime = 0f;

    [Header("References")]
    [SerializeField] private Transform bulletsSpawner = null;

    private void Update()
    {
        if(shootTime > 0f)
        {
            shootTime -= Time.deltaTime;
        }
    }

    public void OnShootActionStarted()
    {
        isShooting = true;
    }

    public void OnShootActionCanceled()
    {
        isShooting = false;
    }

    public void Shoot()
    {
        if(isShooting && shootTime <= 0f)
        {
            shootTime = shootCooldown;

            GameObject _bulletInstance = bulletObjectsPool.Get();
            _bulletInstance.transform.position = bulletsSpawner.position;
            _bulletInstance.transform.rotation = bulletsSpawner.rotation;
        }
    }
}
