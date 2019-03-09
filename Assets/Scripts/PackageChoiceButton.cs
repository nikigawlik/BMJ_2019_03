using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackageChoiceButton : MonoBehaviour
{
    public string packageID;
    private void OnMouseDown() {
        if(GameController.instance.currentPackage.packageID == packageID) {
            GameController.instance.currentPackage.GetComponent<Animator>().SetTrigger("CorrectPackage");
        } else {
            GameController.instance.currentPackage.GetComponent<Animator>().SetTrigger("WrongPackage");
        }
    }
}
