using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DoorSystem : MonoBehaviour
{
    // VARIABLES
    [SerializeField] float neededKeys;
    private GameObject player;
    new SpriteRenderer renderer;
    Color closedColor;
    Color openColor;
    public TextMeshProUGUI NeededKeysUI;

    private void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player");
        closedColor = new Color(0.87225f,0f,0f,0.3f);
        openColor = new Color(0f, 1f, 0.2f, 0.3f);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        // OPEN / CLOSE & CHANGE COLOUR BASED ON WHETHER KEYS >= NEEDEDKEYS
        if (other.gameObject.CompareTag("Player"))
            if (player.GetComponent<InventoryScript>().keys >= neededKeys)
                {
                player.GetComponent<InventoryScript>().keys -= neededKeys;
                renderer.color = openColor;
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                }
            else 
                {
                renderer.color = closedColor;
                gameObject.GetComponent<BoxCollider2D>().enabled = true;
                StartCoroutine(ShowNeededKeys());
                }
    }


    IEnumerator ShowNeededKeys()
    {
        NeededKeysUI.text = ($"You need {neededKeys} keys to open this door");
        yield return new WaitForSeconds(2);
        NeededKeysUI.text = ("");

    }

}