using UnityEngine;

public class SI_ScoreCallbacks : MonoBehaviour
{
    [Header("Components")]
    private SI_IScore iScore = null;

    private void Awake()
    {
        iScore = GetComponent<SI_IScore>();
    }

    public void OnDeath(GameObject _go)
    {
        if(iScore == null)
        {
            return;
        }

        SI_IScorePerDeath _scorePerDeath = _go?.GetComponent<SI_IScorePerDeath>();

        if(_scorePerDeath == null)
        {
            return;
        }

        iScore.Score += _scorePerDeath.ScorePerDeath;
    }
}
