using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Canvas_Manager : MonoBehaviour
{
    public static Canvas_Manager instance;
	public GameObject menu_panel;
	public GameObject ar_panel;
	public GameObject screenshot_panel;
	public GameObject tutorial_panel;
	public GameObject wait_panel;

	[Header("Selfie Screen")]
	public GameObject character_canvas;
	public GameObject photo_canvas;
	[Header("Starting/Current panel")]
	public GameObject current_panel;
	private void Awake()
	{
		instance = this;
	}
	public IEnumerator	Start(){
		if(SceneManager.GetActiveScene().name == "Main"){
			if(!Experience_Manager.started)
			{
				Experience_Manager.started = true;
				wait_panel.SetActive(true);
				current_panel.SetActive(true);
				current_panel.GetComponent<Animator>().Play("entry");
				yield return new WaitForSeconds(3.0f);
				wait_panel.SetActive(false);
			}
			else{
				wait_panel.SetActive(true);
				current_panel.SetActive(true);
				current_panel.GetComponent<Animator>().Play("in");
				yield return new WaitForSeconds(0.5f);
				wait_panel.SetActive(false);
			}

		}
	}
	public void ChangePanel(GameObject new_panel){
		StartCoroutine(TransitionROutine(new_panel));
	}
	public IEnumerator TransitionROutine(GameObject new_panel)
	{
		new_panel.SetActive(true);
		wait_panel.SetActive(true);
		current_panel.GetComponent<Animator>().Play("out");
		new_panel.GetComponent<Animator>().Play("in");
		yield return new WaitForSeconds(0.5f);
		current_panel.SetActive(false);
		current_panel = new_panel;
		wait_panel.SetActive(false);
	}
}
