using UnityEngine;
using UnityEngine.Events;

public class SI_DefaultDamage : MonoBehaviour, SI_IDamage
{
    [Header("Variables")]
    [SerializeField] private SI_DamageType damageType = null;
    [SerializeField] private float damage = 0f;

    [Header("Events")]
    [SerializeField] private UnityEvent<GameObject, GameObject> onDamaged = null;

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

        if(_iTakeDamage == null)
        {
            return;
        }

        bool _didDamage = _iTakeDamage.TakeDamage(damageType, damage, iInflictor?.Inflictor ?? gameObject, iAttacker?.Attacker ?? gameObject, _hitPosition);

        if(_didDamage)
        {
            onDamaged?.Invoke(iInflictor?.Inflictor ?? gameObject, _target);
        }
    }
}
