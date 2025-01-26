using UnityEngine;
using Resource;

public class Interactable : MonoBehaviour
{
    [SerializeField] private bool _getMoney;
    [SerializeField] private bool _getRubber;
    [SerializeField] private bool _getWater;
    private GameManager _gm;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _gm = GameObject.Find("GameManager").GetComponent<GameManager>();
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ResourceManager resource = _gm.GetResourceManager();

            if (_getWater == true)
            {
                
                Debug.Log("resource " + resource);
                int oldrubber = resource.GetPlayerRubbers();
                
                if (oldrubber > 0)
                {
                    Debug.Log("Spending a rubber to create a Wabaloo");
                    int oldwater = resource.GetPlayerWabaloos();
                    resource.SetPlayerWabaloos(oldwater + 1);
                    resource.SetPlayerRubbers(oldrubber - 1);
                }
 
            }

            else if(_getRubber)
            {
                Debug.Log("Collecing rubbers");
                int oldrubbers = resource.GetPlayerRubbers();
                resource.SetPlayerRubbers(oldrubbers + 1);

                
            }
            else if(_getMoney)
            {
                Debug.Log("Collecting Money");
                int oldmoney = resource.GetPlayerMoney();
                resource.SetPlayerMoney(oldmoney + 1);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (this.CompareTag("Money") && other.CompareTag("Player"))
        {
            _getMoney = true;
        }

        if (this.CompareTag("Rubber") && other.CompareTag("Player"))
        {
            _getRubber = true;
        }

        if (this.CompareTag("Water") && other.CompareTag("Player"))
        {
            _getWater = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {

        if (this.CompareTag("Money") && other.CompareTag("Player"))
        {
            _getMoney = false;
        }

        if (this.CompareTag("Rubber") && other.CompareTag("Player"))
        {
            _getRubber = false;
        }

        if (this.CompareTag("Water") && other.CompareTag("Player"))
        {
            _getWater = false;
        }
    }
    //if tag is money and other is player
    //collect 1-4 resources
    //10 second cooldown

}
