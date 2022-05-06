using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BarrelScript : MonoBehaviour
{
    // VARIABLES
    [SerializeField] GameObject destroyedBarrel;
    [SerializeField] float boxHealth;
    [SerializeField] string dropName;
    [SerializeField] float dropAmount;
    private GameObject player;
    public TextMeshProUGUI pickedUpText;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("attackBox"))
            {
            boxHealth -= player.GetComponent<FightingScript>().damage;
            }
        if (boxHealth <= 0)
            {
            Instantiate(destroyedBarrel, transform.position, transform.rotation);
            Destroy(gameObject);
            GiveDrop();
            Debug.Log($"You picked up <color=green>{dropAmount} {dropName}</color>");
            }   
    }

    private void GiveDrop()
    {
        if (dropName == "Keys")
            {
            player.GetComponent<InventoryScript>().keys += dropAmount;
            }
        else if (dropName == "Health Potions")
        {
            player.GetComponent<InventoryScript>().healthPotions += dropAmount;
        }
    }
}
