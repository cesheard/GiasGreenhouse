using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas greenhouseCanvas;

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();

    } // End of Awake()

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += (eventData.delta / greenhouseCanvas.scaleFactor);

    } // End of OnDrag(PointerEvenData evenData)

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 0.5f;
        canvasGroup.blocksRaycasts = false;

    } // End of OnBeingDrag(PointerEvenData eventData

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;

    } // End of OnEndDrag(PointerEventData eventData)
}
