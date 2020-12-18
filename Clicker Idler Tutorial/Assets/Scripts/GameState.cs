using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public GameObject spawnPoint = null;
    public List<GameObject> enemyPrefabs = new List<GameObject>();

    public AutoClicker autoClicker = null;

    Enemy enemyCurrent = null;

    // Start is called before the first frame update
    void Start()
    {
        UnityEngine.Assertions.Assert.IsNotNull(spawnPoint);
        UnityEngine.Assertions.Assert.IsTrue(enemyPrefabs.Count > 0);

        SpawnEnemy();

        if (autoClicker != null)
        {
            autoClicker.theDelegate = AutoClickerDelegateImplementation;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Apply damage over time
        if (enemyCurrent != null)
        {
            // todo: have a subsystem drive the damage over time rate variable
            float damageOverTimeRate = 0.2f;

            // apply damage over time
            float damageOverTime = damageOverTimeRate * Time.deltaTime;
            enemyCurrent.Damage(damageOverTime);

            // if the enemy is dead, destroy it and spawn a new enemy
            if (enemyCurrent.healthCurrent <= 0.0f)
            {
                DestroyEnemy();
                SpawnEnemy();
            }
        }
    }

    public void AutoClickerDelegateImplementation(AutoClicker autoClickerScript)
    {
        //Debug.Log("Auto-clicking!");

        // Click the enemy.
        ClickEnemy();
    }

    public void OnClickDelegateImplementation(OnClick onClickScript)
    {
        // Click the enemy.
        ClickEnemy();
    }

    [ContextMenu("Click an enemy")]
    void ClickEnemy()
    {
        if (enemyCurrent != null)
        {
            // todo: have a subsystem drive the click damage variable
            float damageClick = 2.0f;

            // apply damage
            enemyCurrent.Damage(damageClick);

            // if the enemy is dead, destroy it and spawn a new enemy
            if (enemyCurrent.healthCurrent <= 0.0f)
            {
                DestroyEnemy();
                SpawnEnemy();
            }

            // play the sound fx
            if (enemyCurrent.onClickedAudioClip != null)
            {
                AudioSource audioSource = enemyCurrent.GetComponent<AudioSource>();
                UnityEngine.Assertions.Assert.IsNotNull(audioSource);
                audioSource.PlayOneShot(enemyCurrent.onClickedAudioClip);
            }

            // Add the color lerp.

            var renderer = enemyCurrent.GetComponent<Renderer>();
            UnityEngine.Assertions.Assert.IsNotNull(renderer);

            ColorLerp colorLerp = enemyCurrent.GetComponent<ColorLerp>();
            if (colorLerp != null)
            {
                Destroy(colorLerp);
            }
            enemyCurrent.gameObject.AddComponent<ColorLerp>();
        }
    }

    [ContextMenu("Spawn an enemy")]
    void SpawnEnemy()
    {
        // remove the old enemy if present
        DestroyEnemy();

        // create a new enemy
        int seed = Random.Range(0, enemyPrefabs.Count);
        GameObject enemyPrefab = enemyPrefabs[seed];

        GameObject enemyNew = Instantiate(enemyPrefab, spawnPoint.transform);
        enemyNew.transform.localPosition = Vector3.zero;
        enemyNew.transform.localRotation = Quaternion.identity;

        // store the enemy
        enemyCurrent = enemyNew.GetComponent<Enemy>();
        UnityEngine.Assertions.Assert.IsNotNull(enemyCurrent);
        enemyCurrent.healthCurrent = enemyCurrent.healthMax;

        // set the click delegate
        OnClick enemyClick = enemyCurrent.GetComponent<OnClick>();
        UnityEngine.Assertions.Assert.IsNotNull(enemyClick);
        enemyClick.theDelegate = OnClickDelegateImplementation;
    }

    void DestroyEnemy()
    {
        if (enemyCurrent != null)
        {
            Destroy(enemyCurrent.gameObject);
        }
        enemyCurrent = null;
    }
}
