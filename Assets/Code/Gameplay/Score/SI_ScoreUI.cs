using TMPro;
using UnityEngine;

public class SI_ScoreUI : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private TextMeshProUGUI scoreTMP = null;

    public void RefreshScore(int _score)
    {
        scoreTMP.text = $"{_score}";
    }    
}
