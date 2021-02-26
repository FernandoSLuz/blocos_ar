using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ShareScreenShot : MonoBehaviour
{
    public void ShareImage()
    {
        StartCoroutine(TakeScreenShot());
    }

    private IEnumerator TakeScreenShot()
    {
        yield return new WaitForEndOfFrame();

        Texture2D screenShot = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        screenShot.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        screenShot.Apply();

        string filePath = Path.Combine(Application.temporaryCachePath, "Shared Image.png");
        File.WriteAllBytes(filePath, screenShot.EncodeToPNG());

        Destroy(screenShot);

        new NativeShare().AddFile(filePath).SetSubject("Interação AR").SetText("Olha minha foto bacana").Share();
    }
}
