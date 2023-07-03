using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotSpawner : MonoBehaviour
{
    [SerializeField] private AnimationCurve _botSpawnDelay;
    [SerializeField] private GameObject[] _botPrefabs;
    [SerializeField] private BalanceSheet balance;

    [SerializeField] private Transform _target;

    private int _spawnedBotNumber;

    //

    void Start()
    {
        if (PlayerPrefs.GetInt("Mode") == 2)
        {
            _spawnedBotNumber = 0;
            StartCoroutine(SpawnBot());
        }
    }

    private IEnumerator SpawnBot()
    {
        yield return new WaitForSeconds(_botSpawnDelay.Evaluate(_spawnedBotNumber));
        BotMovement bot = Instantiate(_botPrefabs[Random.Range(0, _botPrefabs.Length - 1)],
            Vector3.right * Random.Range(-balance.MapSize, balance.MapSize) + Vector3.forward * Random.Range(-balance.MapSize, balance.MapSize) + Vector3.up * 2,
            Quaternion.identity).GetComponent<BotMovement>();
        bot.gameObject.SetActive(true);
        _spawnedBotNumber++;

        bot.Target = _target;
        bot.canmove = true;

        yield return StartCoroutine(SpawnBot());
        yield return null;
    }
}
