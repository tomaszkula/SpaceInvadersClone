using UnityEngine;

public class SI_DieAtHealth : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField] private float healthToDie = 0f;

    [Header("Components")]
    private SI_IDie iDie = null;

    private void Awake()
    {
        iDie = GetComponent<SI_IDie>();
    }

    public void OnHealthUpdated(float _health)
    {
        if(_health <= healthToDie)
        {
            iDie?.Die();
        }
    }
}
