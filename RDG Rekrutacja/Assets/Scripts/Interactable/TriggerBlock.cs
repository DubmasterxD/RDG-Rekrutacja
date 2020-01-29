using RDGRekru.Core;
using UnityEngine;

namespace RDGRekru.Interactable
{
    public class TriggerBlock : MonoBehaviour
    {
        [SerializeField] Trigger useTrigger;
        [SerializeField] Trigger resetTrigger;

        Animator animator;
        int _useAnimatorTrigger = Animator.StringToHash("Use");
        int _resetAnimatorTrigger = Animator.StringToHash("Reset");

        private void Awake()
        {
            animator = GetComponent<Animator>();
            useTrigger.onTriggerEnter += Use;
            resetTrigger.onTriggerEnter += ResetBlock;
        }

        private void Use()
        {
            animator.SetTrigger(_useAnimatorTrigger);
        }

        private void ResetBlock()
        {
            animator.SetTrigger(_resetAnimatorTrigger);
        }
    }
}