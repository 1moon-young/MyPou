using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ScrollManager : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{

    public Scrollbar scrollbar;

    const int SIZE = 4; 
    float distance;
    float[] pos = new float[SIZE];
    public GameObject[] pages;
    int curPos, targetPos;
    bool isDrag;

    // 툴 변경
    public GameObject[] mainTools;

    void Start()
    {
        distance = 1f / (SIZE-1);
        for (int i = 0 ; i < SIZE ; i++)
            pos[i] = distance * i;
    }

    public int getPos(){
        for(int i = 0 ; i < SIZE ; i++)
            if(scrollbar.value > pos[i]-distance*0.5 && scrollbar.value < pos[i]+distance*0.5)
                return i;
        return -1;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        curPos = getPos();
    }

    public void OnDrag(PointerEventData eventData)
    {
        isDrag=true;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if(eventData.delta.x < -15)
            targetPos = curPos+1;
        else if (eventData.delta.x > 15)
            targetPos = curPos-1;
        else 
            targetPos = getPos();
        isDrag=false;
    }


    void Update()
    {
        if(!isDrag){
            if (targetPos>=SIZE) targetPos=SIZE-1;
            if (targetPos<0) targetPos=0;
            scrollbar.value = Mathf.Lerp(scrollbar.value, pos[targetPos], 0.1f);

            // 툴 변경
            mainTools[curPos].SetActive(false);
            mainTools[targetPos].SetActive(true);

            // 버튼 깨우기
            for (int i = 0 ; i < pages[curPos].transform.childCount ; i++){
                pages[curPos].transform.GetChild(i).gameObject.SetActive(false);
            }
            for (int i = 0 ; i < pages[targetPos].transform.childCount ; i++){
                pages[targetPos].transform.GetChild(i).gameObject.SetActive(true);
            }
        }
    }
}
