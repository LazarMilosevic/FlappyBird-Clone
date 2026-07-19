using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    [SerializeField] private TextMeshProUGUI _currentScoreValue;
    [SerializeField] private TextMeshProUGUI _highScoreValue;

    private int _score = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        _currentScoreValue.text = _score.ToString();

        _highScoreValue.text = PlayerPrefs.GetInt("HighScoreValue").ToString();
    }

    private void UpdateHighScore()
    {
        if (_score > PlayerPrefs.GetInt("HighScoreValue"))
        {
            PlayerPrefs.SetInt("HighScoreValue", _score);
            _highScoreValue.text = _score.ToString();
        }
    }

    public void UpdateScore()
    {
        _score++;
        _currentScoreValue.text = _score.ToString();
        UpdateHighScore();
    }
}
