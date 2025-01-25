using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Windows;

public class GameManager : MonoBehaviour
{
    private HUDControl _hud;
    private InputSystem_Actions _input;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _input = new InputSystem_Actions();
        _hud = GameObject.Find("HUD").GetComponent<HUDControl>();
        LoadFarmScene();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LoadFarmScene()
    {
        Debug.Log("starting in farm");
        _hud.DisableFarmButton();
        SceneManager.LoadSceneAsync("FarmScene", LoadSceneMode.Additive);
    }
}
