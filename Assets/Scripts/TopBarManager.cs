using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TopBarManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static TopBarManager instance;
    public GameObject coinValue;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(instance.gameObject);
        DontDestroyOnLoad(this.gameObject);
        
    }

    void Start()
    {
        setCoin();
    }

    public void setCoin(){
        int coin = DataManager.instance.userData.coin;
        coinValue.GetComponent<TextMeshProUGUI>().text = "x " + coin;
    }

}
