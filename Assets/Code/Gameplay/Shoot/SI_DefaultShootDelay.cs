using UnityEngine;

public class SI_DefaultShootDelay : MonoBehaviour, SI_IShootDelay
{
    [Header("Variables")]
    [SerializeField] private float defaultShootDelay = 0.5f;

    public float ShootDelay {get; set; }

    private void Start()
    {
        SetDefaultShootDelay();
    }

    public void SetDefaultShootDelay()
    {
        ShootDelay = defaultShootDelay;
    }
}
