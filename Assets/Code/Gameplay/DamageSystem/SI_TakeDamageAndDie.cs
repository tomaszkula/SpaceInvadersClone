using System.Collections.Generic;
using UnityEngine;

public class SI_TakeDamageAndDie : MonoBehaviour, SI_ITakeDamage
{
    [Header("Variables")]
    [SerializeField] private List<SI_DamageType> availableDamageTypes = new List<SI_DamageType>();

    [Header("Components")]
    private SI_IDie iDie = null;

    private void Awake()
    {
        iDie = GetComponentInParent<SI_IDie>();
    }

    public bool TakeDamage(SI_DamageType _damageType, float _damage, GameObject _inflictor, GameObject _attacker, Vector3 _hitPosition)
    {
        if(availableDamageTypes.Contains(_damageType) == false)
        {
            return false;
        }

        iDie?.Die();

        return true;
    }
}
