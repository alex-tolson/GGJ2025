using UnityEngine;
using UnityEngine.Windows;

public class CameraMov : MonoBehaviour
{
    [SerializeField] private Transform _player;
    private Vector3 _position;
    [SerializeField] float _speed;
    [SerializeField] private GameObject _topLeft;
    [SerializeField] private GameObject _bottomRight;
    private InputSystem_Actions _input;
    private GameManager _gm;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable()
    {
        _gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        _input = new InputSystem_Actions();
        WhosePlaying();
    }

    // Update is called once per frame
    void Update()
    {
        WhosePlaying();
        MoveCamera();
    }

    public void MoveCamera()
    {
        float posX = Mathf.Clamp(_player.transform.position.x, _topLeft.transform.position.x,_bottomRight.transform.position.x);
        float posY = Mathf.Clamp(_player.transform.position.y, _bottomRight.transform.position.y, _topLeft.transform.position.y);
        _position = new Vector3(posX, posY, -10);
        //Debug.Log("posX is " + posX + " and posY is " + posY);
        transform.position = Vector3.Lerp(transform.position, _position, _speed);
    }

    public void WhosePlaying()
    {
        int currentPlayer = _gm.GetCurrentPlayer();
        if (currentPlayer == 0)
        {
            
            _player = GameObject.Find("Player").GetComponent<Transform>();
        }
        else
        {
            _player = GameObject.Find("CorgiPlayer").GetComponent<Transform>();
        }
        //Debug.Log(currentPlayer + "  current Player ");
    }
}
