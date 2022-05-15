using UnityEngine;

public class SI_Ufo : MonoBehaviour
{
    [Header("Components")]
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
