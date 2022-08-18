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
            plantPlaceholder.assignedPlantSprite = plantPlaceholder.assignedPlant.stages[Random.Range(0, 4)];
            plantPlaceholder.GetComponentInChildren<SpriteRenderer>().sprite = plantPlaceholder.assignedPlantSprite;
        }

    } // End of Awake()

    void Start()
    {
        pauseMenu = FindObjectOfType<PauseMenu>();

    } // End of Start()

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
}
