using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager
{
    AudioSource[] audioSources = new AudioSource[(int)Define.Sound.MaxCount];

    Dictionary<string, AudioClip> audioClips = new Dictionary<string, AudioClip>();

    public void Init()
    {
        GameObject obj = GameObject.Find("@Sound");

        if (obj == null)
        {
            obj = new GameObject
            {
                name = "@Sound"
            };
            Object.DontDestroyOnLoad(obj);

            string[] soundNames = System.Enum.GetNames(typeof(Define.Sound));

            for (int i = 0; i < soundNames.Length - 1; ++i)
            {
                GameObject go = new GameObject
                {
                    name = soundNames[i]
                };
                audioSources[i] = go.AddComponent<AudioSource>();
                go.transform.parent = obj.transform;
            }

            audioSources[(int) Define.Sound.Bgm].loop = true;
        }
    }

    public void Play(string path, Define.Sound type = Define.Sound.Effect,  float pitch = 1.0f)
    {
        AudioClip clip = GetOrAddAudioClip(path, type);
        Play(clip, type, pitch);
    }

    public void Play(AudioClip clip, Define.Sound type = Define.Sound.Effect, float pitch = 1.0f)
    {
        if (clip == null)
        {
            return;
        }

        if (type == Define.Sound.Bgm)
        {
            AudioSource audioSource = audioSources[(int)Define.Sound.Bgm];

            if (audioSource.isPlaying == true)
            {
                audioSource.Stop();
            }

            audioSource.pitch = pitch;
            audioSource.clip = clip;
            audioSource.Play();
        }
        else
        {
            AudioSource audioSource = audioSources[(int)Define.Sound.Effect];
            audioSource.pitch = pitch;
            audioSource.PlayOneShot(clip);
        }
    }

    AudioClip GetOrAddAudioClip(string path, Define.Sound type = Define.Sound.Effect)
    {
        if (path.Contains("Sounds/") == false)
        {
            path = $"Sounds/{path}";
        }

        AudioClip audioClip;

        if (type == Define.Sound.Bgm)
        {
            audioClip = Managers.Resource.Load<AudioClip>(path);
        }
        else
        {
            if (audioClips.TryGetValue(path, out audioClip) == false)
            {
                audioClip = Managers.Resource.Load<AudioClip>(path);
                audioClips.Add(path, audioClip);
            }
        }
        if (audioClip == null)
        {
            Debug.Log($"No Audio bitch : {path}");
        }
        return audioClip;
    }

    public void Clear()
    {
        foreach(AudioSource aud in audioSources)
        {
            aud.Stop();
            aud.clip = null;
        }
        audioClips.Clear();
    }
}
