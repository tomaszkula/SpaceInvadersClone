using UnityEngine;
using UnityEngine.Events;

public class SI_DefaultDie : MonoBehaviour, SI_IDie
{
    [Header("Events")]
    [SerializeField] private UnityEvent<GameObject> onDeath = null;

    public void Die()
    {
        onDeath?.Invoke(gameObject);
    }
}
