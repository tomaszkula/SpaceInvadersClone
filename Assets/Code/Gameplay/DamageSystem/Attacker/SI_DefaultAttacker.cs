using UnityEngine;

public class SI_DefaultAttacker : MonoBehaviour, SI_IAttacker
{
    [Header("Variables")]
    [SerializeField] private GameObject defaultAttacker = null;

    public GameObject Attacker { get; set; }

    private void Start()
    {
        Attacker = defaultAttacker;
    }
}
