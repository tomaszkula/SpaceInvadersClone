using UnityEngine;

public class SI_Health : MonoBehaviour, SI_IHealth
{
    [Header("Variables")]
    [SerializeField] private float defaultHealth = 3f;

    private float health = 0f;

    public float Health
    {
        get => health;
        set
        {
            health = value;

            onHealthUpdated?.Invoke(health);
        }
    }

    [Header("Events")]
    [SerializeField] private SI_EventWith1ParamFloat onHealthUpdated = null;

    private void Start()
    {
        Health = defaultHealth;
    }
}
