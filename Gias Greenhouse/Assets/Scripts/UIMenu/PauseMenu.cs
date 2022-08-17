using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class PauseMenu : MonoBehaviour
{
    // -- Declared Variables -- //
    //private const string GameVersion = "0.2";
    //[SerializeField] private Button lobbyButton = null;

    public static bool gameIsPaused = false;
    public static bool canToggle = true;
    public GameObject pauseMenuParentObj;
    public GameObject pauseMenuUI;
    //public GameObject mainMenuUI;
    //public GameObject usernameUI;
    public GameObject optionsMenuUI;
    public GameObject optionsGraphicsMenuUI;
    //public GameObject optionsControlsMenuUI;
    public GameObject optionsAudioMenuUI;
    //public AudioSource audioSource;
    public AudioMixer audioMixer;
    public EventSystem eventSystem;

    //public Button resumeButton;
    //public Button graphicsButton;

    public TMP_Dropdown fsDropdown;
    public TMP_Dropdown resolutionDropdown;
    Resolution[] resolutions;
    public TMP_Dropdown graphicDropdown;

    public Animator pauseScreenAnimator;
    //public Animator pauseBoardAnimator;
    //public Animator selectButton;

    private bool firstToggle = true;

    /*private void Awake()
    {
        if (mainMenuUI == null)
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }*/

    // Start is called before the first frame update
    void Start()
    {
        gameIsPaused = false;
        optionsMenuUI.SetActive(false);
        optionsGraphicsMenuUI.SetActive(false);
        //optionsControlsMenuUI.SetActive(false);
        optionsAudioMenuUI.SetActive(false);
        eventSystem = GameObject.FindObjectOfType<EventSystem>();
        resolutions = Screen.resolutions;
        //resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height + " @" + resolutions[i].refreshRate + "hz";
            options.Add(option);

            if (PlayerPrefs.GetInt("SelectedResolution", -1) == -1)       // First time playing (or never changed resolution??)
            {
                if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
                {
                    currentResolutionIndex = i;
                }
            }
            else        // Set to the player's preference
            {
                currentResolutionIndex = PlayerPrefs.GetInt("SelectedResolution", -1);
            }
        }
        resolutionDropdown.AddOptions(options);
        int selectedResolution = PlayerPrefs.GetInt("SelectedResolution", 0);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        int selectedFullscreenMode = PlayerPrefs.GetInt("SelectedFullscreenMode", 0);
        fsDropdown.value = selectedFullscreenMode;  //fullscreenDropdown value - 0 (Fullscreen Window), 1 (Exclusive Fullscreen), 2 (Maximized Window [not supported on Windows]), 3 (Windowed)
        SetFullscreen();

        int selectedQualityPref = PlayerPrefs.GetInt("SelectedQuality", 0);
        graphicDropdown.value = selectedQualityPref;
        SetQuality(selectedQualityPref);

    } // End of Start()

    // Update is called once per frame
    void Update()
    {
        /*if (usernameUI != null && lobbyButton != null)
        {
            string playerName = PlayerPrefs.GetString("PlayerName");
            //Debug.Log(playerName);
            if (playerName.Length > 0)
            {
                lobbyButton.interactable = true;
            }
            else
            {
                lobbyButton.interactable = false;
            }
        }*/
        
    } // End of Update()

    public void PauseToggle()
    {
        if (canToggle)
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
                //eventSystem.GetComponent<ControllerDetector>().HighlightButton(resumeButton);
            }
            //audioSource.Play();
        }
    }

    public void GoTitleMenu()
    {
        /*if (!PhotonNetwork.IsConnected)
        {
            PhotonNetwork.GameVersion = GameVersion;
            PhotonNetwork.ConnectUsingSettings();
            PhotonNetwork.AutomaticallySyncScene = true;
        }

        PhotonNetwork.NickName = PlayerPrefs.GetString("PlayerName");
        PhotonNetwork.AutomaticallySyncScene = true;
        // Goes to the Scene at index 1, which is the username scene
        audioSource.Play();*/
        SceneManager.LoadScene(0);
    }

    public void Pause()
    {
        //Time.timeScale = 0;
        gameIsPaused = true;
        pauseScreenAnimator.SetBool("isPaused", true);
        //pauseBoardAnimator.SetBool("isPaused", true);
        canToggle = false;
        StartCoroutine("SwitchBack");
    } // End of Pause()

    public void Resume()
    {
        //Time.timeScale = 1;
        gameIsPaused = false;
        pauseScreenAnimator.SetBool("isPaused", false);
        //pauseBoardAnimator.SetBool("isPaused", false);
        canToggle = false;
        StartCoroutine("SwitchBack");
        eventSystem.SetSelectedGameObject(null);

    } // End of Resume()

    public IEnumerator SwitchBack()
    {
        yield return new WaitForSeconds(0.333f);
        optionsMenuUI.SetActive(false);
        OptionsBack();
        canToggle = true;
    }

    /*public void LoadUsername()
    {
        mainMenuUI.SetActive(false);
        optionsMenuUI.SetActive(false);
        usernameUI.SetActive(true);
    }*/

    /*public void UsernameBack()
    {
        mainMenuUI.SetActive(true);
        usernameUI.SetActive(false);
    }*/

    /*public void LoadMainMenu()
    {
        audioSource.Play();
        //Time.timeScale = 1;
        Debug.Log("Loading the Main Menu...");

    } // End of LoadMainMenu()*/

    public void LoadOptions()
    {
        Debug.Log("Loading the options...");
        
        pauseMenuParentObj.SetActive(false);
        optionsMenuUI.SetActive(true);
        if (firstToggle)
        {
            LoadGraphics();
            firstToggle = false;
        }
        //audioSource.Play();

    } // End of LoadOptions()

    public void OptionsBack()
    {
        pauseMenuParentObj.SetActive(true);
        optionsMenuUI.SetActive(false);
        /*if (gameIsPaused)
        {
            eventSystem.GetComponent<ControllerDetector>().HighlightButton(resumeButton);
        }*/
    } // End of OptionsBack()


    public void LoadGraphics()
    {
        optionsGraphicsMenuUI.SetActive(true);
        //optionsControlsMenuUI.SetActive(false);
        optionsAudioMenuUI.SetActive(false);
        //audioSource.Play();
        //eventSystem.GetComponent<ControllerDetector>().HighlightButton(graphicsButton);
    } // End of Graphics()

    /*public void LoadControls()
    {
        optionsGraphicsMenuUI.SetActive(false);
        //optionsControlsMenuUI.SetActive(true);
        optionsAudioMenuUI.SetActive(false);
        audioSource.Play();
    } // End of Controls()*/

    public void LoadAudio()
    {
        optionsGraphicsMenuUI.SetActive(false);
        //optionsControlsMenuUI.SetActive(false);
        optionsAudioMenuUI.SetActive(true);
        //audioSource.Play();
    } // End of Audio()

    public void QuitGame()
    {
        //audioSource.Play();
        Debug.Log("Quitting the game...");
        Application.Quit();

    } // End of QuitGame()

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        PlayerPrefs.SetInt("SelectedQuality", qualityIndex);
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        PlayerPrefs.SetInt("SelectedResolution", resolutionIndex);
    }

    public void SetFullscreen()
    {
        if (fsDropdown.options[fsDropdown.value].text == "Fullscreen Window")
        {
            Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
            Debug.Log("Fullscreen Window");
            Screen.fullScreen = true;
            PlayerPrefs.SetInt("SelectedFullscreenMode", 0);
        }
        else if (fsDropdown.options[fsDropdown.value].text == "Exclusive Fullscreen")
        {
            Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
            Debug.Log("Exclusive Fullscreen");
            Screen.fullScreen = true;
            PlayerPrefs.SetInt("SelectedFullscreenMode", 1);
        }
        else if (fsDropdown.options[fsDropdown.value].text == "Maximized Window")
        {
            Screen.fullScreenMode = FullScreenMode.MaximizedWindow;
            Debug.Log("Maximized Window");
            //Screen.fullScreen = false;
            PlayerPrefs.SetInt("SelectedFullscreenMode", 2);
        }
        else if (fsDropdown.options[fsDropdown.value].text == "Windowed")
        {
            Screen.fullScreenMode = FullScreenMode.Windowed;
            Debug.Log("Windowed");
            //Screen.fullScreen = false;
            PlayerPrefs.SetInt("SelectedFullscreenMode", 3);
        }
    }

}

