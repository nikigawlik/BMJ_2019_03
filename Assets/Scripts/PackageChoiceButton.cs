using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackageChoiceButton : MonoBehaviour
{
    public AudioClip winClip;
    public AudioClip loseClip;

    public string packageID;
    private void OnMouseDown() {
        if(GameController.instance.currentPackage.packageID == packageID) {
            GameController.instance.currentPackage.GetComponent<Animator>().SetTrigger("CorrectPackage");
            // GameController.instance.mainAudioSource.PlayOneShot(winClip);
            GameController.instance.GetSoundEffect("win").Play(); // 25.
        } else {
            GameController.instance.currentPackage.GetComponent<Animator>().SetTrigger("WrongPackage");
            GameController.instance.GetSoundEffect("lose").Play();
            // GameController.instance.mainAudioSource.PlayOneShot(loseClip);
        }
    }
}
