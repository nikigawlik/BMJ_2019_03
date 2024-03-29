﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    public string packageID;

    public string soundEffectID;
    public string alternativeSoundEffectID;

    private void OnMouseDown() {
        Package currentPackage = GameController.instance.currentPackage;
        if (currentPackage != null && GameController.instance.tries < GameController.instance.maxTries) {
            string[] tags = packageID.Split(' ');

            foreach (string currentID in tags)
            {
                if(currentPackage.packageID == currentID) {
                    GameController.instance.UseTry();
                    //hammer hack
                    if(gameObject.name == "Hammer") {
                        GameController.instance.currentPackage.hasBeenHit = true;
                    }
                    // do interaction!
                    if(alternativeSoundEffectID != "" && GameController.instance.currentPackage.hasBeenHit) {
                        //play alternative sound effect when it's defined and the package is broken
                        PlaySoundEffects(alternativeSoundEffectID);
                    } else
                    {
                        // play normal sound effect
                        PlaySoundEffects(soundEffectID);
                    }
                }
            }
        }
    }

    private void PlaySoundEffects(string sfxID)
    {
        string[] ids = sfxID.Split(' ');
        foreach (string id in ids)
        {
            GameController.instance.GetSoundEffect(id).Play();
        }
    }
}
