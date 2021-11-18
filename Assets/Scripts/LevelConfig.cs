using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelConfig", menuName = "Config/LevelConfig")]
public class LevelConfig : ScriptableObject
{
    [SerializeField] private List<Levels> _allLevels;

    public Levels GetLevelByIndex(int index)
    {
        if (_allLevels == null || _allLevels.Count == 0)
        {
            return null;
        }
        
        return _allLevels[index >= _allLevels.Count? _allLevels.Count - 1 : index];
    }
}
