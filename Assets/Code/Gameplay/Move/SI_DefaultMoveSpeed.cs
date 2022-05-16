using UnityEngine;

public class SI_DefaultMoveSpeed : MonoBehaviour, SI_IMoveSpeed
{
    [Header("Variables")]
    [SerializeField] private float defaultMoveSpeed = 1f;

    public float MoveSpeed { get; set; }

    private void Start()
    {
        SetDefaultMoveSpeed();
    }

    public void SetDefaultMoveSpeed()
    {
        MoveSpeed = defaultMoveSpeed;
    }
}
