using UnityEngine;

public class SI_Score : MonoBehaviour
{
    [SerializeField] SI_EventWith1Param<int> onScoreUpdated = null;

    private int score = 0;

    public int Score
    {
        get => score;
        set
        {
            if(value == score)
            {
                return;
            }

            score = value;

            onScoreUpdated?.Invoke(score);
        }
    }

    private void Start()
    {
        Score = 0;
    }

    public void AddScore(int _score)
    {
        Score += _score;
    }
}
