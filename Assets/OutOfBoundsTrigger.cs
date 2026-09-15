using System;
using Unity.VisualScripting;
using UnityEngine;

public class OutOfBoundsTrigger : MonoBehaviour
{
    [SerializeField] GameManager GameManager;
    public bool fellOutOfBounds { get; private set; }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Console.WriteLine("Out Of Bounds");
        if (other.CompareTag("Player"))
        {
            GameManager.FellOutOfBounds();
        }
    }
}
