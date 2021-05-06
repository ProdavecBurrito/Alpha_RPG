using System;
using UnityEngine;

public class InputController : IUpdate
{
    private RaycastHit raycastHit;
    private Ray ray;
    LayerMask _layerMask;

    public InputController ()
    {
        _layerMask = LayerMask.GetMask("Unit");
    }

    public void UpdateTick()
    {
        MouseControll();
    }

    private void MouseControll()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow);
    }
}