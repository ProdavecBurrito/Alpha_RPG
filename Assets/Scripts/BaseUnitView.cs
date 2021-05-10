using UnityEngine.AI;
using UnityEngine;

public abstract class BaseUnitView : MonoBehaviour
{
    protected Animator _animator;
    protected NavMeshAgent _navMeshAgent;
    protected Transform _transform;
    public NavMeshAgent NavMeshAgent => _navMeshAgent;
}
