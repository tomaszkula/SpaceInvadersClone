using UnityEngine;

public class SI_ShootFromInput : MonoBehaviour, SI_IShoot
{
    [Header("Variables")]
    [SerializeField] private SI_ObjectsPool bulletObjectsPool = null;

    private bool isShooting = false;
    private float shootCooldown = 0f;

    [Header("References")]
    [SerializeField] private Transform bulletsSpawner = null;

    [Header("Components")]
    private SI_IShootDelay iShootDelay = null;

    private void Awake()
    {
        iShootDelay = GetComponent<SI_IShootDelay>();
    }

    private void Update()
    {
        if(shootCooldown > 0f)
        {
            shootCooldown -= Time.deltaTime;
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
        if(isShooting && shootCooldown <= 0f)
        {
            shootCooldown = iShootDelay?.ShootDelay ?? 1f;

            GameObject _bulletInstance = bulletObjectsPool.Get();
            _bulletInstance.transform.position = bulletsSpawner.position;
            _bulletInstance.transform.rotation = bulletsSpawner.rotation;
        }
    }
}
