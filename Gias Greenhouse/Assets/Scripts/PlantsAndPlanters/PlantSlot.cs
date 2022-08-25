using UnityEngine;
using UnityEngine.EventSystems;

public class PlantSlot : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] public PlantPlaceholderScript plantPlaceholder;
    public Texture2D wateringCanCursor;
    public Texture2D harvestCursor;

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        if (pointerEventData.button == PointerEventData.InputButton.Left /*&& wateringCan.attachedToCursor*/)
        {
            if (plantPlaceholder.needsWater){
                // Water the specific plant
                Debug.Log("Trying to water plant");
                plantPlaceholder.needsWater = false;
                Cursor.SetCursor(default, Vector2.zero, CursorMode.ForceSoftware);
            }

            // Pick the specific plant
            if (plantPlaceholder.readyToPick)
            {
                Debug.Log("Trying to pick to plant");
                plantPlaceholder.readyToPick = false;
                Cursor.SetCursor(default, Vector2.zero, CursorMode.ForceSoftware);
            }
        }
        if (pointerEventData.button == PointerEventData.InputButton.Left && !plantPlaceholder.needsWater /*&& wateringCan.attachedToCursor*/)
        {
            Debug.Log("Does not need water yet!");
        }

    } // End of OnPointerClick(PointerEventData pointerEventData)

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (plantPlaceholder.needsWater)
        {
            Cursor.SetCursor(wateringCanCursor, Vector2.zero, CursorMode.Auto);
        }
        else if (plantPlaceholder.readyToPick)
        {
            Cursor.SetCursor(harvestCursor, Vector2.zero, CursorMode.Auto);
        }
        else
        {
            Cursor.SetCursor(default, Vector2.zero, CursorMode.ForceSoftware);
        }

    } // End of OnPointerEnter(PointerEventData eventData)

    public void OnPointerExit(PointerEventData eventData)
    {
        Cursor.SetCursor(default, Vector2.zero, CursorMode.ForceSoftware);

    } // End of OnPointerEnter(PointerEventData eventData)
}
