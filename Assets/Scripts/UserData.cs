using System;

[Serializable]
public class UserData{
    public int coin;
    public float fullness;
    public Food[] foods;

    public UserData(){
        foods = null;
        fullness = 0;
        coin = 0;
    }
}

