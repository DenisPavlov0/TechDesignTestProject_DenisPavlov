using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioController : MonoBehaviour
{
    public static AudioController instance;
    [Header("Audio Sources")]
    [SerializeField] private AudioSource backgroundMusicSource; 
    [SerializeField] private AudioSource soundEffectsSource; 
    [SerializeField] private AudioSource voiceSource; 

    [Header("Audio Clips")]
    [SerializeField] private AudioClip firstSceneBackgroundMusic; 
    [SerializeField] private AudioClip secondSceneBackgroundMusic;
    [Header("SFX")]
    [SerializeField] public AudioClip door_knock_sfx;
    [SerializeField] public AudioClip letter_mix_sfx;
    

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        SceneManager.sceneLoaded += OnSceneLoaded;
        DontDestroyOnLoad(gameObject);
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode) 
    {
        switch (scene.name) 
        {
            case GlobalConstants.FIRST_SCENE_TAG:
                PlayBackgroundMusic(firstSceneBackgroundMusic); 
                break;
            case GlobalConstants.SECOND_SCENE_TAG:
                PlayBackgroundMusic(secondSceneBackgroundMusic); 
                break;
            default:
                break;
        }
    }
    
    
    public void PlayBackgroundMusic(AudioClip clip)
    {
        if (backgroundMusicSource.isPlaying)
        {
            backgroundMusicSource.Stop();
        }
        backgroundMusicSource.clip = clip;
        backgroundMusicSource.Play();
    }

    public void PlaySoundEffect(AudioClip clip)
    {
        soundEffectsSource.clip = clip;
        soundEffectsSource.Play();
    }
}
