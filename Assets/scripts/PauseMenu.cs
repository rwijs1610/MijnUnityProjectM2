using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject creditsMenuUI;

    void Start()
    {
        if (pauseMenuUI != null)
        {
            pauseMenuUI.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
     public void Resume()
    {
        if (pauseMenuUI != null)
        {
            pauseMenuUI.SetActive(false);
        }
        Time.timeScale = 1f;
        GameIsPaused = false;
        creditsMenuUI.SetActive(false);
    }
    void Pause()
    {
        if (pauseMenuUI != null)
        {
            pauseMenuUI.SetActive(true);
            Debug.Log("Pause menu activated: " + pauseMenuUI.name + ", Active in hierarchy: " + pauseMenuUI.activeInHierarchy);
        }
        else
        {
            Debug.LogError("PauseMenuUI is not assigned!");
        }
        Time.timeScale = 0f;
        GameIsPaused = true;
        creditsMenuUI.SetActive(false);
    }
    public void LoadMenu()
    {
        Debug.Log("Loading Menu...");
        creditsMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }
    public void QuitGame()
    {
        Debug.Log("Quitting Game...");
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
