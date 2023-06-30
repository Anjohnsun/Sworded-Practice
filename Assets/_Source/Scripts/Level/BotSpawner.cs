using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotSpawner : MonoBehaviour
{
    [SerializeField] private AnimationCurve _botSpawnDelay;
    [SerializeField] private GameObject _botPrefab;
    [SerializeField] private BalanceSheet balance;

    private int _spawnedBotNumber;

    //

    void Start()
    {
        _spawnedBotNumber = 0;
        StartCoroutine(SpawnBot());
    }

    private IEnumerator SpawnBot()
    {
        yield return new WaitForSeconds(_botSpawnDelay.Evaluate(_spawnedBotNumber));
        GameObject bot = Instantiate(_botPrefab,
            Vector3.right * Random.Range(-balance.MapSize, balance.MapSize) + Vector3.forward * Random.Range(-balance.MapSize, balance.MapSize)+Vector3.up*2,
            Quaternion.identity);
        bot.gameObject.SetActive(true);
        _spawnedBotNumber++;
        yield return StartCoroutine(SpawnBot());
        yield return null;
    }
}
