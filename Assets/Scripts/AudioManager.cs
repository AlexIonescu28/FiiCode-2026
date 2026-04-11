using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;
    public AudioClip background;

    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();

     
        float savedVolume = PlayerPrefs.GetFloat("MusicVolume", 0.5f);
        musicSource.volume = savedVolume;
    }

    public void SetMusicVolume(float volume)
    {
        musicSource.volume = volume;

        
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }

    public float GetMusicVolume()
    {
        return musicSource.volume;
    }
}