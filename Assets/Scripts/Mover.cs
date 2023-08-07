using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]

public class Mover : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 400f;
    [SerializeField] private float _movementSmoothing = 0.05f;
    [SerializeField] private float _dashSmoothing = 0.01f;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private Transform _groundChecker;
    [SerializeField] private float _speed = 1f;
    [SerializeField] private float _dashRange = 1f;

    private float _groundedRadius = 0.2f;
    private bool _isGrounded;
    private Rigidbody2D _rigidBody2D;
    private SpriteRenderer _spriteRenderer;
    private Vector3 _velocity = Vector3.zero;

    public bool IsGrounded => _isGrounded;

    private void Start()
    {
        _rigidBody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Move(Input.GetAxisRaw("Horizontal") * _speed);

        if (Input.GetButton("Jump"))
            Jump();

        if (Input.GetKeyDown(KeyCode.LeftShift))
            Dash(Input.GetAxisRaw("Horizontal") * _dashRange);
    }

    private void FixedUpdate()
    {
        _isGrounded = false;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(_groundChecker.position, _groundedRadius, _groundLayer);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                _isGrounded = true;
            }
        }
    }

    private void Dash(float move)
    {
        if (_isGrounded)
        {
            Vector3 targetVelocity = new Vector2(move, _rigidBody2D.velocity.y);

            _rigidBody2D.velocity = Vector3.SmoothDamp(_rigidBody2D.velocity, targetVelocity, ref _velocity, _dashSmoothing);
        }
    }

    private void Jump()
    {
        if (_isGrounded)
        {
            _isGrounded = false;
            _rigidBody2D.AddForce(new Vector2(0f, _jumpForce));
        }
    }

    private void Move(float move)
    {
        Vector3 targetVelocity = new Vector2(move, _rigidBody2D.velocity.y);

        _rigidBody2D.velocity = Vector3.SmoothDamp(_rigidBody2D.velocity, targetVelocity, ref _velocity, _movementSmoothing);

        Flip();
    }

    private void Flip()
    {
        float direction = Input.GetAxisRaw("Horizontal");

        if (direction != 0)
            _spriteRenderer.flipX = direction < 0;
    }
}
