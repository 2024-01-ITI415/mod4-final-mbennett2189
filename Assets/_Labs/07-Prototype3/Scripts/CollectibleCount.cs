using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectibleCount : MonoBehaviour
{
    TMPro.TMP_Text text;
    int count;
    public GameObject winText;

    private void Awake()
    {
        text = GetComponent<TMPro.TMP_Text>();
        winText.SetActive(false);  
    }



    private void Start() => UpdateCount();

    private void OnEnable() => Collectible.OnCollected += OnCollectibleCollected;
    private void OnDisable() => Collectible.OnCollected -= OnCollectibleCollected;


    void OnCollectibleCollected()
    {
        count++;
        UpdateCount();
        if (count == 32)
        {
            winText.SetActive(true);
            Time.timeScale = 0;
        }
    }

    void UpdateCount()
    {
        text.text = $"Coffee: {count} / 32";
    }
}
