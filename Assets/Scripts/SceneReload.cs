using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneReload : MonoBehaviour
{
    public void ReloadThisScene()
    {
        SceneManager.LoadScene("FNAFB");
    }
}
