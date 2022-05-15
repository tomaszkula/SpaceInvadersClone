using UnityEngine;

public class SI_ScorePerDeath : MonoBehaviour, SI_IScorePerDeath
{
    [SerializeField] private int defaultScorePerDeath = 0;

    public int ScorePerDeath { get; set; }

    private void Start()
    {
        ScorePerDeath = defaultScorePerDeath;
    }
}
