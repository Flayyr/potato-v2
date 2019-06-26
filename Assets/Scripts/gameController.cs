using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameController : MonoBehaviour
{
    public GameObject[] objects;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    public int hazardCount;
    private bool stopGame;
    public GameObject player;

    private void Start()
    {
        StartCoroutine (SpawnWaves());
        stopGame = false;
    }

    IEnumerator SpawnWaves ()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            if (!stopGame)
            {
                if (player.GetComponent<lives>().GetLives() <= 0)
                {
                    stopGame = true;
                }
                for (int i = 0; i < hazardCount; i++)
                {
                    GameObject obj = objects[Random.Range(0, objects.Length)];
                    Vector3 spawnPosition = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
                    Quaternion spawnRotation = Quaternion.identity;
                    Instantiate(obj, spawnPosition, spawnRotation);
                    yield return new WaitForSeconds(spawnWait);
                }
            }
            else
            {
                break;
            }
            yield return new WaitForSeconds(waveWait);
        }
    }

    public bool GetStopGame()
    {
        return stopGame;
    }
}