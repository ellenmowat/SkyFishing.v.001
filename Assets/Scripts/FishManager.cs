using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishManager : MonoBehaviour
{
    private float timer;
    private float maxTimer;
    private Vector2 screenBounds;

    public int spawnX = 0;
    public Transform fishCollect;
    public string spawning = "no";

    public float timerMin = 3f;
    public float timerMax = 10f;


    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        maxTimer = Random.Range(timerMin, timerMax);

        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        StartCoroutine("SpawnFishTimer");

    }

    private void Update()
    {
        spawnX = Random.Range(-4, 4);
        //Debug.Log(spawnX);
        if (spawning == "no")
        {
            spawning = "yes";
            StartCoroutine(SpawnFishTimer());
        }
    }

    //Timer for how long an enemy will spawn
    IEnumerator SpawnFishTimer()
    {
        maxTimer = Random.Range(timerMin, timerMax);
        timer += 0.5f;
        yield return new WaitForSeconds(maxTimer);
        Instantiate(fishCollect, new Vector2(spawnX, -18), fishCollect.rotation);
        spawning = "no";
    }
}
