using System.Collections;
using System.Collections.Generic;
using System.IO;
using ObjSharp;
using UnityEngine;

public class LoadTest : MonoBehaviour
{
    private ObjProvider _provider;

    // Start is called before the first frame update
    async void Start()
    {
        _provider = FindObjectOfType<ObjProvider>();

        //var path = Path.Combine(Application.streamingAssetsPath, "FinalModel.obj");

        var obj = _provider.Load("CentralizedModel.obj",Application.streamingAssetsPath);
    }
}
