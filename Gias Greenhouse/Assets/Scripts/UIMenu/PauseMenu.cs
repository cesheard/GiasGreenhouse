using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class PauseMenu : MonoBehaviour
{
    // -- Declared Variables -- //
    public static bool gameIsPaused = false;
    public GameObject pauseMenuParentObj;
    public GameObject pauseMenuBackground;
    public GameObject pauseMenuUI;
    public GameObject optionsMenuUI;
    public GameObject optionsGraphicsMenuUI;
    public GameObject optionsAudioMenuUI;
    public AudioMixer audioMixer;
    public EventSystem eventSystem;

    public TMP_Dropdown fsDropdown;
    public TMP_Dropdown resolutionDropdown;
    Resolution[] resolutions;
    public TMP_Dropdown graphicDropdown;

    public Animator pauseMenuAnimator;
    private bool firstToggle = true;

    // Start is called before the first frame update
    void Start()
    {
        gameIsPaused = false;
        optionsMenuUI.SetActive(false);
        optionsGraphicsMenuUI.SetActive(false);
        optionsAudioMenuUI.SetActive(false);
        eventSystem = GameObject.FindObjectOfType<EventSystem>();

        resolutions = Screen.resolutions;
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

    public void PauseToggle()
    {
        if (gameIsPaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }

    } // End of PauseToggle()

    public void GoTitleMenu()
    {
        SceneManager.LoadScene(0);

    } // End of GoTitleMenu()

    public void Pause()
    {
        gameIsPaused = true;
        pauseMenuBackground.SetActive(true);
        pauseMenuAnimator.SetBool("isPaused", true);
    } // End of Pause()

    public void Resume()
    {
        gameIsPaused = false;
        pauseMenuBackground.SetActive(false);
        pauseMenuAnimator.SetBool("isPaused", false);
        //eventSystem.SetSelectedGameObject(null);

    } // End of Resume()

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

    } // End of LoadOptions()

    public void OptionsBack()
    {
        pauseMenuParentObj.SetActive(true);
        optionsMenuUI.SetActive(false);

    } // End of OptionsBack()


    public void LoadGraphics()
    {
        optionsGraphicsMenuUI.SetActive(true);
        optionsAudioMenuUI.SetActive(false);

    } // End of Graphics()

    public void LoadAudio()
    {
        optionsGraphicsMenuUI.SetActive(false);
        optionsAudioMenuUI.SetActive(true);

    } // End of Audio()

    public void QuitGame()
    {
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

