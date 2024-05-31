using System;
using TMPro;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private TMP_Text coinText;
    [SerializeField] private AudioClip soundEffect;

    private int coins = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            AddCoin();
            Destroy(other.gameObject);
        }
    }

    private void AddCoin()
    {
        AudioSource.PlayClipAtPoint(soundEffect, Vector3.zero);
        coins += 1;
        coinText.text = $"Coins : {coins}";
    }
}
