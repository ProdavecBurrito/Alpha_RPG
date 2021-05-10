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
        _currentMovingUnit = FindWhosTurn(_units);
        UnitTurn(_currentMovingUnit);
        Debug.Log(_currentMovingUnit);
        _inputController.GetActingUnit(_currentMovingUnit);
    }

    public BaseUnitController FindWhosTurn(List<BaseUnitController> baseUnits)
    {
        BaseUnitController baseUnit = baseUnits[0];
        var maxInitiative = 0;
        foreach (var unit in baseUnits)
        {
            if (unit.UnitModel.Initiative > maxInitiative && !unit.UnitModel.IsAlreadyActed)
            {
                maxInitiative = unit.UnitModel.Initiative;
                baseUnit = unit;
            }
        }
        return baseUnit;
    }

    public void UnitTurn(BaseUnitController unit)
    {
        unit.GetTurn();
    }

    public void CrearActingState()
    {
        foreach (var unit in _units)
        {
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
