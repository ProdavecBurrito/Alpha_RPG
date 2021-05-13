﻿using System;
using UnityEngine;

public abstract class BaseUnitController : IUnitController
{
    public event Action OnTurnEnd = delegate () { };

    protected UnitAnimationsController _animationController;
    protected BaseUnitView _unitView;
    protected BaseUnitModel _unitModel;

    public BaseUnitController()
    {
        _animationController = new UnitAnimationsController();
    }

    public BaseUnitModel UnitModel => _unitModel;

    public BaseUnitView UnitView => _unitView;

    public virtual void GetTurn()
    {
       _unitModel.IsActing = true;
        _unitModel.CurrentActionPoints = _unitModel.StartActionPoints;
        _unitView.OnSelected(true);
    }

    public virtual void EndTurn()
    {
       _unitModel.IsAlreadyActed = true;
        _unitView.OnSelected(false);
        OnTurnEnd.Invoke();
    }

    public virtual void Move(Vector3 direction)
    {
        _unitView.UnitNavMeshAgent.SetDestination(direction);
        ReduceActionPoints(_unitModel.MovementPointsValue);
    }

    public virtual void Attack()
    {
        throw new System.NotImplementedException();
    }

    public void CheckSpeed()
    {
        _animationController.CheckWalkState(_unitView.UnitNavMeshAgent.hasPath);
    }

    public void ReduceActionPoints(int value)
    {
        _unitModel.CurrentActionPoints -= value;
        if (_unitModel.CurrentActionPoints < 0)
        {
            _unitModel.CurrentActionPoints = 0;
        }
        CheckEndTurn(_unitModel.CurrentActionPoints);
    }

    public void CheckEndTurn(int value)
    {
        if (value == 0)
        {
            _unitModel.IsAlreadyActed = true;
            _unitModel.IsActing = false;
            EndTurn();
        }
    }

    public bool IsActed()
    {
        return _unitModel.IsAlreadyActed;
    }
}
