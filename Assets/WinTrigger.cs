using System;
using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    [SerializeField] private GameManager GameManager;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Console.WriteLine("Touched Win");
        if (other.CompareTag("Player"))
        {
            GameManager.Win();
        }
    }
}
