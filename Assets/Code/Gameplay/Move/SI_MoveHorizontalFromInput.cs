using UnityEngine;

public class SI_MoveHorizontalFromInput : MonoBehaviour, SI_IMove
{
    [Header("Variables")]
    [SerializeField] private float maxMoveSpeed = 1f;

    private float moveInput = 0f;

    [Header("Components")]
    private Transform myTransform = null;
    private SI_IMoveSpeed iMoveSpeed = null;

    private void Awake()
    {
        myTransform = transform;
        iMoveSpeed = GetComponent<SI_IMoveSpeed>();
    }

    public void OnMoveActionPerformed(float _moveInput)
    {
        moveInput = _moveInput;
    }

    public void Move()
    {
        float _moveSpeed = (iMoveSpeed?.MoveSpeed ?? 1f) * Time.deltaTime;
        myTransform.position += _moveSpeed * moveInput * Vector3.right;
    }
}
