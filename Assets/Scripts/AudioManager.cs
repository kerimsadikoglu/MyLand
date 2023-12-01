using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AudioClipType { grabClip, shopClip }
public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    [SerializeField] private AudioSource audioSource;
    public AudioClip grabClip, shopClip;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(instance);
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayAudio(AudioClipType clipType)
    {
        if (audioSource != null)
        {
            AudioClip audioClip = null;
            if (clipType == AudioClipType.grabClip)
            {
                audioClip = grabClip;
            }
            else if (clipType == AudioClipType.shopClip)
            {
                audioClip = shopClip;
            }

            audioSource.PlayOneShot(audioClip, 0.6f);
        }
    }

    public void StopBackgroundMusic()
    {
        Camera.main.GetComponent<AudioSource>().Stop();
    }
}
