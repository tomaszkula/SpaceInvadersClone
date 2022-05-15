using UnityEngine;

public class SI_Die : MonoBehaviour, SI_IDie
{
    [Header("Events")]
    [SerializeField] private SI_EventWith1Param<GameObject> onDeath = null;

    public void Die()
    {
        onDeath?.Invoke(gameObject);
    }
}
