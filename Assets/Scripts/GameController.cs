using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public Package currentPackage;
    public GameObject bubblePrefab;
    public GameObject checkboxPrefab;
    public Transform checkboxParent;
    public float checkboxWidth = 1;
    
    public AudioSource mainAudioSource;

    public List<SoundEffect> soundEffects;

    public int tries = 0;
    public int maxTries = 3;

    private void OnEnable() {
        if(instance != null) {
            GameObject.Destroy(instance);
        }

        instance = this;

        if(mainAudioSource == null) {
            mainAudioSource = GetComponent<AudioSource>();
        }
    }

    private void Start() {
        SetTries(0);
    }

    public SoundEffect GetSoundEffect(string soundEffectID) {
        foreach (SoundEffect se in soundEffects)
        {
            if(se.effectID == soundEffectID) {
                return se;
            }
        }
        // fallback
        return soundEffects[0];
    }

    public void UseTry() {
        SetTries(tries + 1);
        if(tries == maxTries) {
            // SetTries(0);
            // currentPackage.GetComponent<Animator>().SetTrigger("NewPackage");
        }
    }

    public void SetTries(int newTries) {
        tries = Mathf.Clamp(newTries, 0, maxTries);

        float delta = checkboxWidth * (maxTries - 1);

        GameObject container = NilsGameUtils.Utils.CreateChildWithName(checkboxParent, "[Checkboxes]");
        for(int i = 0; i < maxTries; i++) {
            GameObject checkbox = Instantiate(checkboxPrefab);
            checkbox.transform.SetParent(container.transform);
            checkbox.transform.localPosition = new Vector3((-.5f + ((float) i / (maxTries - 1))) * delta, 0, 0);
            checkbox.GetComponent<SpriteSwitcher>().spriteIndex = i < tries? 1 : 0;
        }
    }
}
