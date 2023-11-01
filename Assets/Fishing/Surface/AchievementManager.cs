using UnityEngine;
using System;
using System.Collections.Generic;

[Serializable]
public class Achievement
{
    public string name;
    public string description;
    public bool isUnlocked;
}

public class AchievementManager : MonoBehaviour
{
    public static AchievementManager instance;
    public List<Achievement> achievements = new List<Achievement>();

    public event Action<Achievement> OnAchievementUnlocked;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void UnlockAchievement(string achievementName)
    {
        Achievement achievement = achievements.Find(a => a.name == achievementName);
        if (achievement != null && !achievement.isUnlocked)
        {
            achievement.isUnlocked = true;
            Debug.Log("Achievement unlocked: " + achievementName);

            OnAchievementUnlocked?.Invoke(achievement);
        }
    }
}

public class AchievementObserver : MonoBehaviour
{
    private void Start()
    {
        AchievementManager.instance.OnAchievementUnlocked += HandleAchievementUnlocked;
    }

    private void OnDestroy()
    {
        AchievementManager.instance.OnAchievementUnlocked -= HandleAchievementUnlocked;
    }

    private void HandleAchievementUnlocked(Achievement achievement)
    {
        Debug.Log("Achievement unlocked: " + achievement.name);
    }
}