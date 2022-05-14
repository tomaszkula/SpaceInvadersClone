using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SI_MainMenu : MonoBehaviour
{
    private const string GAMEPLAY_SCENE_NAME = "Gameplay";

    [Header("References")]
    [SerializeField] private Button playButton = null;

    private void Awake()
    {
        playButton?.onClick.AddListener(Play);
    }

    public void Play()
    {
        SceneManager.LoadScene(GAMEPLAY_SCENE_NAME);
    }
}
