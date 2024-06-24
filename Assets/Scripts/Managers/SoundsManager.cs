using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Enums;

[System.Serializable]
public class Sounds
{
    public ESounds _sfxName;
    public AudioClip _clip;
}

public class SoundsManager : BaseSingleton<SoundsManager>
{
    [SerializeField] List<Sounds> _listSounds = new();
    private AudioSource _source;
    private Dictionary<ESounds, Sounds> _dictSounds = new();

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
            {
                _dictSounds.Add(sound._sfxName, sound);
                _dictSounds[sound._sfxName] = new Sounds();
                _dictSounds[sound._sfxName]._clip = sound._clip;
            }
               
        }
        //EventsManager.Instance.SubcribeToAnEvent(GameEvents.OnPlaySfx, PlaySfx);
    }

    private void OnDestroy()
    {
        //EventsManager.Instance.UnSubcribeToAnEvent(GameEvents.OnPlaySfx, PlaySfx);
    }

    public void PlaySfx(ESounds sfxName)
    {
        if(_source == null)
        {
            Debug.Log("Source null");
        }

        if(_dictSounds[sfxName]._clip == null)
        {

        }
        Debug.Log("Play" + sfxName);
        _source.clip = _dictSounds[sfxName]._clip;
        _source.Play();
    }
}