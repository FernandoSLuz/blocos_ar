using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Experience_Manager : MonoBehaviour
{
    public static Experience_Manager instance;
	public Experience_States experience_state = Experience_States.menu;
	public GameObject scan_image;
	private void Awake()
	{
		instance = this;
	}

	public void Start_Ar(){
		experience_state = Experience_States.detecting;
		Canvas_Manager.instance.ChangePanel(Canvas_Manager.instance.ar_panel);
		scan_image.SetActive(true);
	}
	public void End_Ar()
	{
		experience_state = Experience_States.menu;
		Canvas_Manager.instance.ChangePanel(Canvas_Manager.instance.menu_panel);
		scan_image.SetActive(false);
	}
	public void Target_Detected(GameObject target)
	{
		experience_state = Experience_States.detected;
		scan_image.SetActive(false);
		target.SetActive(true);
	}
	public void Target_Lost(GameObject target)
	{
		target.SetActive(false);
		scan_image.SetActive(true);
		experience_state = Experience_States.detecting;
	}

	[System.Serializable]
	public enum Experience_States{ 
		menu,
		detecting,
		detected
	}
}
