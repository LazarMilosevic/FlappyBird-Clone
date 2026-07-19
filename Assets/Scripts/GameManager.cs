using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    private static bool isRestarting;

    [Header("Canvas")]
    [SerializeField] private GameObject _gameOverCanvas; //whole object with all three canvas
    [SerializeField] private GameObject _startGameCanvas; //whole object with all three canvas
    [SerializeField] private GameObject _score;
    
    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        if (isRestarting)
        {
            isRestarting = false;
            StartGame();
        }
        else
        {
            _startGameCanvas.SetActive(true);
            _gameOverCanvas.SetActive(false);
            _score.SetActive(false);
            Time.timeScale = 0f;
        }
    }

    private void StartGame()
    {
        _startGameCanvas.SetActive(false);
        _score.SetActive(true);
        Time.timeScale = 1f;
    }

    public void GamerOver()
    {
        _gameOverCanvas.SetActive(true);
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        isRestarting = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
    }
}
