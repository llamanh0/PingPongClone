using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameState CurrentState {  get; private set; }
    
    public static event Action<GameState> OnStateChanged;

    [SerializeField] private GameObject ballPrefab;

    public int WinConditionNumber = 5;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        UpdateState(GameState.Start);
    }

    /// <summary>
    /// Oyun durumunu gunceller ve
    /// <see cref="OnStateChanged" href=" = State Degistiginde Ateslenen Event"/>i Invoke eder.
    /// </summary>
    /// <param name="state"></param>
    public void UpdateState(GameState state)
    {
        //if (CurrentState == state) return;
        //CurrentState = state;

        HandleStateChange(state);
        OnStateChanged?.Invoke(state);
    }


    private void HandleStateChange(GameState state)
    {
        switch (state)
        {
            case GameState.Start:
                Instantiate(ballPrefab);
                break;
            case GameState.Score:
                Instantiate(ballPrefab);
                break;
            case GameState.Pause:
                Time.timeScale = 0;
                break;
            case GameState.End:
                Time.timeScale = 0;
                break;
            default:
                break;
        }
    }
}
