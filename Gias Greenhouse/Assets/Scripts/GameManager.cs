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
        /*// Assign a planter and plant for each tall plantPlaceholder
        foreach (GameObject plantPlaceholder in tallPlantPlaceholders){
            for (int i=0; i < plantTypes.Length; i++){
                for (int j = 0; j < planterTypes.Length; j++){
                    if 
                }
            }
        }

        // Assign a planter and plant for each short plantPlaceholder
        foreach (GameObject plantPlaceholder in shortPlantPlaceholders){
            
        }*/
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
