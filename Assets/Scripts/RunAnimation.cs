using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(MoveController))]

public class RunAnimation : MonoBehaviour
{
    private Animator _animator;
    private MoveController _moveController;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _moveController = GetComponent<MoveController>();
    }

    private void Update()
    {
        if (_moveController.IsGrounded)
            _animator.SetBool(AnimatorPlayer.Params.RunParamHash, Mathf.Abs(Input.GetAxis("Horizontal")) > 0);

        _animator.SetBool(AnimatorPlayer.Params.JumpParamHash, !_moveController.IsGrounded);
    }
}
