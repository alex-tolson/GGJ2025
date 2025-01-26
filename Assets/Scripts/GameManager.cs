using System;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEngine.Windows;
using Resource;

public class GameManager : MonoBehaviour
{
    private HUDControl _hud;
    //private InputSystem_Actions _input;

    // linux and mac, make a dot folder

    //private string saveFile = "/Users/pavan/wabaloo.json";
    private string _ResourceManagerFile; 
    private string _SaveFolder;
    //private string saveFile;
    private ResourceManager _resources;
    private int _currentPlayer;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InitSaveFolder();
        InitResourceManager();
        //_input = new InputSystem_Actions();
        _hud = GameObject.Find("HUD").GetComponent<HUDControl>();
        // TODO: see if the file exisits, if it dosn't then create it uses the save function, otherwise load it.
        //_resources = ResourceManager.LoadFile(saveFile); // 
        LoadFarmScene();
        Debug.Log("resources::rubbers " + _resources.GetPlayerRubbers());
        
    }

    private void InitSaveFolder()
    {
        // figure out what os we're on
        // and then make a save folder in the way that the system is ok with 
        string currentOS = SystemInfo.operatingSystem;
        if(currentOS.Contains("Linux") || currentOS.Contains("Mac"))
        {
            Debug.Log("Mac or Linux detected");
            // if we're under Linux we can use the enviromental variable for HOME to find the home folder
            // We can then create a . folder to dump all our save data in 
            string HomePath = System.Environment.GetEnvironmentVariable("HOME");
            _SaveFolder = $"{HomePath}/.wabaloo"; 
        }
        else if(currentOS.Contains("Windows"))
        {
            Debug.Log("Windows detected");
            // This is a windows specsific way to return stuff under Windows 
            //string systemFolderPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.System);
            //Debug.Log($"System folder path: {systemFolderPath}"); 
            // if we're on windows we need to find the app data and roaming folders
            string roamingAppData = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData);
            string localAppData = System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData);
            Debug.Log($"roamingAppData folder: {roamingAppData}, localAppData: {localAppData}");
            _SaveFolder = Path.Combine(roamingAppData,"wabaloo");
        }
        else
        {
            Debug.Log("Unsupported Platform :(");
            _SaveFolder = "/tmp/wabaloo"; // if we don't know what platform we're on, maybe we'll have temp?
            Debug.Log("Unknown platform, saving to /tmp/wabaloo");
        }

        this.MakeSaveFolder();
    }


    private void MakeSaveFolder()
    {
        // figure out if the save folder exisits, and create if it not
        if(!Directory.Exists(_SaveFolder))
        {
            Directory.CreateDirectory(_SaveFolder);
            Debug.Log($"Created folder at: {_SaveFolder}");
        }
        else
        {
            // folder already exisits
            Debug.Log($"Found save folder at: {_SaveFolder}");
        }
    }

    private void InitResourceManager()
    {
        _ResourceManagerFile = $"{_SaveFolder}/resourcemanager.json"; 

        // check to see if a save file dose not exist
        // if the file already exists then we don't need to do anything
        if(!File.Exists(_ResourceManagerFile))
        {
            //this.SaveFile(); // create a save file at our save file path
            Debug.Log("saving resources to '" + _ResourceManagerFile + "'");
           // _resources.SaveFile(saveFile);
            _resources = new ResourceManager();
            _resources.SetPlayerWabaloos(0);
            _resources.SetPlayerRubbers(0);
            _resources.SaveFile(_ResourceManagerFile);
        }
        else
        {
            // if the file exists then just load file 
           _resources = ResourceManager.LoadFile(_ResourceManagerFile); 
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    public ResourceManager GetResourceManager()
    {
        return _resources;
    }

    public void SaveAllFiles() {
        this.MakeSaveFolder();
        Debug.Log("saving resources to '" + _ResourceManagerFile + "'");
        _resources.SaveFile(_ResourceManagerFile);
        // TODO: Add tree manager save file
        // TODO: 
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
