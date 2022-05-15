using UnityEngine;

public class SI_Damager : MonoBehaviour
{
    [Header("Components")]
    private Transform myTransform = null;
    private SI_IDamage iDamage = null;

    private void Awake()
    {
        myTransform = transform;
        iDamage = GetComponent<SI_IDamage>();
    }

    private void OnTriggerEnter2D(Collider2D _collision)
    {
        iDamage?.Damage(_collision.gameObject, _collision.ClosestPoint(myTransform.position));
    }
}
