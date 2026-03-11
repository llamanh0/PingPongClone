using System;
using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField] Player player;

    [Header("Referances")]
    [SerializeField] private Collider2D _col;

    public static event Action<Player> OnScoreChanged;

    private void Awake()
    {
        _col = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Ball"))
        {
            OnScoreChanged?.Invoke(player);
            Destroy(other.gameObject);
            GameManager.Instance.UpdateState(GameState.Score);
        }
    }
}
