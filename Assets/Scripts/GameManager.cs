using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    [Tooltip("Management")]
    public Player player;
    public Enemy currentEnemy;
    public EnemyManager enemyManager;
    public int playerDamage, enemyDamage;
    
    [Tooltip("Texts")]
    [SerializeField] private TMP_Text playerNameText, playerHealthText, enemyNameText, enemyHealthText;
    
    [Tooltip("Buttons")]
    [SerializeField] private GameObject shieldButton, attackButton, healButton, loseScreen, winScreen, shakable;

    [Tooltip("Audio")]
    [SerializeField] private AudioClip yayClip;
    [SerializeField] private AudioSource source;
    
    
    
    private float shieldBreakChance;
    

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
            source.PlayOneShot(yayClip);
            winScreen.SetActive(true);
            shakable.SetActive(false);
        }
    }

    private void UpdateText()
    {
        playerNameText.text = player.CharName;
        enemyNameText.text = currentEnemy != null ? currentEnemy.name : "Everyone is dead!";
        playerHealthText.text = player.Health.ToString();
        enemyHealthText.text = currentEnemy != null ? currentEnemy.Health.ToString() : "";
    }

    public void DoRound()
    {
        if (currentEnemy == null) return;

        playerDamage = player.Attack();
        currentEnemy.GetHit(playerDamage);
        
        enemyDamage = currentEnemy.Attack();
        player.GetHit(enemyDamage);

        UpdateText();
        CheckEnemyHealth();
        CheckPlayerHealth();
    }
    
    public void UseShield()
    {
        shieldBreakChance = Random.Range(0f, 1f);
        //print(shieldBreakChance);
        if (shieldBreakChance > 0.3f)
        {
            int playerDamage = player.Attack();
            currentEnemy.GetHit(player.activeWeapon);
            int enemyDamage = currentEnemy.Attack();
            player.GetHit(enemyDamage/2);
            UpdateText();
        }
        else
        {
            shieldButton.SetActive(false);
            StartCoroutine(ButtonReload(20f, shieldButton));
            UpdateText();
        }
        CheckEnemyHealth();
        CheckPlayerHealth();
    }
    private IEnumerator ButtonReload(float loadingTime, GameObject toDisable)
    {
        yield return new WaitForSeconds(loadingTime);
        toDisable.SetActive(true);
    }

    private void CheckEnemyHealth()
    {
        if (currentEnemy.Health <= 0)
        {
            player.Health = 100; 
            GetNextEnemy();
            return;
        }
    }

    private void CheckPlayerHealth()
    {
        if (player.Health <= 0)
        {
            loseScreen.SetActive(true);
        }
    }

    public void Heal()
    {
        if (player.Health<50)
        {
            player.Health += 15;
        }
        else
        {
            player.Health += 5;
        }
        healButton.SetActive(false);
        UpdateText();
        StartCoroutine(ButtonReload(15f, healButton));
    }
}

