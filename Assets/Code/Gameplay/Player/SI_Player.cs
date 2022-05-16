using UnityEngine;

public class SI_Player : MonoBehaviour
{
    private SI_IMove iMove = null;
    private SI_IShoot iShoot = null;
    public SI_IDie IDie { get; private set; }

    private void Awake()
    {
        iMove = GetComponent<SI_IMove>();
        iShoot = GetComponent<SI_IShoot>();
        IDie = GetComponent<SI_IDie>();
    }

    private void Update()
    {
        iMove?.Move();
        iShoot?.Shoot();
    }
}