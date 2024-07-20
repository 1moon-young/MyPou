using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Refrigerator : MonoBehaviour
{

    public GameObject refrigerator;
    // public GameObject foodSlot; // 슬롯 인스턴스. 프리팹
    public Transform refrContent; // 부모(content)
    string path = "Food/";
    public GameObject btnRefr;

    RectTransform rect; // 냉장고 목록 위치(바깥 클릭하면 닫히게 할거임)

    // 냉장고 열기
    public void openRefrigerator()
    {
        refrigerator.SetActive(true);
        rect = refrigerator.GetComponent<RectTransform>();

        // 목록 뿌려주기
        DataManager.instance.loadData();
        Food[] foods = DataManager.instance.userData.foods;

        for (int i = 0; i < foods.Length; i++)
        {
            GameObject foodSlot = Instantiate(Resources.Load<GameObject>(path + "foodSlot"));
            // 0:image, 1:name, 2:description, 3:count, 4:cost, 5:option
            foodSlot.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>(path + foods[i].name);
            foodSlot.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = foods[i].name;
            foodSlot.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = foods[i].description;
            foodSlot.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = "x" + foods[i].count.ToString();
            foodSlot.transform.GetChild(4).GetComponent<TextMeshProUGUI>().text = foods[i].cost.ToString();
            // foodSlot.transform.GetChild(5).GetComponent<TextMeshProUGUI>().text = foods[i].cost.ToString();

            // foodSlot.transform.parent = refrContent;
            foodSlot.transform.SetParent(refrContent, false);
            // .setParent()로 worldPositionStays 를 false로 해야 월드 기준이 아닌 로컬 기준으로 크기 방향 설정 해준다고 유니티가 알려줌 미친 개친절
        }
    }

    public void closeRefrigerator()
    {
        refrigerator.SetActive(false);
        foreach (Transform child in refrContent)
            Destroy(child.gameObject);
    }

}
