using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightChange : MonoBehaviour
{
    
    public Sprite lightOn, lightOff;

    public void lightClick(){
        if (GetComponent<SpriteRenderer>().sprite == lightOff)
            GetComponent<SpriteRenderer>().sprite = lightOn;
        else if(GetComponent<SpriteRenderer>().sprite == lightOn)
            GetComponent<SpriteRenderer>().sprite = lightOff;

        print("클릭");
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
