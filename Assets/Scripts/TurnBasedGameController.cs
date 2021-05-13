using System.Collections.Generic;
using UnityEngine;

public class TurnBasedGameController : IStateController
{
    private List<BaseUnitController> _units;
    private Camera _camera;
    private InputController _inputController;
    private BaseUnitController _currentMovingUnit;

    public TurnBasedGameController(List<BaseUnitController> units, Camera camera, InputController inputController)
    {
        _units = units;
        _camera = camera;
        _inputController = inputController;
        OnUnitTurnEnd();
        foreach (var unit in _units)
        {
            unit.OnTurnEnd += OnUnitTurnEnd;
        }
    }

    public BaseUnitController FindWhosTurn()
    {
        var unitsCount = 0;
        foreach (var unit in _units)
        {
            if (unit.IsActed())
            {
                unitsCount++;
            }
        }
        if (unitsCount == _units.Count)
        {
            ClearActingState();
        }

        BaseUnitController baseUnit = _units[0];
        var maxInitiative = 0;
        foreach (var unit in _units)
        {
            if (unit.UnitModel.Initiative > maxInitiative && !unit.IsActed())
            {
                maxInitiative = unit.UnitModel.Initiative;
                baseUnit = unit;
            }
        }
        UnitTurn(baseUnit);
        return baseUnit;
    }

    public void UnitTurn(BaseUnitController unit)
    {
        unit.GetTurn();
        _inputController.GetActingUnit(unit);
    }

    public void OnUnitTurnEnd()
    {
        _currentMovingUnit = FindWhosTurn();
    }

    public void ClearActingState()
    {
        foreach (var unit in _units)
        {
            Debug.Log("A");
            unit.UnitModel.IsAlreadyActed = false;
        }
    }

    public void AddToActingList(BaseUnitController unit)
    {
        if (!_units.Contains(unit))
        {
            _units.Add(unit);
        }
    }
    
    public void RemoveFromActingList(BaseUnitController unit)
    {
        if (_units.Contains(unit))
        {
            _units.Remove(unit);
        }
    }
}
