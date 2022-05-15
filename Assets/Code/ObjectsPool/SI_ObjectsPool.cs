using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "objectsPool_NewObjectsPool", menuName = "Space Invaders/Objects Pool")]
public class SI_ObjectsPool : ScriptableObject
{
    [Header("Variables")]
    [SerializeField] private GameObject prefab = null;
    [SerializeField] private int initCount = 0;

    private Queue<GameObject> instances = new Queue<GameObject>();

    public void Init()
    {
        for (int i = 0; i < initCount; i++)
        {
            GameObject _instance = Instantiate(prefab);
            Release(_instance);
        }
    }

    public GameObject Get()
    {
        GameObject _instance = null;

        if(instances.Count > 0)
        {
            _instance = instances.Dequeue();
        }
        else
        {
            _instance = Instantiate(prefab);
        }

        if(_instance == null)
        {
            _instance = Get();
        }

        _instance.SetActive(true);

        return _instance;
    }

    public void Release(GameObject _instance)
    {
        if(_instance == null)
        {
            return;
        }

        _instance.SetActive(false);

        instances.Enqueue(_instance);
    }
}
