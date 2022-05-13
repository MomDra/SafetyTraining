using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string soundName;
    public AudioClip clip;
}
public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [SerializeField]
    Sound[] bgmSounds;//배경음악
    [SerializeField]
    Sound[] sfxSounds;//효과음

    [SerializeField]
    AudioSource bgmPlayer;//배경음악 플레이어

    [SerializeField]
    AudioSource[] sfxPlayer;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        PlayRandomBGM();
    }
    public void PlaySoundEffect(string soundName)
    {
        for (int i = 0; i < sfxSounds.Length; i++)
        {
            if (soundName == sfxSounds[i].soundName)
            {
                for (int x = 0; x < sfxPlayer.Length; x++)
                {
                    if (!sfxPlayer[x].isPlaying)
                    {
                        sfxPlayer[x].clip = sfxSounds[i].clip;
                        sfxPlayer[x].Play();
                        return;
                    }
                }
            }
        }
    }

    public void PlayRandomBGM()
    {
        int random = Random.Range(0, 2);
        bgmPlayer.clip = bgmSounds[random].clip;
        bgmPlayer.Play();

    }

}
