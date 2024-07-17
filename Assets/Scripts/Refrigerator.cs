using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Refrigerator : MonoBehaviour
{

    public GameObject refrigerator;
    public GameObject[] foodSlots;
    bool isOpend;

    void Start()
    {
        isOpend = false;
    }

    public void openRefrigerator(){
        refrigerator.SetActive(true);
        isOpend = true;
    }

     public void closeRefrigerator(){
        refrigerator.SetActive(false);
        isOpend = false;
    }

    // 바깥 클릭하면 꺼지게 하기.

    // Update is called once per frame
    void Update()
    {
        
    }
}
