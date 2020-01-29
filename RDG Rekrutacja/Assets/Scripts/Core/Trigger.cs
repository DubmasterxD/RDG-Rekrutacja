using System;
using UnityEngine;

namespace RDGRekru.Core
{
    public class Trigger : MonoBehaviour
    {
        public event Action onTriggerEnter;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player") || other.CompareTag("Trigger"))
            {
                if (onTriggerEnter != null)
                {
                    onTriggerEnter();
                }
            }
        }
    }
}