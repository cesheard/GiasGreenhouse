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

    void Update()
    {
        /*if (attachedToCursor)
        {

            this.rectTransform.position = new Vector3(cursorPos.x, cursorPos.y, 0);
            //canvasGroup.blocksRaycasts = false;
        }*/
        /*else
        {

            canvasGroup.blocksRaycasts = true;
        }*/
    }

    /*public void OnClick()
    {
        // attach the item to cursor
        attachedToCursor = true;
    }
    public void OnRightClick()
    {
        // detatch the item from cursor
        attachedToCursor = false;
    }*/

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        //Output to console the clicked GameObject's name and the following message. You can replace this with your own actions for when clicking the GameObject.
        //Debug.Log(name + " Game Object Clicked!");

        if (pointerEventData.button == PointerEventData.InputButton.Left)
        {
            // attach the item to cursor
            attachedToCursor = true;
            //canvasGroup.interactable = false;
        }
        if (pointerEventData.button == PointerEventData.InputButton.Right)
        {
            // detatch the item from cursor
            attachedToCursor = false;
            this.rectTransform.position = new Vector3(startPosition.x, startPosition.y, 0);
            //canvasGroup.interactable = true;
        }
    }

    public void OnPointerMove(PointerEventData eventData)
    {
        //cursorPos = eventData.position;
        if (attachedToCursor)
        {
            rectTransform.anchoredPosition += (eventData.delta / greenhouseCanvas.scaleFactor);
        }
    }
}
