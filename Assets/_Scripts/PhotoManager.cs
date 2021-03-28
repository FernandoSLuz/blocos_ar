using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotoManager : MonoBehaviour
{
    public static PhotoManager instance;
    public GameObject characterSelection;
    public GameObject photoCanvas;
    public GameObject ShareCanvas;

    public GameObject[] Screens;

    public Sprite[] Characters;

    private void Awake()
    {
        instance = this;
    }

    public void SelectCharacter(int index)
    {
        photoCanvas.GetComponent<PhotoCanvas>().character.sprite = Characters[index -1];
        photoCanvas.GetComponent<PhotoCanvas>().character.gameObject.SetActive(true);
        //ToggleScreens(1);
    }

    public void ToggleScreens(int index)
    {
        for (int i = 0; i < Screens.Length; i++)
        {
            Screens[i].SetActive(i == index);
            photoCanvas.GetComponent<PhotoCanvas>().character.gameObject.SetActive(true);
        }
    }
}
