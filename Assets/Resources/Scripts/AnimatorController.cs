using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Animator))]
public class AnimatorController : MonoBehaviour
{
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void PlayTriggerAnimation(string trigger) => anim.SetTrigger(trigger);

    public void PlayBoolAnimation(bool boolValue, string boolName) => anim.SetBool(boolName, boolValue);
    public void PlayFloatAnimation(float floatValue, string floatName) => anim.SetFloat(floatName, floatValue);
}
