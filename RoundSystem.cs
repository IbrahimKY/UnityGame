using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class RoundSystem : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] doors; // 3 kapın

    public int[] rounds = { 3, 5, 10 };
    private int currentRound = 0;

    public TextMeshProUGUI roundText;
    public GameObject roomClearedText;

    private List<GameObject> activeEnemies = new List<GameObject>();

    private void Start()
    {
        if (roomClearedText != null)
        {
            roomClearedText.SetActive(false);
        }

        SpawnWave();
    }

    private void Update()
    {

        activeEnemies.RemoveAll(enemy => enemy == null);

        UpdateUI();

        if (activeEnemies.Count == 0)
        {
            currentRound++;

            if (currentRound < rounds.Length)
            {
                SpawnWave();
            }
            else
            {
                if (roomClearedText != null)
                {
                    roomClearedText.SetActive(true);
                }

                Debug.Log("Tüm roundlar bitti.");
                this.enabled = false;
            }
        }
    }

    void SpawnWave()
    {
        activeEnemies.Clear();

        for (int i = 0; i < rounds[currentRound]; i++)
        {
            Transform door = doors[Random.Range(0, doors.Length)];

            GameObject newEnemy = Instantiate(enemyPrefab, door.position, Quaternion.identity);
            activeEnemies.Add(newEnemy);
        }
    }

    void UpdateUI()
    {
        if (roundText != null)
        {
            roundText.text = "Round Sayisi: " + (currentRound + 1) + "\nKalan Dusman: " + activeEnemies.Count;
        }
    }
}