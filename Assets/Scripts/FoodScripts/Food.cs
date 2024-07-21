using System;
using UnityEngine;

[Serializable]
public class Food{
    public int idx;
    public static int idx_s = 0;
    public string name;
    public string description;
    public float satiety; // 포만도
    public int cost; // 가격
    public int count; // 남은 개수

    public Food(string name, string description, float satiety, int cost, int count=0){
        this.name = name;
        this.description = description;
        this.satiety = satiety;
        this.cost = cost;
        this.count = count;
        this.idx = idx_s++;
    }
}
