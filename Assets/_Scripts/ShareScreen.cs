using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShareScreen : MonoBehaviour
{
    public RawImage screenShot;
    public string filePath;

    public void ShareScreenShot()
    {
        new NativeShare().AddFile(filePath).SetSubject("Interação AR").SetText("Olha minha foto bacana").Share();
    }
}
