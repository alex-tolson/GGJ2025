using UnityEngine;
using UnityEngine.InputSystem;


public class CorgiPlayerMove : MonoBehaviour
{
    private InputSystem_Actions _input;
    [SerializeField] private float _speed;
    private Vector2 move;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _input = new InputSystem_Actions();
        _input.CorgiPlayer.Move.performed += StartWalk;
        _input.CorgiPlayer.Move.canceled += StopWalk;
    }

    private void StartWalk(InputAction.CallbackContext context)
    {
        Debug.Log("corgi player walking");
        move = _input.CorgiPlayer.Move.ReadValue<Vector2>();
    }
    private void StopWalk(InputAction.CallbackContext context)
    {
        Debug.Log("corgi player stopped walking");
        move = _input.CorgiPlayer.Move.ReadValue<Vector2>();
    }

    // Update is called once per frame
    void Update()
    {
        CalcMove();
    }

    private void CalcMove()
    {
        Vector2 dx = move * _speed * Time.deltaTime;
        transform.Translate(dx);
    }
}
