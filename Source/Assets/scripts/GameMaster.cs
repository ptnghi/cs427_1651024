using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
    public static GameMaster gm;

    public Transform playerPrefab;
    public Transform spawnPoint;
    public int spawnDelay = 2;
    private Player currPlayer;

    public bool isHiding = false;

    [SerializeField]
    private GameObject gameOverUI;

    public Cinemachine.CinemachineVirtualCamera gameCamera;

    private void Start()
    {
        if (gm == null)
        {
            gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        }
    }

    public IEnumerator RespawnPlayer() {

        yield return new WaitForSeconds(spawnDelay);
        gameCamera.Follow = GameObject.Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);
    }

    public void KillPlayer (Player player)
    {
        Destroy(player.gameObject);
        //gm.StartCoroutine(gm.RespawnPlayer());
        gm.GameOver();
    }

    public void GameOver() {
        gameOverUI.SetActive(true);
    }

    public void Update() {
        if (isHiding && Input.GetButtonDown("Interact")) {
            currPlayer.gameObject.SetActive(true);
        }
    }

    public void PlayerHide (Player player) {
        isHiding = true;
        currPlayer = player;
    }

    public void NextStage() {
        string currSceneName = SceneManager.GetActiveScene().name;
        
        int level = currSceneName[currSceneName.Length - 1] - '0';
        level++;
        char next = '0';
        next += (char)level;

        string nextLevel = currSceneName.Substring(0, currSceneName.Length - 1) + next;
        Debug.Log(nextLevel);

        if (nextLevel.Equals("Level3")) {
            nextLevel = "endgame";
        }

        SceneManager.LoadScene(nextLevel);
    }

}
