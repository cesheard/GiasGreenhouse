using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    [SerializeField] public GameObject[] plantPlaceholders;
    [SerializeField] public GameObject[] plantTypes;
    [SerializeField] public GameObject[] potTypes;

    public PauseMenu pauseMenu;

    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        pauseMenu = FindObjectOfType<PauseMenu>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPauseMenu(InputValue value)
    {

        Debug.Log("Player is tring to pause game");
        pauseMenu.PauseToggle();

        /*if (photonView.IsMine && value.isPressed)
        {
            pauseMenu.PauseToggle();
            if (PauseMenu.gameIsPaused)
            {
                desiredMovementState = currMovementState;
                ChangeState(MovementStates.paused);
            }
            else
            {
                ChangeState(desiredMovementState);
            }
        }*/
    }
}
