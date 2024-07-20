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
        Food[] foods = new Food[3];
        foods[0] = new Food("pasta", "싸구려 파스타면과 시판 토마토 소스로 만들었다.", 0.2f, 7, 10);
        foods[1] = new Food("hotdog", "싸구려 소시지에 반죽을 감아 튀겨낸 핫도그. 설탕을 묻히고 케찹과 머스타드를 뿌렸다.", 0.15f, 5, 5);
        foods[2] = new Food("gangyebab", "꼬슬한 밥 위에 반숙 후라이를 얹고 간장, 참기름을 둘렀다. 숟가락으로 팍팍 비벼먹으면..!!", 0.15f, 6, 3);
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
