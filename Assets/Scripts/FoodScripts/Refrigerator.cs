using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Refrigerator : MonoBehaviour
{

    public GameObject refrigerator;
    // public GameObject foodSlot; // 슬롯 인스턴스. 프리팹
    public Transform refrContent; // 부모(content)
    string path = "Food/";
    public GameObject btnRefr;
    Food[] foods;

    // 냉장고 열기
    public void openRefrigerator()
    {
        refrigerator.SetActive(true);

        // 목록 뿌려주기
        DataManager.instance.loadData();
        foods = DataManager.instance.userData.foods;

        for (int i = 0; i < foods.Length; i++)
        {
            GameObject foodSlot = Instantiate(Resources.Load<GameObject>(path + "foodSlot"));
            // 0:image, 1:name, 2:description, 3:count, 4:cost, 5:option
            foodSlot.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>(path + foods[i].name);
            foodSlot.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = foods[i].name;
            foodSlot.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = foods[i].description;
            foodSlot.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = "x" + foods[i].count.ToString();
            foodSlot.transform.GetChild(4).GetChild(1).GetComponent<TextMeshProUGUI>().text = foods[i].cost.ToString();
            // foodSlot.transform.GetChild(5).GetComponent<TextMeshProUGUI>().text = foods[i].cost.ToString();

            foodSlot.transform.GetChild(6).GetComponent<Text>().text = foods[i].idx.ToString();

            foodSlot.transform.SetParent(refrContent, false);
            // worldPositionStays = false 로 해야 월드 기준이 아닌 로컬 기준으로
        }
    }

    public void closeRefrigerator()
    {
        refrigerator.SetActive(false);
        foreach (Transform child in refrContent)
            Destroy(child.gameObject);
    }

}
