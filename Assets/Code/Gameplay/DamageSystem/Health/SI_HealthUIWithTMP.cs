using TMPro;
using UnityEngine;

public class SI_HealthUIWithTMP : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private TextMeshProUGUI healthTMP = null;

    public void RefreshHealth(float _health)
    {
        healthTMP.text = $"{_health}";
    }
}
