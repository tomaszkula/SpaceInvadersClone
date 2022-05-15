using UnityEngine;
using UnityEngine.UI;

public class SI_LiveUI : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField] private Sprite liveSprite = null;
    [SerializeField] private Sprite noLiveSprite = null;

    [Header("References")]
    [SerializeField] private Image liveImage = null;

    public void Setup(bool _hasLive)
    {
        if(_hasLive)
        {
            liveImage.sprite = liveSprite;
        }
        else
        {
            liveImage.sprite = noLiveSprite;
        }
    }
}
