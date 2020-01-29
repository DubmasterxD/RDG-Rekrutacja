using UnityEngine;

namespace RDGRekru.Player
{
    public class PlayerController : MonoBehaviour
    {
        public Fighter fighter { get; private set; }
        public Mover mover { get; private set; }
        public AnimatorController animator { get; private set; }

        Collider collider;

        private void Awake()
        {
            animator = GetComponent<AnimatorController>();
            fighter = GetComponentInChildren<Fighter>();
            mover = GetComponentInChildren<Mover>();
            collider = GetComponent<Collider>();
        }

        private void Update()
        {
            if (!IsBusy())
            {
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    mover.BeginMove();
                }
            }
        }

        private bool IsBusy()
        {
            return transform.parent != null || mover.IsBusy();
        }

        public void ChangeParent(Transform newParent)
        {
            transform.parent = newParent;
        }

        public void ToggleCollider(bool isEnabled)
        {
            collider.enabled = isEnabled;
        }
    }
}