using UnityEngine;

public class SI_MaxHealth : MonoBehaviour, SI_IMaxHealth
{
    [Header("Variables")]
    [SerializeField] private float defaultMaxHealth = 3f;

    [Header("Events")]
    [SerializeField] private SI_EventWith1Param<float> onMaxHealthUpdated = null;

    private float maxHealth = 0f;

    public float MaxHealth
    {
        get => maxHealth;
        private set
        {
            maxHealth = value;

            onMaxHealthUpdated?.Invoke(maxHealth);
        }
    }

    private void Start()
    {
        MaxHealth = defaultMaxHealth;
    }
}
