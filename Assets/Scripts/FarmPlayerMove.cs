using UnityEngine;
using UnityEngine.InputSystem;

public class FarmPlayerMove : MonoBehaviour
{
    private InputSystem_Actions _input;
    [SerializeField] private float _speed;
    private Vector2 move;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("FarmPlayerMove::Start is running");
        _input = new InputSystem_Actions();
        _input.FarmPlayer.Move.performed += StartWalk;
        _input.FarmPlayer.Move.canceled += StopWalk;
    }

    private void StartWalk(InputAction.CallbackContext context)
    {
        Debug.Log("farm player walking");
        move = _input.FarmPlayer.Move.ReadValue<Vector2>();
    }
    private void StopWalk(InputAction.CallbackContext context)
    {
        Debug.Log("farm player stopped walking");
        move = _input.FarmPlayer.Move.ReadValue<Vector2>();
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
