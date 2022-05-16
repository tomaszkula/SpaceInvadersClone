using System.Collections.Generic;
using UnityEngine;

public class SI_ShieldsManager : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField] private SI_ObjectsPool shieldObjectsPool = null;
    [SerializeField] private int shieldsCount = 4;
    [SerializeField] private Vector3 shieldPositionOffset = Vector3.zero;

    public List<SI_Shield> Shields { get; private set; } = new List<SI_Shield>();

    [Header("Components")]
    private Transform myTransform = null;

    private void Awake()
    {
        myTransform = transform;

        spawnShields();
    }

    public void OnShieldDestroyed(GameObject _shieldInstance)
    {
        SI_Shield _shield = _shieldInstance?.GetComponent<SI_Shield>();

        if(_shield == null)
        {
            return;
        }

        Shields.Remove(_shield);
    }

    private void spawnShields()
    {
        Vector3 _positionOffset = (shieldsCount - 1) * shieldPositionOffset * 0.5f;

        for (int i = 0; i < shieldsCount; i++)
        {
            SI_Shield _shield = shieldObjectsPool.Get().GetComponent<SI_Shield>();
            _shield.transform.position += myTransform.position + i * shieldPositionOffset - _positionOffset;
            Shields.Add(_shield);
        }
    }
}
