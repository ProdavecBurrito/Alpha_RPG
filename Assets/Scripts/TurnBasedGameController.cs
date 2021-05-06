using System.Collections.Generic;
using UnityEngine;

public class TurnBasedGameController
{
    private List<IUnit> _units;
    private Camera _camera;

    private IUnit currentMovingUnit;

    public TurnBasedGameController(List<IUnit> units, Camera camera)
    {
        _units = units;
        _camera = camera;
        FindWhosTurn(currentMovingUnit);
        UnitTurn(currentMovingUnit);
    }

    public IUnit FindWhosTurn(IUnit currentUnit)
    {
        var maxInitiative = 0;
        foreach (var unit in _units)
        {
            if (unit.Initiative > maxInitiative && !unit.IsAlreadyActed)
            {
                maxInitiative = unit.Initiative;
                currentUnit = unit;
            }
        }
        return currentUnit;
    }

    public void UnitTurn(IUnit unit)
    {
        unit.IsActing = true;
    }

    public void CrearActingState()
    {
        foreach (var unit in _units)
        {
            unit.IsAlreadyActed = false;
        }
    }

    public void AddToUnits(IUnit unit)
    {
        if (!_units.Contains(unit))
        {
            _units.Add(unit);
        }
    }
    
    public void RemoveFromUnits(IUnit unit)
    {
        if (_units.Contains(unit))
        {
            _units.Remove(unit);
        }
    }
}
