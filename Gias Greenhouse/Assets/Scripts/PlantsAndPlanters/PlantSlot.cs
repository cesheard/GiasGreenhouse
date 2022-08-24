using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlantSlot : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] public PlantPlaceholderScript plantPlaceholder;
    //[SerializeField] public ClickCursor wateringCan;
    public Texture2D wateringCanCursor;

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        if (pointerEventData.button == PointerEventData.InputButton.Left && plantPlaceholder.needsWater /*&& wateringCan.attachedToCursor*/)
        {
            // Water the specific plant
            Debug.Log("Trying to water plant");
            plantPlaceholder.needsWater = false;
            Cursor.SetCursor(default, Vector2.zero, CursorMode.ForceSoftware);
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
