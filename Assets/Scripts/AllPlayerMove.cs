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
        UpdateAnimators();
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

    private void UpdateAnimators()
    {
        Animator corgiAnim = _corgiPlayer.GetComponent<Animator>();
        Animator farmPlayerAnim = _farmPlayer.GetComponent<Animator>();
        if (_gm.GetCurrentPlayer() == 0)
        {
            
            corgiAnim.SetBool("isMoving", false);
            

            if (move.x * move.x + move.y * move.y < 0.1f)
            {
                farmPlayerAnim.SetBool("isMoving", false);
            }
            else
            {
                farmPlayerAnim.SetBool("isMoving", true);
                farmPlayerAnim.SetFloat("FarmerX", move.x);
                farmPlayerAnim.SetFloat("FarmerY", move.y);
            }
            //corgiAnim.SetFloat("corgiX", 0.0f);
            //corgiAnim.SetFloat("corgiY", 0.0f);
            //TODO farmerAnim.Set()
        }
        else
        {
            farmPlayerAnim.SetBool("isMoving", false);
            if (move.x * move.x + move.y * move.y < 0.1f)
            {
                corgiAnim.SetBool("isMoving", false);
            }
            else
            {
                corgiAnim.SetBool("isMoving", true);
                corgiAnim.SetFloat("corgiX", move.x);
                corgiAnim.SetFloat("corgiY", move.y);
            }
        }
    }
}
