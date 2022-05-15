using UnityEngine;

public class SI_DefaultInflictor : MonoBehaviour, SI_IInflictor
{
    [Header("Variables")]
    [SerializeField] private GameObject defaultInflictor = null;

    public GameObject Inflictor { get; set; }

    private void Start()
    {
        Inflictor = defaultInflictor;
    }
}
