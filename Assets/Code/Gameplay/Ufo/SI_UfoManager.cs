using System.Collections.Generic;
using UnityEngine;

public class SI_UfoManager : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField] private SI_ObjectsPool ufoObjectsPool = null;
    [SerializeField] private float ufoSpawnCooldown = 10f;

    private float ufoSpawnTime = 0f;

    [Header("References")]
    [SerializeField] private List<Transform> ufoSpawners = new List<Transform>();

    private void Start()
    {
        ufoSpawnTime = ufoSpawnCooldown;
    }

    private void Update()
    {
        if(ufoSpawnTime > 0f)
        {
            ufoSpawnTime -= Time.deltaTime;
        }
        else
        {
            ufoSpawnTime = ufoSpawnCooldown;

            spawnUfo();
        }
    }

    private void spawnUfo()
    {
        int _ufoSpawnerId = Random.Range(0, ufoSpawners.Count);

        GameObject _ufoInstance = ufoObjectsPool.Get();
        _ufoInstance.transform.SetParent(ufoSpawners[_ufoSpawnerId]);
        _ufoInstance.transform.localPosition = Vector3.zero;
        _ufoInstance.transform.localScale = Vector3.one;
    }
}
