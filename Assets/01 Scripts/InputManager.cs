using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : M_MonoBehaviour
{
    private static InputManager _instance;
    public static InputManager Instance => _instance;

    [SerializeField] private bool _isMoving;
    public bool IsMoving => _isMoving;

    protected override void Awake()
    {
        base.Awake();
        if(_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
            return;
        }
        if(_instance.gameObject.GetInstanceID() != this.gameObject.GetInstanceID())
        {
            Destroy(this.gameObject);
        }
    }
    private void Update()
    {
        MovingTracking();
    }
    private void MovingTracking()
    {
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
            _isMoving = true;
        else 
            _isMoving = false;
    }
}
