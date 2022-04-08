using UnityEngine;

[CreateAssetMenu(fileName = "QuestStoryConfig", menuName = "ConfigQuests/QuestStoryConfig", order = 1)]
public class QuestStoryConfig : ScriptableObject
{
    public QuestConfig[] Quests;
    public QuestStoryType QuestStoryType;

}

public enum QuestStoryType
{
    Common,
    Resettable
}
