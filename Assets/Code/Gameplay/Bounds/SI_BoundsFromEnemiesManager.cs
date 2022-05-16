using UnityEngine;

public class SI_BoundsFromEnemiesManager : MonoBehaviour, SI_IBounds
{
    [Header("Components")]
    private SI_EnemiesManager enemiesManager = null;

    public Bounds Bounds
    {
        get => getBounds();
        set => throw new System.NotImplementedException();
    }

    private void Awake()
    {
        enemiesManager = GetComponent<SI_EnemiesManager>();
    }

    private Bounds getBounds()
    {
        float _minX = float.MaxValue;
        float _minY = float.MaxValue;

        float _maxX = float.MinValue;
        float _maxY = float.MinValue;

        for (int i = 0; i < enemiesManager.Enemies.Count; i++)
        {
            Bounds _bounds = enemiesManager.Enemies[i].IBounds.Bounds;

            if (_bounds.min.x < _minX)
            {
                _minX = _bounds.min.x;
            }

            if (_bounds.min.y < _minY)
            {
                _minY = _bounds.min.y;
            }

            if (_bounds.max.x > _maxX)
            {
                _maxX = _bounds.max.x;
            }

            if (_bounds.max.y > _maxY)
            {
                _maxY = _bounds.max.y;
            }
        }

        Vector2 _origin = new Vector2(_minX + _maxX, _minY + _maxY) * 0.5f;
        Vector2 _size = new Vector2(_maxX - _minX, _maxY - _minY);
        return new Bounds(_origin, _size);
    }
}
