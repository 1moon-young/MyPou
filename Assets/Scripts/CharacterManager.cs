using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Eyehandler : MonoBehaviour
{

    // 눈동자
    public Transform eye;

    // 눈동자 최대 x, y 값
    float maxX = 0.1f;
    float maxY = 0.1f;

    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = eye.localPosition;
        
    }

    // 임시코드.. 언젠가 수정
    void Update()
    {

        if (Input.GetMouseButton(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 targetPosition = new Vector3(mousePosition.x, mousePosition.y, initialPosition.z);

            // 타겟 위치 제한
            targetPosition.x = Mathf.Clamp(targetPosition.x, initialPosition.x - maxX, initialPosition.x + maxX);
            targetPosition.y = Mathf.Clamp(targetPosition.y, initialPosition.y - maxY, initialPosition.y + maxY);

            eye.localPosition = Vector2.Lerp(eye.localPosition, targetPosition, 0.05f);

        }else{
            eye.localPosition = Vector2.Lerp(eye.localPosition, new Vector2(0,0), 0.05f);
        }

    }
}