using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class PhotoCanvas : MonoBehaviour
{
    public SpriteRenderer character;
    public ShareScreen share;
    public GameObject screenShotButton;
    public AudioSource audioSource;

    public void TakeScreenShot()
    {
        audioSource.Play();
        screenShotButton.SetActive(false);
        StartCoroutine(TakeScreenShotRoutine());
    }

    private IEnumerator TakeScreenShotRoutine()
    {
        yield return new WaitForEndOfFrame();

        Texture2D screenShot = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        screenShot.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        screenShot.Apply();

        string filePath = Path.Combine(Application.temporaryCachePath, "Shared Image.png");
        File.WriteAllBytes(filePath, screenShot.EncodeToPNG());

        byte[] bytes = File.ReadAllBytes(Path.Combine(Application.temporaryCachePath, "Shared Image.png"));
        Texture2D thisTexture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        thisTexture.LoadImage(bytes);
        thisTexture.name = "Shared Image.png";
        share.screenShot.texture = thisTexture;
        share.filePath = filePath;
        PhotoManager.instance.ToggleScreens(2);
        Destroy(screenShot);
        screenShotButton.SetActive(true);
    }
}
