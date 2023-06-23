using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    [Header("--------- Audio Source ------------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("--------- Audio Clip ------------")]
    public AudioClip gameplay;
    public AudioClip menu;
    public AudioClip click;
    public AudioClip comic;
    public AudioClip scientist;
    public AudioClip death;
    public AudioClip convert;
    public AudioClip victory;

    /*private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }*/

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "Menu")
        {
            musicSource.Pause();
            musicSource.clip = menu;
            musicSource.Play();
        }
        if (SceneManager.GetActiveScene().name == "Comic")
        {
            musicSource.Pause();
            musicSource.clip = comic;
            musicSource.Play();
        }
        if (SceneManager.GetActiveScene().name == "Level")
        {
            musicSource.Pause();
            musicSource.clip = gameplay;
            musicSource.Play();
        }
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

    public void PlayMusic(AudioClip clip)
    {
        musicSource.Pause();
        musicSource.clip = clip;
        musicSource.Play();
    }
}