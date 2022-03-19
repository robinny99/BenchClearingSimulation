using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Lever : MonoBehaviour , IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] 
    private RectTransform lever;
    private RectTransform rectTransform;

    [SerializeField, Range(10f, 150f)] 
    private float leverRange;
    
    private Vector2 inputDirection;
    private bool isInput;

    [SerializeField] 
    private TPSController controller;
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        var inputDir = eventData.position - rectTransform.anchoredPosition;

        var clampedDir = inputDir.magnitude < leverRange ? inputDir : inputDir.normalized * leverRange;

        lever.anchoredPosition = clampedDir;

        ControlJoystickLever(eventData);
        isInput = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        var inputDir = eventData.position - rectTransform.anchoredPosition;
        
        var clampedDir = inputDir.magnitude < leverRange ? inputDir : inputDir.normalized * leverRange;

        lever.anchoredPosition = clampedDir;

        ControlJoystickLever(eventData);
        isInput = false;
    }

    public void ControlJoystickLever(PointerEventData eventData)
    {
        var inputDir = eventData.position - rectTransform.anchoredPosition;
        
        var clampedDir = inputDir.magnitude < leverRange ? inputDir : inputDir.normalized * leverRange;

        lever.anchoredPosition = clampedDir;
        inputDirection = clampedDir / leverRange;
    }
    
    public void OnEndDrag(PointerEventData eventData)
    {
        lever.anchoredPosition = Vector2.zero;
        controller.Move(Vector2.zero);
    }

    private void InputControlVector()
    {
        controller.Move(inputDirection);
        Debug.Log(inputDirection.x + " / " + inputDirection.y);
    }

    private void Update()
    {
        if (isInput)
        {
            InputControlVector();
        }
    }
}
