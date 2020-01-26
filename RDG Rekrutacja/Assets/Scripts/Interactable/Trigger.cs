using System;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public event Action onTriggerEnter;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            onTriggerEnter();
        }
    }
}
