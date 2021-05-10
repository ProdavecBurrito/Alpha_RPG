using UnityEngine;

public class InputController : IUpdate
{
    private RaycastHit _raycastHit;
    private Ray _ray;
    private IUnitController _unit;
    private Camera _mainCamera;
    LayerMask _layerMask;
    LayerMask _ground;

    public InputController(Camera camera)
    {
        _layerMask = LayerMask.GetMask("Unit");
        _ground = LayerMask.GetMask("Ground");
        Debug.Log(_ground.value);
        _mainCamera = camera;
    }

    public void GetActingUnit(IUnitController unitController)
    {
        _unit = unitController;
        Debug.Log(_unit);
    }

    public void UpdateTick()
    {
        MouseControll();
    }

    private void MouseControll()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_unit != null)
            {
                Debug.Log("2");
                _ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
                Debug.DrawRay(_ray.origin, _ray.direction * 10, Color.yellow);
                if (Physics.Raycast(_ray, out _raycastHit, 100, _ground))
                {
                    Debug.Log("3");
                    _unit.Move(_raycastHit.point);
                }
            }
        }
    }
}