using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObject : MonoBehaviour
{
    public GameObject enemyUI;
    public int EnemyID;
    public string enemyReading;
    public delegate void OnEnemyHit();
    public OnEnemyHit onEnemyhit;
    public delegate void OnEnemyDie();
    public OnEnemyHit onEnemyDie;

    public int hitPoints = 5;
    public int scorePoints = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        EnemyEscaped();
    }
    private void EnemyEscaped()
    {
        if (transform.position.z <= -10f)
        {
            EnemyManager.access.RemoveEnemyFromList(gameObject, enemyUI, enemyReading);
            EnemyManager.access.EscapedEnemy();

            Destroy(enemyUI);
            Destroy(gameObject);
        }
    }
    public void ReduceScorePoints()
    {
        if (scorePoints > 5)
            scorePoints -= 1;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            hitPoints--;
            if (hitPoints <= 0)
            {
                LevelManager.access.GetPoints(scorePoints);

                EnemyManager.access.RemoveEnemyFromList(gameObject, enemyUI, enemyReading);
                EnemyManager.access.DefeatEnemy();
                Destroy(enemyUI);

                onEnemyDie?.Invoke();
            }

            //Destroy(gameObject);

            onEnemyhit?.Invoke();
        }

    }
}
