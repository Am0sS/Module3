using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{

    public float Health;
    Animator anim;
    public GameObject deadBoss;


    private void Start() {
        Health = 120f;
        deadBoss.SetActive(false);
    }

    private void Update()
     {
        if (Health <= 0)
            deadBoss.SetActive(true);
    }

    

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("attackBox"))
        Health -= 20f;
    }



}
