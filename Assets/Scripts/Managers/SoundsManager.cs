using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Enums;

[System.Serializable]
public struct Sounds
{
    public ESounds _sfxName;
    public AudioClip _clip;
}

public class SoundsManager : BaseSingleton<SoundsManager>
{
    [SerializeField] List<Sounds> _listSounds = new();
    private AudioSource _source;
    private Dictionary<ESounds, Sounds> _dictSounds;

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
        _source = GetComponent<AudioSource>();
    }

    private void Start()
    {
        foreach(var sound in _listSounds)
        {
            if (!_dictSounds.ContainsKey(sound._sfxName))
                _dictSounds.Add(sound._sfxName, sound);
        }
        //EventsManager.Instance.SubcribeToAnEvent(GameEvents.OnPlaySfx, PlaySfx);
    }

    private void OnDestroy()
    {
        //EventsManager.Instance.UnSubcribeToAnEvent(GameEvents.OnPlaySfx, PlaySfx);
    }

    public void PlaySfx(ESounds sfxName)
    {
        _source.clip =_dictSounds[sfxName]._clip;
        _source.Play();
    }
}