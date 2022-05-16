using System;
using UnityEngine;

[CreateAssetMenu(fileName = "enemiesWave_NewEnemiesWave", menuName = "Space Invaders/Enemies Wave")]
public class SI_EnemiesWave : ScriptableObject
{
    [Serializable]
    public struct Wave
    {
        public SI_ObjectsPool EnemyObjectsPool;
        public int EnemiesCount;
        public Vector3 PositionOffset;
    }

    public Wave[] Waves = new Wave[0];
    public Vector3 PositionOffset = Vector3.zero;
}
