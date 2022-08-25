using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlantPlaceholderScript : MonoBehaviour
{
    public GameObject plantObject;
    public Plant assignedPlant;
    public Sprite assignedPlantSprite;
    [SerializeField] public SpriteRenderer assignedPlantHighlight;
    public DropSlot labelSlot;
    public int assignedPlantCurrentStage = -1;
    public bool stageDone = false;
    public bool needsWater = false;
    public bool readyToPick = false;

    // Checks to see if the assigned label is correct, returns bool; GameManager references the function
    public bool CheckLabels()
    {
        return (labelSlot.labelName.Equals(assignedPlant.name));

    } // End of CheckLabels()

    public IEnumerator GrowTime(float growTime)
    {
        stageDone = false;
        yield return new WaitForSeconds(growTime);

        stageDone = true;
        if (assignedPlantCurrentStage < 3)
        {
            needsWater = true;
        }
        else
        {
            readyToPick = true;
        }

    } // End of GrowTime(float growTime)
}
