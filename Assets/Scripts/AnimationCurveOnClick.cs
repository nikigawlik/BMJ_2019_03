using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationCurveOnClick : MonoBehaviour
{
    public AnimationCurve animTest;
    private float animProgress = 100f;
    private Vector3 baseScale;

    private void Start() {
        baseScale = transform.localScale;
    }

    private void Update() {
        animProgress += Time.deltaTime;
        transform.localScale = baseScale * (1f + animTest.Evaluate(animProgress));
    }

    private void OnMouseDown() {
        animProgress = 0;
    }
}
