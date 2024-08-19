using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LvPlayer
{
    public int lv;
    public Sprite sprite;
    public int tuViLV;
}

public class PlayerFighting : MonoBehaviour
{
    [SerializeField] int tuVi = 3;
    [SerializeField] float maxHP = 10;
    [SerializeField] List<LvPlayer> lvPlayers = new List<LvPlayer>();
    int lvNow = 0;
    float countHP = 0;
    PlayerController playerController;

    private void Start()
    {
        playerController = GetComponent<PlayerController>();
        countHP = maxHP;
    }
    void AddTuVi(int count)
    {
        tuVi += count;
        CheckLV();
        CheckSize();
        UpdateUIScore();
    }
    void GiamHP(int count)
    {
        countHP -= count;
        if(countHP < 0)
        {
            countHP = 0;
            GameOver();
        }
        UpdateUIHP();
    }
    void CheckLV()
    {
        if (lvPlayers[lvNow].tuViLV <= tuVi)
        {
            if(lvNow < lvPlayers.Count - 1)
            {
                lvNow++;
                gameObject.GetComponent<SpriteRenderer>().sprite = lvPlayers[lvNow].sprite;
                Destroy(gameObject.GetComponent<PolygonCollider2D>());
                gameObject.AddComponent<PolygonCollider2D>();
            }
        }
    }
    void CheckSize()
    {
        float countX = transform.localScale.x;
        Vector3 scale = Vector3.one;
        if (countX < 0) scale.x = -1;
        float tuViChuan = 0;
        if (lvNow-1<0) tuViChuan = 0;
        else tuViChuan = lvPlayers[lvNow-1].tuViLV;
        float kichThuocTang = ((float)tuVi - tuViChuan) / 200;
        if(kichThuocTang > 0.15f)
        {
            kichThuocTang = 0.15f;
        }
        scale *= (0.45f + kichThuocTang);
        transform.localScale = scale;
    }
    void UpdateUIScore()
    {
        UIController.Instance.UpdateScoreUI(tuVi);
    }
    void UpdateUIHP()
    {
        UIController.Instance.UpdateHPUI(countHP);
    }
    void GameOver()
    {
        UIController.Instance.GameOver();
        gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (playerController.GetStatusChoang()) return;

        if(collision.gameObject.tag == "Enemy")
        {
            if(tuVi >= collision.gameObject.GetComponent<Enemy>().TuVi)
            {
                AddTuVi(collision.gameObject.GetComponent<Enemy>().ScoreGet);
                collision.gameObject.GetComponent<Enemy>().EnemyDie();
            }
            else
            {
                GiamHP(collision.gameObject.GetComponent<Enemy>().Damage);
                collision.gameObject.GetComponent<Enemy>().EnemyNotActive();
            }
        }
        else if(collision.gameObject.tag == "Rac")
        {
            playerController.Choang();
            Destroy(collision.gameObject);
        }
        else if(collision.gameObject.tag == "PhuDu")
        {
            AddTuVi(1);
            Destroy(collision.gameObject);
        }
    }

}
