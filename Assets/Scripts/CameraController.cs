using System;
using UnityEngine;

public class CameraController
{
    public event Action OnRotationEnd = delegate () { };

    private const float CAMERA_SPEED = 90.0f;

    private float _offset;
    private Transform _followingObject;
    private Camera _camera;

    public CameraController(Camera camera)
    {
        _offset = -10;
        _camera = camera;
    }

    public void RotateToRight()
    {
        _camera.transform.RotateAround(_followingObject.position, Vector3.up, CAMERA_SPEED * Time.deltaTime);
    }

    public void RotateToLeft()
    {
        _camera.transform.RotateAround(_followingObject.position, -Vector3.up, CAMERA_SPEED * Time.deltaTime);
    }

    public void AssignFollowing(Transform followingObject)
    {
        _followingObject = followingObject;
        _camera.transform.localRotation = new Quaternion(_camera.transform.localRotation.x, 0, 0, _camera.transform.localRotation.w);
        _camera.transform.localPosition = new Vector3(_followingObject.position.x, _camera.transform.position.y, _followingObject.position.z + _offset);
    }
}
