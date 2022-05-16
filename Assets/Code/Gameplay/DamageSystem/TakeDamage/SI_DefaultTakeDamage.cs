using System.Collections.Generic;
using UnityEngine;

public class SI_DefaultTakeDamage : MonoBehaviour, SI_ITakeDamage
{
    [Header("Variables")]
    [SerializeField] private List<SI_DamageType> killDamageTypes = new List<SI_DamageType>();
    [SerializeField] private List<SI_DamageType> normalDamageTypes = new List<SI_DamageType>();

    [Header("Components")]
    private SI_IHealth iHealth = null;

    private void Awake()
    {
        iHealth = GetComponentInParent<SI_IHealth>();
    }

    public bool TakeDamage(SI_DamageType _damageType, float _damage, GameObject _inflictor, GameObject _attacker, Vector3 _hitPosition)
    {
        if(iHealth == null)
        {
            return false;
        }

        if (killDamageTypes.Contains(_damageType))
        {
            iHealth.Health -= iHealth.Health;
            return true;
        }
        else if (normalDamageTypes.Contains(_damageType))
        {
            iHealth.Health -= _damage;
            return true;
        }
        else
        {
            return false;
        }
    }
}
