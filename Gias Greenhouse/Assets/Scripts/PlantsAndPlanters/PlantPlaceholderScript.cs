using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantPlaceholderScript : MonoBehaviour
{
    public GameObject plantObject;
    public Plant assignedPlant;
    public Sprite assignedPlantSprite;
    public DropSlot labelSlot;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool CheckLabels()
    {
        return (labelSlot.labelName.Equals(assignedPlant.name));
    }
}
