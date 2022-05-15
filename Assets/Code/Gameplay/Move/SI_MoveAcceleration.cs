using UnityEngine;

public class SI_MoveAcceleration : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField] private float acceleration = 1.1f;

    [Header("Components")]
    private SI_IMoveSpeed iMoveSpeed = null;

    private void Awake()
    {
        iMoveSpeed = GetComponent<SI_IMoveSpeed>();
    }

    public void Accelerate()
    {
        if(iMoveSpeed == null)
        {
            return;
        }

        iMoveSpeed.MoveSpeed *= acceleration;
    }
}
