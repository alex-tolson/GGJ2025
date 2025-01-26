using UnityEngine;
using UnityEngine.InputSystem;


public class CorgiPlayerMove : MonoBehaviour
{
    private InputSystem_Actions _input;
    [SerializeField] private float _speed;
    private Vector2 move;

    void OnEnable()
    {
        Debug.Log("CorgiPlayer::OnEnable");
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

    void Update()
    {
        CalcMove();
    }

    void OnDisable()
    {
        Debug.Log("CorgiPlayerMove::OnDisable");
        _input.CorgiPlayer.Disable();
    }

    private void CalcMove()
    {
        Vector2 dx = move * _speed * Time.deltaTime;
        transform.Translate(dx);
    }


}
