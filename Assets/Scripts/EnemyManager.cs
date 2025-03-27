using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class EnemyManager : MonoBehaviour
{
    public Enemy CurrentEnemy { get; private set; }
    
    [SerializeField] private List<Enemy> enemies; 
    [SerializeField] private Image enemyImage;
    
    private int currentEnemyIndex = -1;
    private Enemy currentEnemy;
    
    public Enemy GetNextEnemy()
    {
        currentEnemyIndex++;
        if (currentEnemyIndex < enemies.Count)
        {
            CurrentEnemy = enemies[currentEnemyIndex];
            UpdateEnemySprite();
            return CurrentEnemy;
        }
        else
        {
            return null;
        }
    }   
    private void UpdateEnemySprite()
    {
        if (enemyImage != null && CurrentEnemy != null)
        {
            enemyImage.sprite = CurrentEnemy.sprite; 
        }
    }
}
