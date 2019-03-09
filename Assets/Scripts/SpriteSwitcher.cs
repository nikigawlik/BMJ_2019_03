using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class SpriteSwitcher : MonoBehaviour
{
    public Sprite[] sprites;
    public int _spriteIndex;
    public int spriteIndex {
        get => _spriteIndex;
        set {
            _spriteIndex = value;
            GetComponent<SpriteRenderer>().sprite = sprites[_spriteIndex];
        }
    }

    private void Start() {
    }

    public void SwitchSprite() {
        spriteIndex = (spriteIndex + 1) % sprites.Length;
    }
}
