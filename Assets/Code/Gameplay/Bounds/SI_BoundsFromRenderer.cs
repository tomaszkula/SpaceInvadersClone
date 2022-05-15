using UnityEngine;

public class SI_BoundsFromRenderer : MonoBehaviour, SI_IBounds
{
    [Header("References")]
    [SerializeField] private Renderer rendererForBounds = null;

    public Bounds Bounds
    {
        get => rendererForBounds.bounds;
        set => throw new System.NotImplementedException();
    }
}
