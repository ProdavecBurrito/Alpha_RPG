using System;
using UnityEngine;

public class InputController : IUpdate
{
    private RaycastHit _raycastHit;
    private Ray _ray;
    private BaseUnitController _unit;
    private Camera _mainCamera;
    private CameraController _cameraController;
    LayerMask _unitMask;
    LayerMask _groundMask;

    public InputController(Camera camera)
    {
        _unitMask = LayerMask.GetMask("Unit");
        _groundMask = LayerMask.GetMask("Ground");
        _mainCamera = camera;
        _cameraController = new CameraController(_mainCamera);
    }

    public void GetActingUnit(BaseUnitController unitController)
    {
        _unit = unitController;
        _cameraController.AssignFollowing(_unit.UnitView.transform);
    }

    public void UpdateTick()
    {
        MouseControll();
        RotateCamera();
    }

    private void MouseControll()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_unit != null)
            {
                _ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(_ray, out _raycastHit, 100, _groundMask))
                {
                    _unit.Move(_raycastHit.point);
                }
            }
        }
    }

    public void RotateCamera()
    {
        RotateToRight();
        RotateToLeft();
    }

    private void RotateToLeft()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            UpdateManager.SubscribeToUpdate(_cameraController.RotateToLeft);
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            UpdateManager.UnsubscribefromUpdate(_cameraController.RotateToLeft);
        }
    }

    private void RotateToRight()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            UpdateManager.SubscribeToUpdate(_cameraController.RotateToRight);
        }
        if (Input.GetKeyUp(KeyCode.Q))
        {
            UpdateManager.UnsubscribefromUpdate(_cameraController.RotateToRight);
        }
    }
}