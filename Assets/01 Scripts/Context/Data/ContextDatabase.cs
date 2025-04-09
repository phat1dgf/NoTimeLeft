using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ContextDatabase", menuName = "Game/ContextDatabase")]
public class ContextDatabase : ScriptableObject
{
    public List<ContextData> contexts;
}

