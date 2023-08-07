using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Mover))]

public class PlayerAnimation : MonoBehaviour
{
    private Animator _animator;
    private Mover _moveController;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _moveController = GetComponent<Mover>();
    }

    private void Update()
    {
        if (_moveController.IsGrounded)
            _animator.SetBool(PlayerAnimator.Params.RunParamHash, Mathf.Abs(Input.GetAxis("Horizontal")) > 0);

        _animator.SetBool(PlayerAnimator.Params.JumpParamHash, !_moveController.IsGrounded);
    }
}
