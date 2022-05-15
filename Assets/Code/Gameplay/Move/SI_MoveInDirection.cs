using UnityEngine;

public class SI_MoveInDirection : MonoBehaviour, SI_IMove
{
    [Header("Variables")]
    [SerializeField] private Vector3 moveDirection = Vector3.up;

    [Header("Components")]
    private Transform myTransform = null;
    private SI_IMoveSpeed iMoveSpeed = null;

    private void Awake()
    {
        myTransform = transform;
        iMoveSpeed = GetComponent<SI_IMoveSpeed>();
    }

    public void Move()
    {
        float _moveSpeed = (iMoveSpeed?.MoveSpeed ?? 1f) * Time.deltaTime;
        myTransform.position += _moveSpeed * myTransform.TransformDirection(moveDirection);
    }
}
