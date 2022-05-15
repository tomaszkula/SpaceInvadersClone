using UnityEngine;

public class SI_MoveHorizontalFromInput : MonoBehaviour, SI_IMove
{
    [Header("Variables")]
    private float moveInput = 0f;

    [Header("Components")]
    private Transform myTransform = null;
    private SI_IMoveSpeed iMoveSpeed = null;
    private SI_IBounds iBounds = null;

    private void Awake()
    {
        myTransform = transform;
        iMoveSpeed = GetComponent<SI_IMoveSpeed>();
        iBounds = GetComponent<SI_IBounds>();
    }

    public void OnMoveActionPerformed(float _moveInput)
    {
        moveInput = _moveInput;
    }

    public void Move()
    {
        float _moveSpeed = (iMoveSpeed?.MoveSpeed ?? 1f) * Time.deltaTime;
        Vector3 _position = _moveSpeed * moveInput * Vector3.right;

        if (iBounds.Bounds.min.x + _position.x < SI_CameraManager.HorizontalBounds.x)
        {
            _position.x += SI_CameraManager.HorizontalBounds.x - (iBounds.Bounds.min.x + _position.x);
        }
        else if (iBounds.Bounds.max.x + _position.x > SI_CameraManager.HorizontalBounds.y)
        {
            _position.x -= (iBounds.Bounds.max.x + _position.x) - SI_CameraManager.HorizontalBounds.y;
        }

        myTransform.position += _position;
    }
}
