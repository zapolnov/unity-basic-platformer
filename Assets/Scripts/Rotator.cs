using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Rotator : MonoBehaviour
{
    [SerializeField] float Duration;

    void Start()
    {
        transform
            .DORotate(new Vector3(0.0f, 0.0f, 360.0f), Duration, RotateMode.FastBeyond360)
            .SetRelative()
            .SetEase(Ease.Linear)
            .SetLoops(-1);
    }
}
