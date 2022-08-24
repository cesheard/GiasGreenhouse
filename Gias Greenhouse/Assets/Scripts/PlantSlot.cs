using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlantSlot : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler
{
    [SerializeField] public PlantPlaceholderScript plantPlaceholder;
    [SerializeField] public ClickCursor wateringCan;

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        if (pointerEventData.button == PointerEventData.InputButton.Left && plantPlaceholder.needsWater && wateringCan.attachedToCursor)
        {
            // Water the specific plant
            plantPlaceholder.needsWater = false;
        }
        if (pointerEventData.button == PointerEventData.InputButton.Left && !plantPlaceholder.needsWater && wateringCan.attachedToCursor)
        {
            Debug.Log("Does not need water yet!");
        }
    }

    public void OnPointerEnter(PointerEventData pointerEventData)
    {

    }
}
