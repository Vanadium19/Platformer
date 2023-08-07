using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    public static class Params
    {
        public static readonly int RunParamHash = Animator.StringToHash("IsRunning");
        public static readonly int JumpParamHash = Animator.StringToHash("IsJumping");
    }
}
