using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterManager : MonoBehaviour
{

    // 눈동자
    public Transform eyes;
    float eyesMaxX = 0.1f;
    float eyesMaxY = 0.1f;
    private Vector3 eyesInitialPosition;

    void Start()
    {
        eyesInitialPosition = eyes.localPosition;
        
    }

    void Update()
    {

        // 시선 따라가기. 임시코드.. 언젠가 수정
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 eyesTargetPosition = new Vector3(mousePosition.x, mousePosition.y, eyesInitialPosition.z);

            // 타겟 위치 제한
            eyesTargetPosition.x = Mathf.Clamp(eyesTargetPosition.x, eyesInitialPosition.x - eyesMaxX, eyesInitialPosition.x + eyesMaxX);
            eyesTargetPosition.y = Mathf.Clamp(eyesTargetPosition.y, eyesInitialPosition.y - eyesMaxY, eyesInitialPosition.y + eyesMaxY);

            eyes.localPosition = Vector2.Lerp(eyes.localPosition, eyesTargetPosition, 0.05f);

        }else{
            eyes.localPosition = Vector2.Lerp(eyes.localPosition, new Vector2(0,0), 0.05f);
        }

    }
}