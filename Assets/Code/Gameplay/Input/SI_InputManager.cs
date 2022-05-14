using UnityEngine;
using UnityEngine.InputSystem;

public class SI_InputManager : MonoBehaviour
{
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

    }

    private void onShootActionPerformed(InputAction.CallbackContext _context)
    {

    }
}
