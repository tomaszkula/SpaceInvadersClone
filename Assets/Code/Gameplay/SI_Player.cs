using UnityEngine;

public class SI_Player : MonoBehaviour
{
    private SI_IMove iMove = null;

    private void Update()
    {
        iMove?.Move();
    }
}