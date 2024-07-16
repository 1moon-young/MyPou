using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FeedFood : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{

    public GameObject curFood; 
    public Transform parent;
    public Sprite[] foods;
    int foodIdx = 0;

    GameObject instanceFood;

    /** 음식 끌어다 주기 */
    public void OnBeginDrag(PointerEventData eventData)
    {
        instanceFood = Instantiate(curFood, parent);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 v = Camera.main.ScreenToWorldPoint(eventData.position);
        v.Set(v.x,v.y,0);
        instanceFood.transform.position = v;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Destroy(instanceFood);
    }


    /** 음식 선택 */
    public void nextFood(){
        foodIdx = Math.Clamp(foodIdx+1, 0, foods.Length-1);
        curFood.GetComponent<SpriteRenderer>().sprite = foods[foodIdx];
    }

    public void preFood(){
        foodIdx = Math.Clamp(foodIdx-1, 0, foods.Length-1);
        curFood.GetComponent<SpriteRenderer>().sprite = foods[foodIdx];
    }

}
