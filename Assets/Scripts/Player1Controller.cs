using UnityEngine;
using System.Collections;

public class Player1Controller : MonoBehaviour
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

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Move();

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            StartCoroutine(Dash());
        }
    }

    void Move()
    {
        float h = 0;
        float v = 0;

        if (Input.GetKey(KeyCode.A))
            h = -1;

        if (Input.GetKey(KeyCode.D))
            h = 1;

        if (Input.GetKey(KeyCode.W))
            v = 1;

        if (Input.GetKey(KeyCode.S))
        v = -1;

        Vector3 direction = new Vector3(h, 0, v).normalized;

        Vector3 velocity = direction * moveSpeed;
        velocity.y = rb.velocity.y;

        rb.velocity = velocity;
    }

    void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    IEnumerator Dash()
    {
        canDash = false;

        Vector3 direction = transform.forward;

        rb.AddForce(direction * dashForce, ForceMode.Impulse);

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