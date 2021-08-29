using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum BGMType
{
    /// <summary>
    /// 使用しない
    /// </summary>
    None,
    Pattern1,
    Pattern2,
    Pattern3,
}
public enum SEType
{
    /// <summary>
    /// 使用しない
    /// </summary>
    None,
    Cut,
    Count,
    Whistle,
}
[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    static public SoundManager Instance { get; private set; }
    private AudioSource audioSource;
    [SerializeField] private AudioClip[] soundBGM;
    [SerializeField] private AudioClip[] soundEffect;
    Dictionary<BGMType, AudioClip> soundBGMList = new Dictionary<BGMType, AudioClip>();
    Dictionary<SEType, AudioClip> soundSEList = new Dictionary<SEType, AudioClip>();
    [SerializeField] private BGMType startBGM = BGMType.Pattern1;
    private BGMType bgmType = BGMType.None;
    private void Awake()
    {
        Instance = this;
        audioSource = GetComponent<AudioSource>();
        for (int i = 0; i < soundBGM.Length; i++)
        {
            var soundID = (BGMType)(i + 1);
            soundBGMList.Add(soundID, soundBGM[i]);
        }
        for (int i = 0; i < soundEffect.Length; i++)
        {
            var soundID = (SEType)(i + 1);
            soundSEList.Add(soundID, soundEffect[i]);
        }
    }
    private void Start()
    {
        PlayBGM(startBGM);
    }
    public void PlayBGM(BGMType type)
    {
        if (type == BGMType.None)
        {
            return;
        }
        if (bgmType != type)
        {
            audioSource.clip = soundBGMList[type];
            audioSource.Play();
            audioSource.loop = true;
            bgmType = type;
        }
    }

    public void PlaySE(SEType type)
    {
        if (type == SEType.None)
        {
            return;
        }
        audioSource.PlayOneShot(soundSEList[type]);
    }
}
