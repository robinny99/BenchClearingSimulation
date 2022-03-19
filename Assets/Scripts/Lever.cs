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
    
    public float xforce;
    public float yforce;
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        var inputDir = eventData.position - rectTransform.anchoredPosition;

        var clampedDir = inputDir.magnitude < leverRange ? inputDir : inputDir.normalized * leverRange;

        lever.anchoredPosition = clampedDir;

        xforce = inputDir.normalized.x;
        yforce = inputDir.normalized.y;
    }

    public void OnDrag(PointerEventData eventData)
    {
        var inputDir = eventData.position - rectTransform.anchoredPosition;
        
        var clampedDir = inputDir.magnitude < leverRange ? inputDir : inputDir.normalized * leverRange;

        lever.anchoredPosition = clampedDir;

        xforce = inputDir.normalized.x;
        yforce = inputDir.normalized.y;
    }
    
    public void OnEndDrag(PointerEventData eventData)
    {
        xforce = 0;
        yforce = 0;
        lever.anchoredPosition = Vector2.zero;
    }
}
