using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    [SerializeField]
    private Camera mainCamera;

    public UnityEvent OnShoot = new UnityEvent();
    public UnityEvent OnShootMine = new UnityEvent();
    public UnityEvent<Vector2> OnMoveBody = new UnityEvent<Vector2>();
    public UnityEvent<Vector2> OnMoveTurret = new UnityEvent<Vector2>();

    // Start is called before the first frame update
    void Start()
    {
       if (mainCamera == null){
        mainCamera = Camera.main;
       }
    }

    // Update is called once per frame
    void Update()
    {
       GetBodyMovement(); 
       GetTurretMovement(); 
       GetShootingMovement(); 
    }

    private void GetBodyMovement()
    {
        Vector2 movementVector = new Vector2(Input.GetAxisRaw("Vertical"), Input.GetAxisRaw("Horizontal"));
        OnMoveBody?.Invoke(movementVector.normalized);
        print(movementVector.normalized);
    }

    private void GetTurretMovement()
    {
        OnMoveTurret?.Invoke(GetMousePosition());
    }

    private Vector2 GetMousePosition()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = mainCamera.nearClipPlane;
        Vector2 mouseWorldPosition = mainCamera.ScreenToWorldPoint(mousePosition);
        return mouseWorldPosition;
    }

    private void GetShootingMovement()
    {
        if(Input.GetMouseButtonDown(0))
        {
            OnShoot?.Invoke();
        }
        else if(Input.GetMouseButtonDown(1))
        {
            OnShootMine?.Invoke();
        }
    }
}
