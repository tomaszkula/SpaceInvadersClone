using UnityEngine;

public class SI_MoveHorizontalFromInput : MonoBehaviour, SI_IMove
{
    [Header("Variables")]
    [SerializeField] private float maxMoveSpeed = 1f;

    private float moveInput = 0f;

    [Header("Components")]
    private Transform myTransform = null;

    private void Awake()
    {
        myTransform = transform;
    }

    public void OnMoveActionPerformed(float _moveInput)
    {
        moveInput = _moveInput;
    }

    public void Move()
    {
        myTransform.position += maxMoveSpeed * moveInput * Time.deltaTime * Vector3.right;
    }
}
