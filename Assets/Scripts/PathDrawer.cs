using UnityEngine;
using UnityEngine.AI;

public class PathDrawer
{
	public NavMeshAgent _agent;
	public LineRenderer _lineRenderer;
	public NavMeshPath _meshPath;

	public PathDrawer()
	{
		_lineRenderer = ResourceLoader.LoadAndInstantiateObject<LineRenderer>("Prefabs/Line");
		//UpdateManager.SubscribeToUpdate(UpdateTick);
	}

	public void Draw()
	{
		if (_agent != null)
		{
			_lineRenderer.positionCount = _meshPath.corners.Length + 1;
			_lineRenderer.SetPosition(0, _agent.gameObject.transform.position);
			for (int i = 0; i < _meshPath.corners.Length; i++)
			{
				_lineRenderer.SetPosition(i + 1, _meshPath.corners[i]);
			}
		}
	}

	public void GetAgent(NavMeshAgent agent, NavMeshPath navMeshPath)
    {
		_agent = agent;
		_meshPath = navMeshPath;
    }
}
