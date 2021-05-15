using UnityEngine;
using UnityEngine.AI;

public class PlayerInfantryView : BaseUnitView
{
    private void Awake()
    {
        _unitAnimator = GetComponentInChildren<Animator>();
        _unitNavMeshAgent = GetComponent<NavMeshAgent>();
        _path = new NavMeshPath();
        _meshObstacle = GetComponent<NavMeshObstacle>();
        _unitTransform = GetComponent<Transform>();
        OnSelected(false);
    }
}