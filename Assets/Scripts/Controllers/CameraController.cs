using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraController : MonoBehaviour
{
    public GameObject Map;
    public GameObject Player;

    float _moveSpeed = 0.5f;

    [SerializeField]
    float _cameraSize = 5f;

    float _halfSightX;
    float _halfSightY;

    Vector2 _mapSize;
    Vector2 _halfSize;

    Vector2 _cameraRectX;
    Vector2 _cameraRectY;




    void Start()
    {
        _mapSize = Map.GetComponent<Renderer>().bounds.size * 0.5f;
        _halfSightY = _cameraSize;
        _halfSightX = _halfSightY * Camera.main.aspect;

        _cameraRectX = new Vector2(-_mapSize.x + _halfSightX, _mapSize.x - _halfSightX);
        _cameraRectY = new Vector2(-_mapSize.y + _halfSightY, _mapSize.y - _halfSightY);
    }

    private void LateUpdate()
    {
        if(Camera.main.orthographicSize != _cameraSize)
        {
            Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, _cameraSize, _moveSpeed * Time.deltaTime);
        }
        Vector3 dir = Player.transform.position - transform.position;

        transform.position += dir * Time.fixedDeltaTime * _moveSpeed;
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, _cameraRectX.x, _cameraRectX.y),
            Mathf.Clamp(transform.position.y, _cameraRectY.x, _cameraRectY.y),
            -10f
            );
    }
}
