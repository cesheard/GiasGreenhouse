using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlantSlot : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] public PlantPlaceholderScript plantPlaceholder;
    //[SerializeField] public ClickCursor wateringCan;
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
    }

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
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Cursor.SetCursor(default, Vector2.zero, CursorMode.ForceSoftware);
    }
}
