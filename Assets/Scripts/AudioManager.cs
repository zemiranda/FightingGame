using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instanceAM;

    [Header("Audio Source")]
    public AudioSource musicSource;

    [Header("Audio Clip")]
    public AudioClip music;

    void Awake()
    {
        Music();

        if (instanceAM == null)
        {
            instanceAM = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Music()
    {
        musicSource.clip = music;
        musicSource.Play();
    }
}