using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private float _phaseIncrements = 5.0f;
    private float _timer = 0.0f;
    private int _phase = 0;

    public GameObject defaultEnemy;

    [SerializeField] private List<WaveInfo> _waveAmount = new List<WaveInfo>();

    [SerializeField] private Vector2 _minMaxSpawnX = new Vector2(0.0f, 0.0f);
    [SerializeField] private float _spawnY = 60.0f;
    private Vector3 _spawnRotation = new Vector3(0.0f, 0.0f, 180.0f);

    void Update()
    {
        _timer += Time.deltaTime;
        switch (_phase)
        {
            case 0:
                if (_timer >= 0)
                {
                    //spawn first set of enemies
                    for(int i = 0; i < _waveAmount[_phase].amountToSpawn; i++)
                    {
                        SpawnEnemy();
                    }
                    _phase = 1;
                }
                break;
            case 1:
                if (_timer >= _phaseIncrements)
                {
                    //spawn second set of enemies
                    _phase = 2;
                }
                break;
            case 2:
                if (_timer <= _phaseIncrements * 2)
                {
                    //spawn second set of enemies
                    _phase = 3;
                }
                break;
            case 3:
                if (_timer <= _phaseIncrements * 3)
                {
                    ResetPhases();
                }
                break;
        }
    }

    private void ResetPhases()
    {
        //Reset phase
        _phase = 0;
        _timer = 0.0f;
        //_phaseIncrements *= 0.9f; //Make phases come faster
    }

    private void SpawnEnemy()
    {
        GameObject go;
        if (_waveAmount[_phase].enemyToSpawn == null)
        {
            go = defaultEnemy;
        }
        else
        {
            float f = Random.Range(0.0f, 1.0f);
            if(f < _waveAmount[_phase].percentageChanceToSpawnSpecial)
            {
                go = _waveAmount[_phase].enemyToSpawn;
            }
            else
            {
                go = defaultEnemy;
            }
            
        }

        Instantiate(go, new Vector3(Random.Range(_minMaxSpawnX.x, _minMaxSpawnX.y), _spawnY, 0.0f), Quaternion.Euler(_spawnRotation));
    }
}

[System.Serializable]
public class WaveInfo
{
    public int amountToSpawn;
    public GameObject enemyToSpawn;
    public float percentageChanceToSpawnSpecial = 1;


}