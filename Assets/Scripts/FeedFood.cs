using System;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FeedFood : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{

    public GameObject curFood;  // 현재 선택된 음식. 프리팹. sprite 변경으로 화면에 뿌려줌
    public Transform parent;    // 드래그한 food instance 부모인데 굳이 필요한진 모르겠다.
    int foodIdx = 0;    // 얘가 고정이 되었으면 하는디 

    string path = "Food/";

    GameObject instanceFood;
    public Image fullnessBar;
    public TextMeshProUGUI foodCount;

    public GameObject character;

    Food[] Foods;

    private void Start()
    {

        Foods = DataManager.instance.userData.foods;
        print(Resources.Load<Sprite>(path + Foods[foodIdx].name));
        curFood.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(path + Foods[foodIdx].name);

        foodCount.text = "x" + Foods[foodIdx].count.ToString();
    }

    /** 음식 끌어다 주기 */
    public void OnBeginDrag(PointerEventData eventData)
    {
        instanceFood = Instantiate(curFood, parent);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 v = Camera.main.ScreenToWorldPoint(eventData.position);
        v.Set(v.x, v.y, 0);
        instanceFood.transform.position = v;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // Vector3 now = Camera.main.ScreenToWorldPoint(eventData.position); // 드래그 끝나는 지점

        // if (now.x < 1.3 && now.x > -1.3 && now.y > -1.6 && now.y < 1)
        if (RectTransformUtility.RectangleContainsScreenPoint(character.GetComponent<RectTransform>(), Camera.main.ScreenToWorldPoint(eventData.position)))
        {  // 캐릭터한테 준 경우
            if (DataManager.instance.userData.fullness < 1)
            {
                DataManager.instance.userData.fullness = Math.Min(1, DataManager.instance.userData.fullness + Foods[foodIdx].satiety);
                fullnessBar.fillAmount = DataManager.instance.userData.fullness;
                fullnessBar.color = DataManager.instance.userData.fullness < 0.4 ? Color.red : DataManager.instance.userData.fullness < 0.7 ? Color.yellow : Color.green;
                foodCount.text = "x" + (--Foods[foodIdx].count).ToString();
                DataManager.instance.saveFoodData(Foods);
            }
        }
        Destroy(instanceFood);
    }

    /** 음식 선택 */
    public void nextFood()
    {
        foodIdx = Math.Clamp(foodIdx + 1, 0, Foods.Length - 1);
        curFood.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(path + Foods[foodIdx].name);
        foodCount.text = "x" + Foods[foodIdx].count.ToString();

    }

    public void preFood()
    {
        foodIdx = Math.Clamp(foodIdx - 1, 0, Foods.Length - 1);
        curFood.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(path + Foods[foodIdx].name);
        foodCount.text = "x" + Foods[foodIdx].count.ToString();
    }

}
