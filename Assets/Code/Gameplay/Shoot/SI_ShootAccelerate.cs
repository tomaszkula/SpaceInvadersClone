using UnityEngine;
using UnityEngine.Events;

public class SI_ShootAccelerate : MonoBehaviour
{
    [Header("Events")]
    [SerializeField] private UnityEvent<float> onShootAccelerated = null;

    [Header("Components")]
    private SI_IShootDelay iShootDelay = null;

    private void Awake()
    {
        iShootDelay = GetComponent<SI_IShootDelay>();
    }

    public void Accelerate(float _acceleration)
    {
        if (iShootDelay == null)
        {
            return;
        }

        iShootDelay.ShootDelay *= _acceleration;

        onShootAccelerated?.Invoke(_acceleration);
    }
}
