using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
[RequireComponent(typeof(PlayerInput))]
public class DumbPlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector2 moveVector;
    [SerializeField] private float speed = 5f;
    private UnityEngine.InputSystem.PlayerInput _playerInput;

    private void Start()
    {
        _playerInput = GetComponent<UnityEngine.InputSystem.PlayerInput>();
        _playerInput.actions["Move"].performed += (val) => moveVector = val.ReadValue<Vector2>();
        _playerInput.actions["Move"].canceled += (val) => moveVector = val.ReadValue<Vector2>();
       // _playerInput.Enable();
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        this.transform.Translate(new Vector3(moveVector.x, 0, moveVector.y) * speed * Time.fixedDeltaTime);
    }
}
