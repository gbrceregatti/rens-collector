using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimentos : MonoBehaviour
{
    [SerializeField] private LayerMask platformsLayerMask;
    private Rigidbody2D rigidbody2d;
    private BoxCollider2D boxCollider2d;

    public float jumpSpeed;
    public float moveSpeed;

    private void Awake()
    {
        rigidbody2d = transform.GetComponent<Rigidbody2D>();
        boxCollider2d = transform.GetComponent<BoxCollider2D>();
    }

    // Start is called before the first frame update
    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody2d.velocity = Vector2.up * jumpSpeed;
        }

        HandleMoviment();
    }

    private void HandleMoviment()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rigidbody2d.velocity = new Vector2(-moveSpeed, rigidbody2d.velocity.y);
        } else
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                rigidbody2d.velocity = new Vector2(+moveSpeed, rigidbody2d.velocity.y);
            } else
            {
                rigidbody2d.velocity = new Vector2(0, rigidbody2d.velocity.y);
            }
        }
    }

    private bool IsGrounded()
    {
        RaycastHit2D raycastHit2d = Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size, 0f, Vector2.down, .1f, platformsLayerMask);
        return raycastHit2d.collider != null;
    }
}
