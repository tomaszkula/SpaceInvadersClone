using System.Collections.Generic;
using UnityEngine;

public class SI_EnemiesManager : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField] private SI_EnemiesWave enemiesWave = null;

    public List<SI_Enemy> Enemies { get; private set; } = new List<SI_Enemy>();

    [Header("Components")]
    private Transform myTransform = null;
    private SI_IMove iMove = null;
    private SI_IShoot iShoot = null;

    private void Awake()
    {
        myTransform = transform;
        iMove = GetComponent<SI_IMove>();
        iShoot = GetComponent<SI_IShoot>();
    }

    private void Start()
    {
        spawnEnemies();
    }

    private void Update()
    {
        iMove?.Move();
        iShoot?.Shoot();
    }

    public void OnEnemyDeath(GameObject _enemyInstance)
    {
        SI_Enemy _enemy = _enemyInstance?.GetComponent<SI_Enemy>();

        if(_enemy == null)
        {
            return;
        }

        Enemies.Remove(_enemy);
    }

    public void spawnEnemies()
    {
        Vector3 _positionOffset = (enemiesWave.EnemiesCount - 1) * enemiesWave.PositionOffset / 2f;

        for (int i = 0; i < enemiesWave.EnemiesCount; i++)
        {
            SI_Enemy _enemy = enemiesWave.EnemyObjectsPool.Get().GetComponent<SI_Enemy>();
            _enemy.transform.SetParent(myTransform);
            _enemy.transform.position += myTransform.position + i * enemiesWave.PositionOffset - _positionOffset;
            Enemies.Add(_enemy);
        }
    }
}
