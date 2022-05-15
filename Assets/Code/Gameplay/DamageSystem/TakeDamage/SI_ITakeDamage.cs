using UnityEngine;

public interface SI_ITakeDamage
{
    bool TakeDamage(SI_DamageType _damageType, float _damage, GameObject _inflictor, GameObject _attacker, Vector3 _hitPosition);
}
