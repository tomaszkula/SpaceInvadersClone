using UnityEngine;
using UnityEngine.Events;

public class SI_MoveAcceleration : MonoBehaviour
{
    [Header("Events")]
    [SerializeField] private UnityEvent<float> onMoveAccelerated = null;

    [Header("Components")]
    private SI_IMoveSpeed iMoveSpeed = null;

    private void Awake()
    {
        iMoveSpeed = GetComponent<SI_IMoveSpeed>();
    }

    public void Accelerate(float _acceleration)
    {
        if(iMoveSpeed == null)
        {
            return;
        }

        iMoveSpeed.MoveSpeed *= _acceleration;

        onMoveAccelerated?.Invoke(_acceleration);
    }
}
