using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Windows;
using Resource;

public class GameManager : MonoBehaviour
{
    private HUDControl _hud;
    //private InputSystem_Actions _input;

    private string saveFile = "/Users/Owner/wabaloo.json";
    private ResourceManager _resources;
    private int _currentPlayer;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //_input = new InputSystem_Actions();
        _hud = GameObject.Find("HUD").GetComponent<HUDControl>();
        _resources = ResourceManager.LoadFile(saveFile);
        LoadFarmScene();
        Debug.Log("resources::rubbers " + _resources.GetPlayerRubbers());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public ResourceManager GetResourceManager()
    {
        return _resources;
    }

    public void SaveFile() {
        Debug.Log("saving resources to '" + saveFile + "'");
        _resources.SaveFile(saveFile);
    }

    private void LoadFarmScene()
    {
        Debug.Log("starting in farm");
        _currentPlayer = 0;
        GameObject.Find("PlayerButton").SetActive(false);
        //SceneManager.LoadSceneAsync("FarmScene1", LoadSceneMode.Additive);
    }

    public int GetCurrentPlayer()
    {
        return _currentPlayer;
    }

    public void SetCurrentPlayer(int newPlayer)
    {
        _currentPlayer = newPlayer;
    }
}
