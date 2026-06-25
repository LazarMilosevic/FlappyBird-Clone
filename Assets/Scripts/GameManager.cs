using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private GameObject _gameOverCanvas; //whole object with all three canvas


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        Time.timeScale = 1f; //default value ingameTime relative to realTime
    }

    public void GamerOver()
    {
        _gameOverCanvas.SetActive(true); //show on call

        Time.timeScale = 0f; //ingameTime stops
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
    }
}
