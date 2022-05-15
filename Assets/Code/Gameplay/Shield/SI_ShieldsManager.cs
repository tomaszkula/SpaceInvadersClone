using System.Collections.Generic;
using UnityEngine;

public class SI_ShieldsManager : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField] private SI_ObjectsPool shieldObjectsPool = null;
    [SerializeField] private int shieldsCount = 4;
    [SerializeField] private Vector3 shieldPositionOffset = Vector3.zero;

    private List<SI_Shield> shields = new List<SI_Shield>();

    [Header("Components")]
    private Transform myTransform = null;

    private void Awake()
    {
        myTransform = transform;

        spawnShields();
    }

    private void spawnShields()
    {
        Vector3 _positionOffset = (shieldsCount - 1) * shieldPositionOffset * 0.5f;

        for (int i = 0; i < shieldsCount; i++)
        {
            SI_Shield _shield = shieldObjectsPool.Get().GetComponent<SI_Shield>();
            _shield.transform.position += myTransform.position + i * shieldPositionOffset - _positionOffset;
            shields.Add(_shield);
        }
    }
}
