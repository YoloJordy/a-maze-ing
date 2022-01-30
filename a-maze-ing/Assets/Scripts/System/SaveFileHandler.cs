using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData
{
    public float totalPlayTime;
    public float bestTimeL1;
    public float bestTimeL2;
    public float bestTimeL3;
}

public class SaveFileHandler : MonoBehaviour
{
    public static void SaveTimeData(int level, float time)
    {
        string json = File.ReadAllText(Application.dataPath + "/StreamingAssets/saveFile.json");
        SaveData saveData = JsonUtility.FromJson<SaveData>(json);

        saveData.totalPlayTime += time;
        switch (level)
        {
            case 1:
                if (time > saveData.bestTimeL1) saveData.bestTimeL1 = time;
                break;
            case 2:
                if (time > saveData.bestTimeL2) saveData.bestTimeL2 = time;
                break;
            case 3:
                if (time > saveData.bestTimeL3) saveData.bestTimeL3 = time;
                break;
        }       

        json = JsonUtility.ToJson(saveData);
        File.WriteAllText(Application.dataPath + "/StreamingAssets/saveFile.json", json);
    }

    public static SaveData LoadData()
    {
        string json = File.ReadAllText(Application.dataPath + "/StreamingAssets/saveFile.json");
        SaveData saveData = JsonUtility.FromJson<SaveData>(json);

        return saveData;
    }
}
