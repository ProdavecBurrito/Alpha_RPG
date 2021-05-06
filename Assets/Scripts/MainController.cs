using UnityEngine;
using UnityEngine.Events;

public class MainController : MonoBehaviour
{
    public UnityEvent OnGameStateChange;
    [SerializeField] private GameState GameState;
    private TurnBasedGameController _turnBasedGameController;

    private void Awake()
    {
        GameStateChange(GameState);
    }

    private void Update()
    {
        UpdateManager.UpdateAll();
    }

    private void GameStateChange(GameState gameState)
    {
        switch(gameState)
        {
            case GameState.Battle:
                _turnBasedGameController = new TurnBasedGameController();
                break;
            case GameState.Exploring:
                break;
        }
        OnGameStateChange?.Invoke();
    }
}
