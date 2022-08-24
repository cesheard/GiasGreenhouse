using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class ClickCursor : MonoBehaviour, IPointerClickHandler, IPointerMoveHandler
{
    [SerializeField] private Canvas greenhouseCanvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    private Vector2 startPosition;
    public bool attachedToCursor = false;
    //public Vector2 cursorPos;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();

    } // End of Awake()

    void Start()
    {
        startPosition = new Vector2(this.rectTransform.position.x, this.rectTransform.position.y);
    }

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        if (pointerEventData.button == PointerEventData.InputButton.Left)
        {
            // attach the item to cursor
            attachedToCursor = true;
            //canvasGroup.blocksRaycasts = false;
        }
        if (pointerEventData.button == PointerEventData.InputButton.Right)
        {
            // detatch the item from cursor
            attachedToCursor = false;
            this.rectTransform.position = new Vector3(startPosition.x, startPosition.y, 0);
            //canvasGroup.blocksRaycasts = true;
        }
    }

    public void OnPointerMove(PointerEventData eventData)
    {
        if (attachedToCursor)
        {
            rectTransform.anchoredPosition += (eventData.delta / greenhouseCanvas.scaleFactor);
            //canvasGroup.blocksRaycasts = false;
        }
    }
}