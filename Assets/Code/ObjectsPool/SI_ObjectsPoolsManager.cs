using System.Collections.Generic;
using UnityEngine;

public class SI_ObjectsPoolsManager : MonoBehaviour
{
    [SerializeField] private List<SI_ObjectsPool> objectsPools = new List<SI_ObjectsPool>();

    private void Awake()
    {
        for (int i = 0; i < objectsPools.Count; i++)
        {
            objectsPools[i].Init();
        }
    }
}
