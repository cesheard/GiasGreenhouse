using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    [SerializeField] public GameObject[] tallPlantPlaceholders;
    [SerializeField] public GameObject[] shortPlantPlaceholders;
    [SerializeField] public Plant[] plantTypes;
    [SerializeField] public Planter[] planterTypes;

    public PauseMenu pauseMenu;

    private void Awake()
    {

        // Start growing the plants?
        foreach (GameObject plantPlaceholder in shortPlantPlaceholders){
            
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
