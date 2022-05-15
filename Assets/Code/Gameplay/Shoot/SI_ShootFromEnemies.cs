using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SI_ShootFromEnemies : MonoBehaviour, SI_IShoot
{
    [Header("Variables")]
    [SerializeField] private float shootDelayFromStart = 3f;
    [SerializeField] private float shootCooldown = 1f;
    [SerializeField] private SI_ObjectsPool bulletObjectsPool = null;

    private bool canShoot = false;
    private float shootTime = 0f;
    private WaitForSeconds waiterFromStart = null;

    [Header("Components")]
    private SI_EnemiesManager enemiesManager = null;

    private void Awake()
    {
        enemiesManager = GetComponent<SI_EnemiesManager>();

        waiterFromStart = new WaitForSeconds(shootDelayFromStart);
    }

    private IEnumerator Start()
    {
        yield return waiterFromStart;
        canShoot = true;
    }

    private void Update()
    {
        if(shootTime > 0f)
        {
            shootTime -= Time.deltaTime;
        }
    }

    public void Shoot()
    {
        if(canShoot == false || shootTime > 0f || enemiesManager.Enemies.Count < 1)
        {
            return;
        }

        shootTime = shootCooldown;

        int _targetId = Random.Range(0, enemiesManager.Enemies.Count);
        GameObject _bulletInstance = bulletObjectsPool.Get();
        _bulletInstance.transform.position = enemiesManager.Enemies[_targetId].transform.position;
        _bulletInstance.transform.rotation = enemiesManager.Enemies[_targetId].transform.rotation * Quaternion.Euler(0f, 0f, 180f);
    }
}
