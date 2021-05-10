
using UnityEngine;
using UnityEngine.AI;

public class PlayerInfantryView : BaseUnitView
{
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }
}