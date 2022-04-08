using UnityEngine;

[CreateAssetMenu(fileName = "QuestConfig", menuName = "ConfigQuests/QuestConfig", order = 1)]
public class QuestConfig : ScriptableObject
{
    public int Id;
    public QuestType QuestType;
}

public enum QuestType
{
    Switch
}
