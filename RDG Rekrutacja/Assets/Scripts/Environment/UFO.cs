using RDGRekru.Core;
using UnityEngine;

namespace RDGRekru.Environment
{
    public class UFO : MonoBehaviour
    {
        [SerializeField] Trigger showTrigger = null;

        Animator animator;
        int _showAnimatorTrigger = Animator.StringToHash("Show");

        private void Awake()
        {
            animator = GetComponent<Animator>();
            showTrigger.onTriggerEnter += Show;
        }

        private void Show()
        {
            animator.SetTrigger(_showAnimatorTrigger);
        }
    }
}