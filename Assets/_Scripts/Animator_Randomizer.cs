using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animator_Randomizer : MonoBehaviour
{
    public bool randomize_start_frame;

    private void OnEnable()
	{
        var anim = GetComponent<Animator>();
        if (!randomize_start_frame)
        {
            anim.Play("loop");
        }
        else
        {
            float startPoint = Random.Range(0f, 1f);
            anim.Play("loop", -1, startPoint);
        }
    }
}
