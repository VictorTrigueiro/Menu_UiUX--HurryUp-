using UnityEngine;
using System.Collections;

public class Player2Controller : MonoBehaviour
{
    [Header("Movimento")]
    public float moveSpeed = 5f;

    [Header("Pulo")]
    public float jumpForce = 7f;

    [Header("Dash")]
    public float dashForce = 12f;
    public float dashDuration = 0.2f;
    public float dashCooldown = 1f;

    private Rigidbody rb;
    private bool isGrounded;
    private bool canDash = true;
    private bool isDashing;

    private Vector3 moveDirection;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Move();

        if ((Input.GetKeyDown(KeyCode.Return) ||
             Input.GetKeyDown(KeyCode.KeypadEnter)) && isGrounded)
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.RightControl) && canDash)
        {
            StartCoroutine(Dash());
        }
    }

    void Move()
    {
        float h = 0;
        float v = 0;

        if (Input.GetKey(KeyCode.LeftArrow))
            h = -1;

        if (Input.GetKey(KeyCode.RightArrow))
            h = 1;

        if (Input.GetKey(KeyCode.UpArrow))
            v = 1;

        if (Input.GetKey(KeyCode.DownArrow))
            v = -1;

        moveDirection = new Vector3(h, 0, v).normalized;

        if (!isDashing)
        {
            Vector3 velocity = moveDirection * moveSpeed;
            velocity.y = rb.linearVelocity.y;

            rb.linearVelocity = velocity;
        }
    }

    void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    IEnumerator Dash()
    {
        if (moveDirection == Vector3.zero)
            yield break;

        canDash = false;
        isDashing = true;

        rb.linearVelocity = new Vector3(
            moveDirection.x * dashForce,
            rb.linearVelocity.y,
            moveDirection.z * dashForce
        );

        yield return new WaitForSeconds(dashDuration);

        isDashing = false;

        yield return new WaitForSeconds(dashCooldown);

        canDash = true;
    }

    private void OnCollisionStay(Collision collision)
    {
        isGrounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }
}