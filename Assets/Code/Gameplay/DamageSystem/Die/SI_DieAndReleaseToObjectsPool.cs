using UnityEngine;
using UnityEngine.Events;

public class SI_DieAndReleaseToObjectsPool : MonoBehaviour, SI_IDie
{
    [Header("Variables")]
    [SerializeField] private SI_ObjectsPool objectsPool = null;

    [Header("Events")]
    [SerializeField] private UnityEvent<GameObject> onDeath = null;

    public void Die()
    {
        objectsPool.Release(gameObject);

        onDeath?.Invoke(gameObject);
    }
}
