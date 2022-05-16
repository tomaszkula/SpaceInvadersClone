using UnityEngine;

public class SI_ShieldsLevel : MonoBehaviour
{
    [Header("Components")]
    private SI_ShieldsManager shieldsManager = null;
    private SI_IBounds iBounds = null;

    private void Awake()
    {
        shieldsManager = GetComponent<SI_ShieldsManager>();
        iBounds = GetComponent<SI_IBounds>();
    }

    public void OnEnemiesMovedDown(Vector3 _position)
    {
        if(_position.y > iBounds.Bounds.max.y)
        {
            return;
        }

        for (int i = shieldsManager.Shields.Count - 1; i >= 0; i--)
        {
            shieldsManager.Shields[i].IDie?.Die();
        }
    }
}
