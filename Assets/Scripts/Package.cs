using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Package : MonoBehaviour
{
    public string allPackageIDs;
    public string packageID;
    public bool hasBeenHit;

    void Start() {
        GameController.instance.currentPackage = this;
    }

    public void OnMidpoint() {
        GameController.instance.SetTries(0);
        hasBeenHit = false;

        string[] ids = allPackageIDs.Split(' ');
        packageID = ids[Random.Range(0, ids.Length)];
        
        GetComponent<SpriteRenderer>().enabled = true;
    }
}
