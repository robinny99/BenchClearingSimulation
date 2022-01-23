using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseClick : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Left)
        {
            Debug.Log("Mouse Click Button : Left");
            //왼쪽
        }

        Debug.Log("Mouse Position : " + eventData.position);
        Debug.Log("Mouse Click Count : " + eventData.clickCount);
    }
}
