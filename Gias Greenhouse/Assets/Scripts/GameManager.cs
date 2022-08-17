using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    [SerializeField] public PlantPlaceholderScript[] plantPlaceholders;
    [SerializeField] public Plant[] plantTypes;

    public PauseMenu pauseMenu;

    private void Awake()
    {
        // Randomize the assigned plants and plant stages to the pots (not randomizing the planters)
        foreach (PlantPlaceholderScript plantPlaceholder in plantPlaceholders)
        {
            plantPlaceholder.assignedPlant = plantTypes[Random.Range(0, plantTypes.Length)];
            plantPlaceholder.assignedPlantSprite = plantPlaceholder.assignedPlant.stages[Random.Range(0, 4)];
            plantPlaceholder.GetComponentInChildren<SpriteRenderer>().sprite = plantPlaceholder.assignedPlantSprite;
        }
    }

    void Start()
    {
        pauseMenu = FindObjectOfType<PauseMenu>();
    }

    public void OnPauseMenu(InputValue value)
    {

        Debug.Log("Player is tring to pause game");
        pauseMenu.PauseToggle();
    }
}
