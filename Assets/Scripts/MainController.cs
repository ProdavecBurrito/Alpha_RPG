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
    private IStateController _currentStateController;

    [SerializeField] private List<BaseUnitController> _units = new List<BaseUnitController>();

    private void Start()
    {
        _mainCamera = Camera.main;
        _inputController = new InputController(_mainCamera);
        UpdateManager.AddToUpdate(_inputController);
        _units.Add(UnitFactory.CreateUnit(PlayerUnitType.Infantry));
        ChangeGameState(_gameState);
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
                if (_turnBasedGameController == null)
                {
                    _turnBasedGameController = new TurnBasedGameController(_units, _mainCamera, _inputController);
                }
                _currentStateController = _turnBasedGameController;
                break;
            case GameState.Exploring:
                break;
        }
        OnGameStateChange?.Invoke();
    }
}
