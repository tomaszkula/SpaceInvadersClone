using UnityEngine;
using UnityEngine.InputSystem;

public class SI_InputManager : MonoBehaviour
{
    [Header("Events")]
    [SerializeField] private SI_EventWith1Param<float> onMove = null;
    [SerializeField] private SI_Event onShoot = null;

    private SI_InputData inputData = null;

    private void Awake()
    {
        inputData = new SI_InputData();
        inputData.Enable();
    }

    private void OnEnable()
    {
        inputData.Default.Move.performed += onMoveActionPerformed;
        inputData.Default.Shoot.performed += onShootActionPerformed;
    }

    private void OnDisable()
    {
        inputData.Default.Move.performed -= onMoveActionPerformed;
        inputData.Default.Shoot.performed -= onShootActionPerformed;
    }

    private void onMoveActionPerformed(InputAction.CallbackContext _context)
    {
        float _floatValue = _context.ReadValue<float>();
        onMove?.Invoke(_floatValue);
    }

    private void onShootActionPerformed(InputAction.CallbackContext _context)
    {
        onShoot?.Invoke();
    }
}
