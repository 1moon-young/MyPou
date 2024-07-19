using UnityEngine;
using System.IO;
using System;

public class DataManager : MonoBehaviour
{

    // 싱글톤
    public static DataManager instance;
    string path;
    string filename = "save";

    public UserData userData = new UserData();

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(instance.gameObject);
        DontDestroyOnLoad(this.gameObject);

        path = Application.persistentDataPath;
        print(path);
        initialize();
    }

    void initialize(){
        Food[] foods = new Food[2];
        foods[0] = new Food("pasta", 0.2f, 7, 10);
        foods[1] = new Food("hotdog", 0.15f, 7, 5);
        userData.foods = foods;
    }

    public void saveData(){
        string jsonData = JsonUtility.ToJson(userData, true);
        File.WriteAllText(path + filename, jsonData);
    }

    public void saveFoodData(Food[] foods){
        userData.foods = foods;
        saveData();
    }

    public void loadData(){
        string jsonData = File.ReadAllText(path+filename);
        userData = JsonUtility.FromJson<UserData>(jsonData);
    }

    void Start()
    {   
        saveData();
        loadData();
    }

}
