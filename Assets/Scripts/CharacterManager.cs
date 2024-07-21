using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterManager : MonoBehaviour
{

    // 눈동자
    public Transform eyeR;
    float eyesMaxX = 0.1f;
    float eyesMaxY = 0.1f;
    private Vector3 eyeLInitPos, eyeRInitPos;

    void Start()
    {
        // eyeLInitPos = eyeL.localPosition;
        eyeRInitPos = eyeR.localPosition;
    }

    void Update()
    {
        // 시선 따라가기. 임시코드.. 언젠가 수정
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // Vector3 LtargetPos = new Vector3(mousePos.x, mousePos.y, 0);
            Vector3 RtargetPos = new Vector3(mousePos.x, mousePos.y, 0);
            // 타겟 위치 제한
            // LtargetPos.x = Mathf.Clamp(LtargetPos.x, eyeLInitPos.x - eyesMaxX*2.5f, eyeLInitPos.x + eyesMaxX);
            // LtargetPos.y = Mathf.Clamp(LtargetPos.y, eyeLInitPos.y - eyesMaxY, eyeLInitPos.y + eyesMaxY-0.04f);

            RtargetPos.x = Mathf.Clamp(RtargetPos.x, eyeRInitPos.x - eyesMaxX*2.5f, eyeRInitPos.x + eyesMaxX);
            RtargetPos.y = Mathf.Clamp(RtargetPos.y, eyeRInitPos.y - eyesMaxY, eyeRInitPos.y + eyesMaxY-0.04f);

            // eyeL.localPosition = Vector2.Lerp(eyeL.localPosition, LtargetPos, 0.05f);
            eyeR.localPosition = Vector2.Lerp(eyeR.localPosition, RtargetPos, 0.05f);


        }else{
            // eyeL.localPosition = Vector2.Lerp(eyeL.localPosition, eyeLInitPos, 0.05f);
            eyeR.localPosition = Vector2.Lerp(eyeR.localPosition, eyeRInitPos, 0.05f);
        }

    }

}