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

    public int numOfTomatoes;
    public TMP_Text textOfTomatoes;
    public int numOfPotatoes;
    public TMP_Text textOfPotatoes;
    public int numOfCarrots;
    public TMP_Text textOfCarrots;

    private void Awake()
    {
        // Randomize the assigned plants and plant stages to the pots (not randomizing the planters)
        foreach (PlantPlaceholderScript plantPlaceholder in plantPlaceholders)
        {
            plantPlaceholder.assignedPlant = plantTypes[Random.Range(0, plantTypes.Length)];
            plantPlaceholder.assignedPlantCurrentStage = Random.Range(0, 4);
            plantPlaceholder.assignedPlantSprite = plantPlaceholder.assignedPlant.stages[plantPlaceholder.assignedPlantCurrentStage];
            plantPlaceholder.GetComponentInChildren<SpriteRenderer>().sprite = plantPlaceholder.assignedPlantSprite;
            
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
                if (plantPlaceholder.stageDone && plantPlaceholder.assignedPlantCurrentStage < 3 /*&& plantPlaceholder.needsWater*/)
                {
                    if (plantPlaceholder.needsWater)
                    {
                        // Add needs water indication
                        plantPlaceholder.assignedPlantHighlight.enabled = true;
                        plantPlaceholder.assignedPlantHighlight.sprite = plantPlaceholder.assignedPlant.blueHighlights[plantPlaceholder.assignedPlantCurrentStage];
                    }

                    // When watered, start next grow stage
                    if (!plantPlaceholder.needsWater)
                    {
                        plantPlaceholder.assignedPlantHighlight.enabled = false;

                        plantPlaceholder.stageDone = false;
                        plantPlaceholder.assignedPlantCurrentStage++;
                        plantPlaceholder.assignedPlantSprite = plantPlaceholder.assignedPlant.stages[plantPlaceholder.assignedPlantCurrentStage];
                        plantPlaceholder.GetComponentInChildren<SpriteRenderer>().sprite = plantPlaceholder.assignedPlantSprite;

                        StartCoroutine(plantPlaceholder.GrowTime(plantPlaceholder.assignedPlant.growTime));
                    }
                }
                if (plantPlaceholder.stageDone && plantPlaceholder.assignedPlantCurrentStage == 3)
                {
                    if (plantPlaceholder.readyToPick)
                    {
                        // Add ready to pick indication
                        plantPlaceholder.assignedPlantHighlight.enabled = true;
                        plantPlaceholder.assignedPlantHighlight.sprite = plantPlaceholder.assignedPlant.purpleHighlight;
                    }

                    // When re-planted, start first grow stage
                    if (!plantPlaceholder.readyToPick)
                    {
                        if (plantPlaceholder.assignedPlant == plantTypes[0])
                        {
                            numOfTomatoes++;
                            textOfTomatoes.text = "" + numOfTomatoes;
                        }
                        else if (plantPlaceholder.assignedPlant == plantTypes[1])
                        {
                            numOfPotatoes++;
                            textOfPotatoes.text = "" + numOfPotatoes;
                        }
                        else if (plantPlaceholder.assignedPlant == plantTypes[2])
                        {
                            numOfCarrots++;
                            textOfCarrots.text = "" + numOfCarrots;
                        }
                        plantPlaceholder.stageDone = false;
                        plantPlaceholder.assignedPlantHighlight.enabled = false;
                        plantPlaceholder.assignedPlantCurrentStage = 0;
                        plantPlaceholder.assignedPlantSprite = plantPlaceholder.assignedPlant.stages[plantPlaceholder.assignedPlantCurrentStage];
                        plantPlaceholder.GetComponentInChildren<SpriteRenderer>().sprite = plantPlaceholder.assignedPlantSprite;

                        StartCoroutine(plantPlaceholder.GrowTime(plantPlaceholder.assignedPlant.growTime));
                    }
                }
            }

            yield return new WaitForSeconds(.1f);
        }

    } // End of DoCheck()

    public void UpdateProduceInventoryUI()
    {
        Debug.Log("Update is being called");
        textOfTomatoes.text = numOfTomatoes.ToString();
        textOfPotatoes.text = numOfPotatoes.ToString();
        textOfCarrots.text = numOfCarrots.ToString();

    } // End of UpdateProduceInventoryUI()
}
