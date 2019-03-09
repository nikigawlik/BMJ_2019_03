using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Package : MonoBehaviour
{
    public string packageID;

    void Start() {
        GameController.instance.currentPackage = this;
    }

    public void OnMidpoint() {
        GameController.instance.SetTries(0);
    }
}
