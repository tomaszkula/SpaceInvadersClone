using UnityEngine;

public class SI_Shield : MonoBehaviour
{
    public SI_IDie IDie { get; private set; }
    public SI_IBounds IBounds { get; private set; }

    private void Awake()
    {
        IDie = GetComponent<SI_IDie>();
        IBounds = GetComponent<SI_IBounds>();
    }
}
