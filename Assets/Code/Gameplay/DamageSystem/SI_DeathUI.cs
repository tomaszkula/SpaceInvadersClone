using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SI_DeathUI : MonoBehaviour
{
    private const string MAIN_MENU_SCENE = "MainMenu";

    [Header("References")]
    [SerializeField] private float moveToMenuDelay = 3f;

    private WaitForSeconds moveToMenuWaiter = null;

    [Header("References")]
    [SerializeField] private Canvas deathCanvas = null;
    [SerializeField] private TextMeshProUGUI scoreTMP = null;

    private void Awake()
    {
        moveToMenuWaiter = new WaitForSeconds(moveToMenuDelay);
    }

    public void ToggleUI(bool _enabled)
    {
        deathCanvas.enabled = _enabled;

        StartCoroutine(XD());
    }

    public void RefreshScore(int _score)
    {
        scoreTMP.text = $"{_score}";
    }

    private IEnumerator XD()
    {
        yield return moveToMenuWaiter;

        SceneManager.LoadScene(MAIN_MENU_SCENE);
    }
}
