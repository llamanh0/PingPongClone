using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI playerOneScoreText;
    [SerializeField] private TextMeshProUGUI playerTwoScoreText;

    private int _playerOneScore;
    private int _playerTwoScore;

    private void Start()
    {
        _playerOneScore = int.Parse(playerOneScoreText.text);
        _playerTwoScore = int.Parse(playerTwoScoreText.text);
    }

    private void OnEnable()
    {
        Goal.OnScoreChanged += HandleScoreChange;
    }

    private void OnDisable()
    {
        Goal.OnScoreChanged -= HandleScoreChange;
    }

    private void HandleScoreChange(Player player)
    {
        if (player == Player.One)
        {
            _playerOneScore++;
            playerOneScoreText.text = _playerOneScore.ToString();
            if (_playerOneScore == GameManager.Instance.WinConditionNumber)
            {
                GameManager.Instance.UpdateState(GameState.End);
            }
        }
        else // Player Two
        {
            _playerTwoScore++;
            playerTwoScoreText.text = _playerTwoScore.ToString();
            if (_playerOneScore == GameManager.Instance.WinConditionNumber)
            {
                GameManager.Instance.UpdateState(GameState.End);
            }
        }
    }
}
