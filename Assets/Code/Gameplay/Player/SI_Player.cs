using UnityEngine;

public class SI_Player : MonoBehaviour
{
    private SI_IMove iMove = null;
    private SI_IShoot iShoot = null;

    private void Awake()
    {
        iMove = GetComponent<SI_IMove>();
        iShoot = GetComponent<SI_IShoot>();
    }

    private void Update()
    {
        iMove?.Move();
        iShoot?.Shoot();
    }
}