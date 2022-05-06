using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FightingScript : MonoBehaviour
{
    // VARIABLES
    public float damage;
    private bool isBlocking;
    private bool onCooldown;
    public float Health;
    private float maxHealth, minHealth;
    private Animator animator;
    private GameObject player;
    private  Rigidbody2D rb;
    private GameObject attackBox;
    public TextMeshProUGUI HealthText;

    void Start()
    {
        damage = 10f;
        isBlocking = false;
        Health = 40f;
        maxHealth = 100f;
        minHealth = 0f;
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        attackBox = GameObject.FindGameObjectWithTag("attackBox");
        attackBox.SetActive(false);
    }

    void Update()
    {

        // ATTACKING
        if (Input.GetKeyDown(KeyCode.Mouse0) && isBlocking == false && onCooldown == false)
            {
            // attackBox.SetActive(true);
            animator.SetTrigger("Attack");
            StartCoroutine(AttackCooldown());
            }

        // BLOCKING
        if (Input.GetKey(KeyCode.Mouse1))
            {
            isBlocking = true;
            animator.SetBool("isBlocking", true);
            }
        else
            {
            isBlocking = false;
            animator.SetBool("isBlocking", false);
            }

        // HEALING
        if (Input.GetKey(KeyCode.F) && Health > minHealth && Health < maxHealth)
            {
            animator.SetBool("isHealing", true);
            Health = Health + 0.025f;
            player.GetComponent<MovementScript>().enabled = false;
            animator.SetBool("isRunning", false);
            }
        else
            {
            animator.SetBool("isHealing", false);
            player.GetComponent<MovementScript>().enabled = true;
            }
        if (Health > maxHealth)
            Health = maxHealth;
        else if (Health < minHealth)
            Health = minHealth;

        // USE HEALTHPOTION
        if (player.GetComponent<InventoryScript>().healthPotions > 0 && Health < maxHealth && Input.GetKeyDown(KeyCode.R))
            {
            player.GetComponent<InventoryScript>().healthPotions--;
            Health += 15;
            }

        // DEATH
        if (Health <= 0)
            Destroy(gameObject);

        HealthText.text = ($"Health - {Health.ToString()}");
    }


    // HURTBOX CHECK
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy") && isBlocking == false)
            {
            animator.SetTrigger("Hurt");
            Health -= damage; 
            }
        if (other.gameObject.CompareTag("deadTrigger"))
            {
            Destroy(gameObject);
            Health = 0;
            }
    }

    // ATTACK COOLDOWN & ATTACKBOX
    IEnumerator AttackCooldown()
    {
        onCooldown = true;
        attackBox.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        attackBox.SetActive(false);
        yield return new WaitForSeconds(0.8f);
        onCooldown = false;
    }
}
