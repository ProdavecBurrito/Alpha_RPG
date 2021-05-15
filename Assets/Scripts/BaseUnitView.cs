using UnityEngine.AI;
using UnityEngine;

public abstract class BaseUnitView : MonoBehaviour
{
    [SerializeField] private MeshRenderer _selected;

    protected Animator _unitAnimator;
    protected NavMeshAgent _unitNavMeshAgent;
    protected NavMeshObstacle _meshObstacle;
    protected Transform _unitTransform;
    public NavMeshPath _path;
    public NavMeshAgent UnitNavMeshAgent => _unitNavMeshAgent;
    public Animator UnitAnimator => _unitAnimator;
    public Transform UnitTransform => _unitTransform;

    public void OnSelected(bool isSelected)
    {
        _selected.enabled = isSelected;
        _meshObstacle.enabled = !isSelected;
        _unitNavMeshAgent.enabled = isSelected;
    }

    public void CalculatePath(Vector3 target)
    {
        if( _unitNavMeshAgent.CalculatePath(target, _path))
        {
            Debug.Log(_path.corners.Length);
        }
    }
}
