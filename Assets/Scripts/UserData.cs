using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

[Serializable]
public class UserData{
    public int coin;
    public float fullness;
    public Food[] foods;

    public static int count = 1;

    public UserData(){
        this.foods = null;
        this.fullness = 0;
        this.coin = 50;
        // Debug.Log("생성자 호출" + count++);
    }

}

