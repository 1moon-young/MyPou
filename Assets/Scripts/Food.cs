using System;
using UnityEngine;

[Serializable]
public class Food{
    public string name;
    public float satiety; // 포만도
    public int cost; // 가격
    public int count; // 남은 개수

    public Food(string name, float satiety, int cost, int count=0){
        this.name = name;
        this.satiety = satiety;
        this.cost = cost;
        this.count = count;
    }
}
