using UnityEngine;

public class SI_Score : MonoBehaviour, SI_IScore
{
    [Header("Variables")]
    private int score = 0;

    public int Score
    {
        get => score;
        set
        {
            if (value == score)
            {
                return;
            }

            score = value;

            onScoreUpdated?.Invoke(score);
        }
    }

    [Header("Events")]
    [SerializeField] private SI_EventWith1Param<int> onScoreUpdated = null;

    private void Start()
    {
        Score = 0;
    }
}
