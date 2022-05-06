using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryScript : MonoBehaviour
{
    // VARIABLES
    public TextMeshProUGUI Keys;
    public TextMeshProUGUI HPotions;
    public float healthPotions;
    public float keys;


    private void Start()
    {
        keys = 0f;
        healthPotions = 1f;
    }

    private void Update()
    {
        Keys.text = ($"Keys - {keys.ToString()}");
        HPotions.text = ($"Health Potions - {healthPotions.ToString()}");
    }
}
