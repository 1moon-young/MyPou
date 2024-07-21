using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class FoodShop : MonoBehaviour
{
    public GameObject foodSlot;
    // public GameObject coinValue;

    public void buyFood(){
        // 0:image, 1:name, 2:description, 3:count, 4:cost, 5:option
        int idx = int.Parse(foodSlot.transform.GetChild(6).GetComponent<Text>().text);
        
        foreach ( Food a in DataManager.instance.userData.foods){
            print(a);
        }
        DataManager.instance.userData.coin -= DataManager.instance.userData.foods[idx].cost;

        Debug.Log(DataManager.instance.userData.foods[idx].count + "전");
        DataManager.instance.userData.foods[idx].count++;
        Debug.Log(DataManager.instance.userData.foods[idx].count + "후");

        foodSlot.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = "x" + DataManager.instance.userData.foods[idx].count.ToString();
        // coinValue.GetComponent<TextMeshProUGUI>().text = "x " + DataManager.instance.userData.coin;

        DataManager.instance.saveData();
        TopBarManager.instance.setCoin();
        FeedFood.instance.loadFood();
        // foodSlot.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text
    }

}
