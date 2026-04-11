using UnityEngine;
using UnityEngine.UI; // Foarte important: ne trebuie pentru a accesa Slider-ul

public class VolumeSliderFix : MonoBehaviour
{
    private Slider mySlider;

    void Start()
    {
      
        mySlider = GetComponent<Slider>();

        if (mySlider != null)
        {
           
            mySlider.value = PlayerPrefs.GetFloat("MusicVolume", 0.5f);

           
            mySlider.onValueChanged.AddListener(UpdateTheVolume);
        }
    }

   
    void UpdateTheVolume(float sliderValue)
    {
       
        MenuAudioManager activeManager = FindFirstObjectByType<MenuAudioManager>();

       
        if (activeManager != null)
        {
            activeManager.SetMusicVolume(sliderValue);
        }
    }
}