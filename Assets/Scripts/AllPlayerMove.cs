using UnityEngine;
using UnityEngine.InputSystem;

public class AllPlayerMove : MonoBehaviour
{
    private InputSystem_Actions _input;
    [SerializeField] private float _speed;
    [SerializeField] private GameObject _farmPlayer;
    [SerializeField] private GameObject _corgiPlayer;
    private GameManager _gm;
    private Vector2 move;

    void OnEnable()
    {
        _gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        Debug.Log("FarmPlayerMove::OnEnable");
        _input = new InputSystem_Actions();
        _input.AllPlayer.Enable();
        _input.AllPlayer.Move.performed += StartWalk;
        _input.AllPlayer.Move.canceled += StopWalk;
    }

    private void StartWalk(InputAction.CallbackContext context)
    {
        
        move = _input.AllPlayer.Move.ReadValue<Vector2>();
        if(_gm.GetCurrentPlayer()==0)
        {
            Debug.Log("farm player walking");
        }
        else
        {
            Debug.Log("corgi player walking");
        }
    }
    private void StopWalk(InputAction.CallbackContext context)
    {
        move = _input.AllPlayer.Move.ReadValue<Vector2>();
        if (_gm.GetCurrentPlayer() == 0)
        {
            Debug.Log("farm player stopped walking");
        }
        else
        {
            Debug.Log("corgi player stopped walking");
        }
    }

    void Update()
    {
        CalcMove();
    }

    private void CalcMove()
    {
        Vector2 dx = move * _speed * Time.deltaTime;
        
        if (_gm.GetCurrentPlayer() == 0)
        {
            _farmPlayer.transform.Translate(dx);


        }
        else
        {
            _corgiPlayer.transform.Translate(dx);
        }
    }
}
