using System.Collections.Generic;
using UnityEngine;

public class SI_EnemiesManager : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField] private SI_EnemiesWave enemiesWave = null;

    public List<SI_Enemy> Enemies { get; private set; } = new List<SI_Enemy>();

    [Header("Components")]
    private SI_IShoot iShoot = null;

    private void Awake()
    {
        iShoot = GetComponent<SI_IShoot>();
    }

    private void Start()
    {
        SpawnEnemiesWave();
    }

    private void Update()
    {
        iShoot?.Shoot();
    }

    public void SpawnEnemiesWave()
    {
        float _xOffset = (enemiesWave.EnemiesCount - 1) * enemiesWave.PositionOffset.x / 2f;

        for (int i = 0; i < enemiesWave.EnemiesCount; i++)
        {
            SI_Enemy _enemy = enemiesWave.EnemyObjectsPool.Get().GetComponent<SI_Enemy>();
            _enemy.transform.position += i * enemiesWave.PositionOffset - new Vector3(_xOffset, 0f, 0f);
            Enemies.Add(_enemy);
        }
    }
}
