using UnityEngine;

[CreateAssetMenu(fileName = "enemiesWave_NewEnemiesWave", menuName = "Space Invaders/Enemies Wave")]
public class SI_EnemiesWave : ScriptableObject
{
    public SI_ObjectsPool EnemyObjectsPool = null;
    public int EnemiesCount = 0;
    public Vector3 PositionOffset = Vector3.zero;
}
