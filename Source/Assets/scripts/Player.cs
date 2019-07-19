using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator animator;

    public CharacterController characterController;

    private bool isAtHidingSpot = false;

    private bool isAtFinish = false;

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag.Equals("DeathPlatform") || collision.gameObject.tag.Equals("Enemy")) {
            Debug.Log("Dead");
            GameMaster.gm.KillPlayer(this);
        } else if (collision.gameObject.name.Equals("World")) {
            animator.SetBool("isJumping", false);
        } 
    }


    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "HideSpot") {
            isAtHidingSpot = true;
            Debug.Log("Enter spot");
        }
        else if (collision.gameObject.tag == "Finish") {
            isAtFinish = true;
            Debug.Log("Enter finish");
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("HideSpot")) {
            isAtHidingSpot = false;
            Debug.Log("Exit spot");
        }
        else if (collision.gameObject.CompareTag("Finish")) {
            isAtFinish = false;
            Debug.Log("exit finish");
        }
    }

    private void Update() {
        if (isAtHidingSpot && Input.GetButtonDown("Interact")) {
            GameMaster.gm.PlayerHide(this);
            this.gameObject.SetActive(false);
        }

        if (isAtFinish && Input.GetButtonDown("Interact")) {
            GameMaster.gm.NextStage();
        }
    }

}
