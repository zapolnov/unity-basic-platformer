using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MovingObject : MonoBehaviour
{
    [SerializeField] Transform[] Waypoints;
    [SerializeField] float StayTime;
    [SerializeField] float MovementDuration;

    void Start()
    {
        var seq = DOTween.Sequence();
        foreach (var waypoint in Waypoints) {
            seq.AppendInterval(StayTime);
            seq.Append(transform.DOMove(waypoint.position, MovementDuration));
        }
        seq.SetLoops(-1, LoopType.Yoyo);
    }
}

