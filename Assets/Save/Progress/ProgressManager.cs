using FightParty.Save;
using System;
using System.IO;
using UnityEngine;

public class ProgressManager : ISave<ProgressJSON>, ILoad<ProgressJSON>
{
    private ProgressManagerConfig _config;

    public ProgressManager(ProgressManagerConfig config)
        => _config = config;

    public void Save(ProgressJSON info)
    {
        string json = JsonUtility.ToJson(info);

        try
        {
            File.WriteAllText(_config.SavePatch, json);
        }
        catch (Exception e)
        {
            Debug.Log($"Warrning: {e}");
        }
    }

    public ProgressJSON Load()
    {
        if (!File.Exists(_config.SavePatch))
            return new ProgressJSON(_config.DefaultBattleRating, _config.DefaultSurvivalTime, _config.DefaultRingIndex);

        try
        {
            string json = File.ReadAllText(_config.SavePatch);

            return JsonUtility.FromJson<ProgressJSON>(json);
        }
        catch (Exception e)
        {
            Debug.Log($"Warrning: {e}");

            return new ProgressJSON();
        }
    }
}
