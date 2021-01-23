using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] float movementVelocity;
    [SerializeField] float jumpVelocity;

    Rigidbody body;
    GroundDetector groundDetector;
    Animator animator;
    Vector2 direction;

    void Start()
    {
        body = GetComponent<Rigidbody>();
        groundDetector = GetComponentInChildren<GroundDetector>();
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        Vector3 velocity = body.velocity;
        velocity.x = direction.x * movementVelocity;

        if (direction.y > 0.0f && groundDetector.IsAtGround) {
            velocity.y = jumpVelocity;
        }

        body.velocity = velocity;

        animator.SetBool("Running", direction.x != 0.0f);
        animator.SetBool("TouchingGround", groundDetector.IsAtGround);

        var r = animator.transform.localEulerAngles;
        if (direction.x < 0.0f)
            r.y = 180.0f;
        else if (direction.x > 0.0f)
            r.y = 0.0f;
        animator.transform.localEulerAngles = r;
    }

    void OnMove(InputValue value)
    {
        direction = value.Get<Vector2>();
    }
}
