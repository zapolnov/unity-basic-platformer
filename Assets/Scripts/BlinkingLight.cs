using UnityEngine;
using DG.Tweening;

public sealed class BlinkingLight : MonoBehaviour
{
    [SerializeField] float InitialDelay;
    [SerializeField] float Duration;

    void Start()
    {
        Invoke("StartAnimation", InitialDelay);
    }

    void StartAnimation()
    {
        GetComponent<Light>()
            .DOIntensity(0.0f, Duration)
            .SetLoops(-1, LoopType.Yoyo);
    }
}
