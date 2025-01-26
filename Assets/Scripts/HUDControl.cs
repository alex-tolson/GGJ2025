using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Resource;

public class HUDControl : MonoBehaviour
{
    //private InputSystem_Actions _input;
    [SerializeField] private GameObject _farmButton;
    [SerializeField] private GameObject _corgiButton;
    [SerializeField] private TMP_Text _wabalooNumber;
    [SerializeField] private TMP_Text _rubberNumber;

    private GameManager _gm;

    private void OnEnable()
    {
        //_input = new InputSystem_Actions();
        _gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        Debug.Log("start in hud control called");
    }


    // Update is called once per frame
    void Update()
    {
        ResourceManager r = _gm.GetResourceManager();
        _wabalooNumber.SetText(r.GetPlayerWabaloos().ToString());
        _rubberNumber.SetText(r.GetPlayerRubbers().ToString());
    }

    public void SaveGame()
    {
        _gm.SaveFile();
    }

    //function to switch scene upon button press
    public void SwitchToCorgi()
    {

        Debug.Log("switching to corgi");
        _gm.SetCurrentPlayer(1);
        _farmButton.SetActive(true);
        _corgiButton.SetActive(false);
    }

    public void SwitchToFarm()
    {
        Debug.Log("switching to farm");
        _gm.SetCurrentPlayer(0);
        _corgiButton.SetActive(true);
        _farmButton.SetActive(false);

    }

}
