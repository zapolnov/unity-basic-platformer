using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Animator animator;
    float oldX;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        animator.SetBool("TouchingGround", true);
        oldX = transform.position.x;
    }

    void Update()
    {
        float newX = transform.position.x;
        float deltaX = newX - oldX;
        oldX = newX;

        var r = animator.transform.localEulerAngles;
        if (deltaX < 0.0f)
            r.y = 180.0f;
        else if (deltaX > 0.0f)
            r.y = 0.0f;
        animator.transform.localEulerAngles = r;

        animator.SetBool("Running", Mathf.Abs(deltaX) > 0.001f);
    }

    public void Kill()
    {
        Destroy(gameObject);
    }
}
