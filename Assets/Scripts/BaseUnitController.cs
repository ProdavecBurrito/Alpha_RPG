using System;
using UnityEngine;

public abstract class BaseUnitController : IUnitController
{
    public event Action OnTurnEnd = delegate () { };

    protected BaseUnitView _unitView;
    protected BaseUnitModel _unitModel;

    public BaseUnitModel UnitModel => _unitModel;

    public virtual void GetTurn()
    {
       _unitModel.IsActing = true;
    }

    public virtual void EndTurn()
    {
       _unitModel.IsAlreadyActed = true;
        OnTurnEnd.Invoke();
    }

    public virtual void Move(Vector3 direction)
    {
        Debug.Log("Move");
        _unitView.NavMeshAgent.SetDestination(direction);
    }

    public virtual void Attack()
    {
        throw new System.NotImplementedException();
    }
}
