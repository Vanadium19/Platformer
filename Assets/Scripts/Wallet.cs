using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    private int _coinsCount = 0;

    private void Update()
    {
        Debug.Log(_coinsCount);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Coin coin))
        {
            coin.Collect();
            _coinsCount++;
        }
    }
}
