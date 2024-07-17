using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FeedFood : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{

    public GameObject curFood; 
    public Transform parent;
    public Sprite[] foods;
    float[] satiety;  // 음식 별 포만도
    int[] foodCounts; // 남은 음식 개수
    int foodIdx = 0;

    GameObject instanceFood;
    public Image fullnessBar;
    public TextMeshProUGUI foodCount;

    private void Start() {
        // 임시 초기화 코드
        satiety = new float[foods.Length];
        satiety[0] = 0.2f;
        satiety[1] = 0.3f;

        foodCounts = new int[foods.Length];
        foodCounts[0] = 10;
        foodCounts[1] = 8;

        foodCount.text = "x" + foodCounts[foodIdx].ToString();
    }

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
        Vector3 now = Camera.main.ScreenToWorldPoint(eventData.position); // 드래그 끝나는 지점

        if (now.x < 1.3 && now.x > -1.3 && now.y > -1.6 && now.y < 1){  // 캐릭터한테 준 경우
            if(CharacterManager.fullness < 1){
                CharacterManager.fullness = Math.Min(1, CharacterManager.fullness + satiety[foodIdx]);
                fullnessBar.fillAmount = CharacterManager.fullness;
                fullnessBar.color = CharacterManager.fullness < 0.4 ? Color.red : CharacterManager.fullness < 0.7 ? Color.yellow : Color.green;
                foodCount.text = "x" + (--foodCounts[foodIdx]).ToString();
            }    
        }
        Destroy(instanceFood);
    }

    /** 음식 선택 */
    public void nextFood(){
        foodIdx = Math.Clamp(foodIdx+1, 0, foods.Length-1);
        curFood.GetComponent<SpriteRenderer>().sprite = foods[foodIdx];
        foodCount.text = "x" + foodCounts[foodIdx].ToString();
    }

    public void preFood(){
        foodIdx = Math.Clamp(foodIdx-1, 0, foods.Length-1);
        curFood.GetComponent<SpriteRenderer>().sprite = foods[foodIdx];
        foodCount.text = "x" + foodCounts[foodIdx].ToString();
    }

}
