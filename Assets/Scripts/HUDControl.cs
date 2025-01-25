using UnityEngine;
using UnityEngine.SceneManagement;

public class HUDControl : MonoBehaviour
{
    private InputSystem_Actions _input;

    private void OnEnable()
    {
        _input = new InputSystem_Actions();
        Debug.Log("start in hud control called");
    }
  

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisableFarmButton()
    {
        // todo
        if (_input == null)
        {
            Debug.LogError("HUDControl::InputActions is null");
        }
        Debug.Log("disabling farm player button");
    }
    public void DisableCorgiButton()
    {
        // todo
        if (_input == null)
        {
            Debug.LogError("HUDControl::InputActions is null");
        }
        Debug.Log("disabling corgi button");
    }

    //function to switch scene upon button press
    public void SwitchToCorgi()
    {

        Debug.Log("switching to corgi");
        DisableCorgiButton();
        SceneManager.LoadSceneAsync("CorgiScene", LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync("FarmScene");

    }

    public void SwitchToFarm()
    {
        Debug.Log("switching to farm");
        DisableFarmButton();
        SceneManager.LoadSceneAsync("FarmScene",LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync("CorgiScene");
    }
}
