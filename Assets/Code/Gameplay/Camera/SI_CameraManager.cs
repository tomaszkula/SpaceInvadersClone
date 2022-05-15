using UnityEngine;

public class SI_CameraManager : MonoBehaviour
{
    [Header("Variables")]
    private Vector2 horizontalBounds = Vector2.zero;

    public static Vector2 HorizontalBounds => instance.horizontalBounds;

    [Header("References")]
    [SerializeField] private Camera mainCamera = null;

    [Header("Components")]
    private static SI_CameraManager instance = null;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    private void Start()
    {
        calculateBounds();
    }

    private void calculateBounds()
    {
        Vector3 _bottomLeft = mainCamera.ViewportToWorldPoint(new Vector3(0f, 0f));
        Vector3 _topRight = mainCamera.ViewportToWorldPoint(new Vector3(1f, 1f));

        horizontalBounds = new Vector2(_bottomLeft.x, _topRight.x);
    }
}
