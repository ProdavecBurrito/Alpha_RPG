using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MainController : MonoBehaviour
{
    public UnityEvent OnGameStateChange;

    [SerializeField] private GameState _gameState;
    [SerializeField] private Camera _mainCamera;

    private InputController _inputController;
    private TurnBasedGameController _turnBasedGameController;

    private List<IUnit> _units = new List<IUnit>();

    private void Awake()
    {
        ChangeGameState(_gameState);
        _mainCamera = Camera.main;
        _inputController = new InputController();
        UpdateManager.AddToUpdate(_inputController);
    }

    private void Update()
    {
        UpdateManager.UpdateAll();
    }

    private void ChangeGameState(GameState gameState)
    {
        switch(gameState)
        {
            case GameState.Battle:
                _turnBasedGameController = new TurnBasedGameController(_units, _mainCamera);
                break;
            case GameState.Exploring:
                break;
        }
        OnGameStateChange?.Invoke();
    }
}
