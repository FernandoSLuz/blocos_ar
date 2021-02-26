using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animator_Randomizer : MonoBehaviour
{
    public bool randomize_start_frame;
    public string animation_name = "loop";

    private void OnEnable()
	{
        var anim = GetComponent<Animator>();
        if (!randomize_start_frame)
        {
            anim.Play(animation_name);
        }
        else
        {
            float startPoint = Random.Range(0f, 1f);
            anim.Play(animation_name, -1, startPoint);
        }
    }
}
