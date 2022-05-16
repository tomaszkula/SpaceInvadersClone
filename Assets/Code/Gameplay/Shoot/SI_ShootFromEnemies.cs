using System.Collections;
using UnityEngine;

public class SI_ShootFromEnemies : MonoBehaviour, SI_IShoot
{
    [Header("Variables")]
    [SerializeField] private float shootDelayFromStart = 3f;
    [SerializeField] private SI_ObjectsPool bulletObjectsPool = null;

    private bool canShoot = false;
    private float shootCooldown = 0f;
    private WaitForSeconds waiterFromStart = null;

    [Header("Components")]
    private SI_EnemiesManager enemiesManager = null;
    private SI_IShootDelay iShootDelay = null;

    private void Awake()
    {
        enemiesManager = GetComponent<SI_EnemiesManager>();
        iShootDelay = GetComponent<SI_IShootDelay>();

        waiterFromStart = new WaitForSeconds(shootDelayFromStart);
    }

    private void Start()
    {
        Init();
    }

    private void Update()
    {
        if(shootCooldown > 0f)
        {
            shootCooldown -= Time.deltaTime;
        }
    }

    public void Init()
    {
        canShoot = false;
        shootCooldown = 0f;

        StartCoroutine(init());
    }

    public void Shoot()
    {
        if(canShoot == false || shootCooldown > 0f || enemiesManager.Enemies.Count < 1)
        {
            return;
        }

        shootCooldown = iShootDelay?.ShootDelay ?? 1f;

        int _targetId = Random.Range(0, enemiesManager.Enemies.Count);
        GameObject _bulletInstance = bulletObjectsPool.Get();
        _bulletInstance.transform.position = enemiesManager.Enemies[_targetId].transform.position;
        _bulletInstance.transform.rotation = enemiesManager.Enemies[_targetId].transform.rotation * Quaternion.Euler(0f, 0f, 180f);
    }

    private IEnumerator init()
    {
        yield return waiterFromStart;
        canShoot = true;
    }
}
