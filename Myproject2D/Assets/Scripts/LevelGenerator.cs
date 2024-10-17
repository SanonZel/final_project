using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator 
{
    private GameObject _PlatformPref;

    public LevelGenerator(GameObject PlatformPref) 
    {
    _PlatformPref = PlatformPref;
    }
    ~LevelGenerator()
    {

    }

    public void InitLevelRnd(Level level)
    {
       
        level.SetPlatform(0, Random.Range(0, 4));
        level.SetPlatform(1, Random.Range(0, 4));
        level.SetPlatform(2, Random.Range(0, 3));
        level.SetPlatform(3, Random.Range(0, 4));
    }

    public void GenerateLevel(Level level)
    {
        int rSize = level.Data.GetLength(0);
        int cSize = level.Data.GetLength(1);

        for (int r = 0; r < rSize; r++)
            for (int c = 0; c < cSize; c++)
            {
                if (level.Data[r, c] == '-')
                {
                    GameObject TempPlatform = GameObject.Instantiate(_PlatformPref);
                    TempPlatform.transform.position = level.OriginPoint + new Vector3(c * 3f, r * 2f);
                }
            }
    }
}
