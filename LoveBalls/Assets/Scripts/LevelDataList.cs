using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New List", menuName = "Preset/List")]
public class LevelDataList: ScriptableObject {

    public new string name;
    public int[] starsRequired;
}
