using System.Collections.Generic;
using UnityEngine;

public class SI_HealthUIWithLiveImages : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField] private SI_ObjectsPool liveObjectsPool = null;

    private List<SI_LiveUI> lives = new List<SI_LiveUI>();
    private int currentHealth = 0;
    private int realCurrentHealth = 0;

    [Header("References")]
    [SerializeField] private Transform livesContainer = null;

    public void RefreshMaxHealth(float _maxHealth)
    {
        int _maxHealthToInt = (int)_maxHealth;
        int _maxHealthDifference = _maxHealthToInt - lives.Count;

        if (_maxHealthDifference > 0)
        {
            for (int i = 0; i < _maxHealthDifference; i++)
            {
                SI_LiveUI _live = liveObjectsPool.Get().GetComponent<SI_LiveUI>();
                _live.transform.SetParent(livesContainer);
                _live.transform.localScale = Vector3.one;
                _live.Setup(false);
                lives.Add(_live);
            }

            RefreshHealth(realCurrentHealth);
        }
        else if( _maxHealthDifference < 0)
        {
            for (int i = 0; i > _maxHealthDifference; i--)
            {
                liveObjectsPool.Release(lives[lives.Count - 1].gameObject);
                lives.RemoveAt(lives.Count - 1);
            }
        }
    }

    public void RefreshHealth(float _health)
    {
        int _healthToInt = (int)_health;
        int _healthDifference = _healthToInt - currentHealth;

        if(_healthDifference > 0)
        {
            for (int i = currentHealth; i < _healthToInt && i < lives.Count; i++)
            {
                if (i < 0)
                {
                    continue;
                }

                lives[i].Setup(true);
            }
        }
        else if(_healthDifference < 0)
        {
            for (int i = currentHealth; i >= _healthToInt && i >= 0; i--)
            {
                if(i > lives.Count - 1)
                {
                    continue;
                }

                lives[i].Setup(false);
            }
        }

        currentHealth = Mathf.Clamp(_healthToInt, 0, lives.Count);
        realCurrentHealth = _healthToInt;
    }
}
