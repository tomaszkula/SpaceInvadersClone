using UnityEngine;

public class SI_Player : MonoBehaviour
{
    private SI_IMove iMove = null;

    private void Awake()
    {
        iMove = GetComponent<SI_IMove>();
    }

    private void Update()
    {
        iMove?.Move();
    }
}