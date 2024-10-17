using System.Collections;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject PlatformPref;

    private LevelGenerator LevelGenerator;
    private int n = 0;
    private Level Test;
    private Level startLevel;
    private bool IsGameOver = false;

    private void Start()
    {
        LevelGenerator = new LevelGenerator(PlatformPref);
        Test = new Level(Vector3.zero);

        startLevel = new Level(Vector3.zero + Vector3.up * 8.0f);
        startLevel.SetPlatform(0, 0);
        LevelGenerator.GenerateLevel(startLevel);

        StartCoroutine(RegenerateLevelWithOffset());
    }

    public void GenerateLevels(Vector3 offset)
    {
        Test = new Level(offset);
        Test.SetPlatform(0, Random.Range(0, 4));
        Test.SetPlatform(1, Random.Range(0, 4));
        Test.SetPlatform(2, Random.Range(0, 3));
        Test.SetPlatform(3, Random.Range(0, 4));
        LevelGenerator.GenerateLevel(Test);


    }

private IEnumerator RegenerateLevelWithOffset()
    {
        while (IsGameOver == false)
        {
            GenerateLevels(Vector3.up * 10f * n);
            yield return new WaitForSeconds(1.7f);
            n++;
        }
    }
    public void GameOver()
    {
        IsGameOver = true;
    }
}
