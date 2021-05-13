using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class SkillsEventSystem : MonoBehaviour
{
    public static UnityEvent<SkillNode, int> OnSkillUnlock;

    private void Awake()
    {
        OnSkillUnlock = new UnityEvent<SkillNode, int>();
    }

    public static void UnlockSkill(SkillNode node, int level)
    {
        OnSkillUnlock?.Invoke(node, level);
    }


}
