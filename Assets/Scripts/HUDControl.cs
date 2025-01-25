using UnityEngine;
using UnityEngine.SceneManagement;

public class HUDControl : MonoBehaviour
{
    private InputSystem_Actions _input;
    [SerializeField] private GameObject _farmButton;
    [SerializeField] private GameObject _corgiButton;

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
        _farmButton.SetActive(false);
    }
    public void DisableCorgiButton()
    {
        // todo
        if (_input == null)
        {
            Debug.LogError("HUDControl::InputActions is null");
        }
        Debug.Log("disabling corgi button");
        _corgiButton.SetActive(false);
    }

    //function to switch scene upon button press
    public void SwitchToCorgi()
    {

        Debug.Log("switching to corgi");
        DisableCorgiButton();
        _farmButton.SetActive(true);
        SceneManager.LoadSceneAsync("CorgiScene", LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync("FarmScene");

    }

    public void SwitchToFarm()
    {
        Debug.Log("switching to farm");
        DisableFarmButton();
        EnableCorgiButton();
        SceneManager.LoadSceneAsync("FarmScene",LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync("CorgiScene");
    }
    public void EnableFarmButton()
    {
        _farmButton.SetActive(true);
    }
    public void EnableCorgiButton()
    { 
        _corgiButton.SetActive(true);
    }
}
