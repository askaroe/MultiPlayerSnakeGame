using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class PlayerController : NetworkBehaviour
{

    private Camera _mainCamera;
    private Vector3 _mouseInput = Vector3.zero;
    [SerializeField]
    private float _speed = 3.0f;
    
    private void Initialize()
    {
        _mainCamera = Camera.main;
    }

    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();
        Initialize();
    }

    private void Update()
    {
        if (!IsOwner || !Application.isFocused) return;
        //Movement
        _mouseInput.x = Input.mousePosition.x;
        _mouseInput.y = Input.mousePosition.y;
        _mouseInput.z = _mainCamera.nearClipPlane;
        Vector3 mouseWorldPosition = _mainCamera.ScreenToWorldPoint(_mouseInput);
        mouseWorldPosition.z = 0f;
        transform.position = Vector3.MoveTowards(transform.position, mouseWorldPosition, 
            Time.deltaTime * _speed);

        //Rotate
        if(mouseWorldPosition != transform.position)
        {
            Vector3 targetDirection = mouseWorldPosition - transform.position;
            targetDirection.z = 0f;
            transform.up = targetDirection;
        }
    }
}
