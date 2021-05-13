using UnityEngine.AI;
using UnityEngine;

public abstract class BaseUnitView : MonoBehaviour
{
    [SerializeField] private GameObject _selected;

    protected Animator _unitAnimator;
    protected NavMeshAgent _unitNavMeshAgent;
    protected Transform _unitTransform;

    public NavMeshAgent UnitNavMeshAgent => _unitNavMeshAgent;
    public Animator UnitAnimator => _unitAnimator;
    public Transform UnitTransform => _unitTransform;

    public void OnSelected(bool isSelected)
    {
        _selected.SetActive(isSelected);
    }
}
