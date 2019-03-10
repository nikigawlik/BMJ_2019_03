using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SoundEffect {
    public string effectID;
    public AudioClip audioClip;
    public Sprite sprite;

    public SoundEffect(string effectID, AudioClip audioClip, Sprite sprite) {
        this.effectID = effectID;
        this.audioClip = audioClip;
        this.sprite = sprite;
    }

    public void Play() {
        GameController.instance.mainAudioSource.PlayOneShot(audioClip);
        GameController.instance.StartCoroutine(MakeAndDeleteBubble());
        //special cases
        if(effectID == "boom") {
            Package currentPackage = GameController.instance.currentPackage;
            currentPackage.GetComponent<SpriteRenderer>().enabled = false;
            currentPackage.GetComponent<Animator>().SetTrigger("WrongPackage");
        }
    }

    private IEnumerator MakeAndDeleteBubble() {
        GameObject obj = GameObject.Instantiate(GameController.instance.bubblePrefab);
        Package currentPackage = GameController.instance.currentPackage;
        if(currentPackage != null) {
            // move to a random position around the package
            obj.transform.position = 
                currentPackage.transform.position 
                + Quaternion.Euler(0, 0, Random.Range(0f, 360f)) * Vector3.right * Random.Range(0, 3f);
            // rotate randomly
            obj.transform.rotation = Quaternion.Euler(0, 0, Random.Range(-15f, 15f));
        }
        SpriteRenderer sr = obj.GetComponent<SpriteRenderer>();
        sr.sprite = sprite;

        yield return new WaitForSeconds(1f);

        GameObject.Destroy(obj);
    }
};