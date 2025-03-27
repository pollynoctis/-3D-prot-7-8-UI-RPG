using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public Player player;
    public EnemyManager enemyManager;

    private Enemy currentEnemy;
    private float shieldBreakChance;

    [SerializeField] private TMP_Text playerNameText, playerHealthText, enemyNameText, enemyHealthText;
    [SerializeField] private GameObject shieldButton;

    private void Start()
    {
        GetNextEnemy();
        UpdateText();
    }

    private void GetNextEnemy()
    {
        currentEnemy = enemyManager.GetNextEnemy();

        if (currentEnemy != null)
        {
            UpdateText();
        }
        else
        {
            //do victory thing
        }
    }

    private void UpdateText()
    {
        playerNameText.text = player.CharName;
        enemyNameText.text = currentEnemy != null ? currentEnemy.name : "Everyone is dead!";
        playerHealthText.text = player.health.ToString();
        enemyHealthText.text = currentEnemy != null ? currentEnemy.health.ToString() : "";
    }

    public void DoRound()
    {
        if (currentEnemy == null) return;

        int playerDamage = player.Attack();
        currentEnemy.GetHit(playerDamage);

        if (currentEnemy.health <= 0)
        {
            player.health = 100; 
            GetNextEnemy();
            return;
        }

        int enemyDamage = currentEnemy.Attack();
        player.GetHit(enemyDamage);

        UpdateText();
    }
    
    public void UseShield()
    {
        shieldBreakChance = Random.Range(0f, 1f);
        print(shieldBreakChance);
        if (shieldBreakChance > 0.3f)
        {
            int playerDamage = player.Attack();
            currentEnemy.GetHit(playerDamage);
            int enemyDamage = currentEnemy.Attack();
            player.GetHit(enemyDamage/2);
            UpdateText();
        }
        else
        {
            shieldButton.SetActive(false);
            StartCoroutine(ShieldReload());
            UpdateText();
        }
    }
    private IEnumerator ShieldReload()
    {
        yield return new WaitForSeconds(20f);
        shieldButton.SetActive(true);
    }
}

