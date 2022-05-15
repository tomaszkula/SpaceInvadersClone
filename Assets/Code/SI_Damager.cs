using UnityEngine;

public class SI_Damager : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField] private SI_DamageType damageType = null;
    [SerializeField] private float damage = 0f;

    [Header("Components")]
    private SI_IInflictor iInflictor = null;
    private SI_IAttacker iAttacker = null;

    private void Awake()
    {
        iInflictor = GetComponent<SI_IInflictor>();
        iAttacker = GetComponent<SI_IAttacker>();
    }

    public void Damage(GameObject _target, Vector3 _hitPosition)
    {
        SI_ITakeDamage _iTakeDamage = _target?.GetComponent<SI_ITakeDamage>();
        _iTakeDamage?.TakeDamage(damageType, damage, iInflictor?.Inflictor ?? gameObject, iAttacker?.Attacker ?? gameObject, _hitPosition);
    }
}
