using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] public PlantPlaceholderScript[] plantPlaceholders;
    [SerializeField] public Plant[] plantTypes;

    public PauseMenu pauseMenu;
    public TMP_Text scoreText;
    public GameObject scoreMenuUI;

    private void Awake()
    {
        // Randomize the assigned plants and plant stages to the pots (not randomizing the planters)
        foreach (PlantPlaceholderScript plantPlaceholder in plantPlaceholders)
        {
            plantPlaceholder.assignedPlant = plantTypes[Random.Range(0, plantTypes.Length)];
            plantPlaceholder.assignedPlantCurrentStage = Random.Range(0, 4);
            plantPlaceholder.assignedPlantSprite = plantPlaceholder.assignedPlant.stages[plantPlaceholder.assignedPlantCurrentStage];
            plantPlaceholder.GetComponentInChildren<SpriteRenderer>().sprite = plantPlaceholder.assignedPlantSprite;

            Debug.Log(plantPlaceholders[0].assignedPlantCurrentStage + " " + plantPlaceholders[0].assignedPlantSprite.name);
            StartCoroutine(plantPlaceholder.GrowTime(plantPlaceholder.assignedPlant.growTime));
        }

    } // End of Awake()

    void Start()
    {
        pauseMenu = FindObjectOfType<PauseMenu>();

    } // End of Start()

    void Update()
    {
        StartCoroutine(DoCheck());

    } // End of Update()

    public void OnPauseMenu(InputValue value)
    {
        pauseMenu.PauseToggle();

    } // End of OnPauseMenu(InputValue value)

    public void CheckLabels()
    {
        scoreMenuUI.SetActive(true);
        int correctLabelCount = 0;
        foreach (PlantPlaceholderScript plantPlaceholder in plantPlaceholders)
        {
            if (plantPlaceholder.CheckLabels())
            {
                correctLabelCount++;
            }
        }
        scoreText.text = "You correctly labeled " + correctLabelCount + " out of " + plantPlaceholders.Length;

    } // End of CheckLabels()

    // Do a check every tenth of a second
    IEnumerator DoCheck()
    {
        for (; ; )
        {
            // Check growth of each plant
            foreach (PlantPlaceholderScript plantPlaceholder in plantPlaceholders)
            {
                if (plantPlaceholder.stageDone && plantPlaceholder.assignedPlantCurrentStage < 3)
                {
                    // Add needs water indication

                    // When watered, start next grow stage
                    plantPlaceholder.stageDone = false;
                    plantPlaceholder.assignedPlantCurrentStage++;
                    plantPlaceholder.assignedPlantSprite = plantPlaceholder.assignedPlant.stages[plantPlaceholder.assignedPlantCurrentStage];
                    plantPlaceholder.GetComponentInChildren<SpriteRenderer>().sprite = plantPlaceholder.assignedPlantSprite;

                    StartCoroutine(plantPlaceholder.GrowTime(plantPlaceholder.assignedPlant.growTime));
                }
                if (plantPlaceholder.stageDone && plantPlaceholder.assignedPlantCurrentStage == 3)
                {
                    // Add ready to pick indication

                    // When re-planted, start first grow stage
                    //plantPlaceholder.assignedPlantCurrentStage = 0;
                }
            }

            yield return new WaitForSeconds(.1f);
        }
    }
}
