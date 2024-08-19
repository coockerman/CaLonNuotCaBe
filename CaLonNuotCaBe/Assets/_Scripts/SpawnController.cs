using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    [SerializeField] Transform PosPlayerSpawn, EnemySpawnLeft, EnemySpawnRight, RacSpawnTop, PhuDuSpawnBottom;
    [SerializeField] GameObject PlayerPrefab, RacPrefab, PhuDuPrefab;
    [SerializeField] List<GameObject> EnemyListPrefab = new List<GameObject>();
    [SerializeField] float TimeSpawnEnemy = 2, TimeSpawnRac = 5, TimeSpawnPhuDu = 1;

    GameObject PlayerObj;
    List<GameObject> EnemyListObj = new List<GameObject>();
    List<GameObject> RacListObj = new List<GameObject>();
    List<GameObject> PhuDuListObj = new List<GameObject>();
    float countTimeSpawnEnemy = 0, countTimeSpawnRac = 0, countTimeSpawnPhuDu = 0;


    private void Start()
    {
        SpawnPlayer();
    }
    private void Update()
    {
        countTimeSpawnEnemy += Time.deltaTime;
        countTimeSpawnRac += Time.deltaTime;
        countTimeSpawnPhuDu += Time.deltaTime;

        if (countTimeSpawnEnemy > TimeSpawnEnemy)
        {
            SpawnEnemy();
            countTimeSpawnEnemy = 0;
        }
        if (countTimeSpawnRac > TimeSpawnRac)
        {
            SpawnRac();
            countTimeSpawnRac = 0;
        }
        if (countTimeSpawnPhuDu > TimeSpawnPhuDu)
        {
            SpawnPhuDu();
            countTimeSpawnPhuDu = 0;
        }
    }

    void SpawnPlayer()
    {
        PlayerObj = Instantiate(PlayerPrefab, PosPlayerSpawn);
        PlayerObj.transform.position = PosPlayerSpawn.position;
    }

    void SpawnEnemy()
    {
        float t = Random.Range(0, 3);
        if (t <= 1)
        {
            GameObject enemy = Instantiate(GetObjEnemyRandom(), EnemySpawnLeft);
            enemy.GetComponent<AutoMove>().SetTargetMove(AutoMove.Target.Right);
            Vector3 scale = enemy.transform.localScale;
            scale.x *= -1;
            enemy.transform.localScale = scale;
            float ranY = Random.Range(-3, 3);
            Vector3 newPos = new Vector3(EnemySpawnLeft.position.x, EnemySpawnLeft.position.y + ranY, 0);
            enemy.transform.position = newPos;
            EnemyListObj.Add(enemy);
        }
        else if (t > 1)
        {
            GameObject enemy = Instantiate(GetObjEnemyRandom(), EnemySpawnRight);
            enemy.GetComponent<AutoMove>().SetTargetMove(AutoMove.Target.Left);
            float ranY = Random.Range(-3, 3);
            Vector3 newPos = new Vector3(EnemySpawnRight.position.x, EnemySpawnRight.position.y + ranY, 0);
            enemy.transform.position = newPos;
            EnemyListObj.Add(enemy);
        }
    }
    GameObject GetObjEnemyRandom()
    {
        if (UIController.Instance.CountClock < 10)
        {
            int ran = Random.Range(0, EnemyListPrefab.Count - 8);
            if (EnemyListPrefab[ran] != null)
                return EnemyListPrefab[ran];
        }
        else if (UIController.Instance.CountClock < 20)
        {
            int ran = Random.Range(0, EnemyListPrefab.Count - 7);
            if (EnemyListPrefab[ran] != null)
                return EnemyListPrefab[ran];
        }
        else if (UIController.Instance.CountClock < 40)
        {
            int ran = Random.Range(0, EnemyListPrefab.Count - 6);
            if (EnemyListPrefab[ran] != null)
                return EnemyListPrefab[ran];
        }
        else if (UIController.Instance.CountClock < 65)
        {
            int ran = Random.Range(0, EnemyListPrefab.Count - 5);
            if (EnemyListPrefab[ran] != null)
                return EnemyListPrefab[ran];
        }
        else if (UIController.Instance.CountClock < 100)
        {
            int ran = Random.Range(0, EnemyListPrefab.Count - 4);
            if (EnemyListPrefab[ran] != null)
                return EnemyListPrefab[ran];
        }
        else if (UIController.Instance.CountClock < 180)
        {
            int ran = Random.Range(0, EnemyListPrefab.Count - 3);
            if (EnemyListPrefab[ran] != null)
                return EnemyListPrefab[ran];
        }
        else if (UIController.Instance.CountClock < 300)
        {
            int ran = Random.Range(0, EnemyListPrefab.Count - 2);
            if (EnemyListPrefab[ran] != null)
                return EnemyListPrefab[ran];
        }
        else if (UIController.Instance.CountClock < 500)
        {
            int ran = Random.Range(0, EnemyListPrefab.Count);
            if (EnemyListPrefab[ran] != null)
                return EnemyListPrefab[ran];
        }
        return null;

    }
    void SpawnRac()
    {
        GameObject rac = Instantiate(RacPrefab, RacSpawnTop);
        rac.GetComponent<AutoMove>().SetTargetMove(AutoMove.Target.Down);
        float ranX = Random.Range(-7, 7);
        Vector3 newPos = new Vector3(RacSpawnTop.position.x + ranX, RacSpawnTop.position.y, 0);
        rac.transform.position = newPos;
        RacListObj.Add(rac);
    }
    void SpawnPhuDu()
    {
        GameObject phudu = Instantiate(PhuDuPrefab, PhuDuSpawnBottom);
        phudu.GetComponent<AutoMove>().SetTargetMove(AutoMove.Target.Up);
        float ranX = Random.Range(-8, 8);
        Vector3 newPos = new Vector3(PhuDuSpawnBottom.position.x + ranX, PhuDuSpawnBottom.position.y, 0);
        phudu.transform.position = newPos;
        PhuDuListObj.Add(phudu);
    }

}
