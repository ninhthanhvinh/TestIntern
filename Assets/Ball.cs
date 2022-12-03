using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Transform newBall;
    public string ballColor;
    public GameObject prefab;
    public Transform parent;
    private bool isPassed;

    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.instance;
        isPassed = false;
        gameObject.transform.Find("Sprite").gameObject.SetActive(true);
    }
    private void OnTriggerEnter(Collider collider)
    {
        var player = collider.GetComponent<Player>();
        if (player != null)
        {
            if (!isPassed)
            {

            
                if(player.GetPlayerColor() == ballColor)
                {
                    player.point += 1;
                    player.ChangeColor();
                    StartCoroutine(SpawnCoolDown());
                    Debug.Log("spawn");
                }
                else
                {
                    gameManager.LoseGame();
                }
                if (player.point == 10)
                    gameManager.WinGame();
            }
        

        }
    }

    IEnumerator SpawnCoolDown()
    {
        gameObject.transform.Find("Sprite").gameObject.SetActive(false);
        yield return new WaitForSeconds(1f);
        newBall = Instantiate(prefab, Vector3.zero, Quaternion.identity, parent).transform;
        newBall.position = new Vector3(Random.Range(-10, 10), 1f, Random.Range(-10, 10));
        newBall.GetComponent<Ball>().ballColor = ballColor;
        Debug.Log(newBall.position);
        Destroy(gameObject);
    }
}
