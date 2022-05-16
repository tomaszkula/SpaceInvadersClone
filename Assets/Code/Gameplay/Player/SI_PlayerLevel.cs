using UnityEngine;

public class SI_PlayerLevel : MonoBehaviour
{
    [Header("Components")]
    private SI_Player player = null;
    private SI_IBounds iBounds = null;

    private void Awake()
    {
        player = GetComponent<SI_Player>();
        iBounds = GetComponent<SI_IBounds>();
    }

    public void OnEnemiesMovedDown(Vector3 _position)
    {
        if (_position.y > iBounds.Bounds.max.y)
        {
            return;
        }

        player.IDie?.Die();
    }
}
