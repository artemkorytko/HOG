using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="LevelConfig",menuName ="Config/LevelConfig")]
public class LevelConfig : ScriptableObject
{
    [SerializeField] private List<Level> _allLevel;

    public Level GetLevelByIndex(int index)
    {
        if(_allLevel == null || _allLevel.Count == 0)
        {
            return null;
        }
        var i = index >= _allLevel.Count ? _allLevel.Count - 1 : index;
        return _allLevel[i];
    }
}
