using UnityEngine;

public class PlantPlaceholderScript : MonoBehaviour
{
    public GameObject plantObject;
    public Plant assignedPlant;
    public Sprite assignedPlantSprite;
    public DropSlot labelSlot;

    // Checks to see if the assigned label is correct, returns bool; GameManager references the function
    public bool CheckLabels()
    {
        return (labelSlot.labelName.Equals(assignedPlant.name));
    } // End of CheckLabels()
}
