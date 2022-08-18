using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    [SerializeField] string volumeParameter;
    [SerializeField] AudioMixerGroup mixer;
    [SerializeField] Slider slider;

    private void Awake()
    {
        slider.onValueChanged.AddListener(HandleSliderValueChanged);

    } // End of Awake()

    private void OnDisable()
    {
        PlayerPrefs.SetFloat(volumeParameter, slider.value);

    } // End of onDisable()

    void Start()
    {
        slider.value = PlayerPrefs.GetFloat(volumeParameter, slider.value);
        HandleSliderValueChanged(slider.value);

    } // End of Start()

    public void HandleSliderValueChanged(float value)
    {
        mixer.audioMixer.SetFloat(volumeParameter, Mathf.Log10(value) * 20);

    } // End of HandleSliderValueChanged(float value)
}
