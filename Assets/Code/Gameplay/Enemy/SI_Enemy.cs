using UnityEngine;

public class SI_Enemy : MonoBehaviour
{
    public SI_IBounds IBounds { get; private set; }

    private void Awake()
    {
        IBounds = GetComponent<SI_IBounds>();
    }
}
