using UnityEngine;

public class SI_MoveForward : MonoBehaviour, SI_IMove
{
    [Header("Variables")]
    [SerializeField] private float moveSpeed = 1f;

    [Header("Components")]
    private Transform myTransform = null;

    private void Awake()
    {
        myTransform = transform;
    }

    public void Move()
    {
        myTransform.position += moveSpeed * Time.deltaTime * myTransform.up;
    }
}
