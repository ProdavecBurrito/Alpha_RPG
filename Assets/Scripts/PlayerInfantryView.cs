using UnityEngine;
using UnityEngine.AI;

public class PlayerInfantryView : BaseUnitView
{
    private void Awake()
    {
        OnSelected(false);
        _unitAnimator = GetComponentInChildren<Animator>();
        _unitNavMeshAgent = GetComponent<NavMeshAgent>();
        _unitTransform = GetComponent<Transform>();
    }
}