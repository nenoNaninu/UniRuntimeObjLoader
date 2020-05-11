using System.Collections;
using System.Collections.Generic;
using System.IO;
using ObjSharp;
using UnityEngine;

public class LoadTest : MonoBehaviour
{
    private ObjProvider _provider;

    public Texture _mainTexture;
    // Start is called before the first frame update
    async void Start()
    {
        _provider = UnityEngine.Object.FindObjectOfType<ObjProvider>();

        //var path = Path.Combine(Application.streamingAssetsPath, "FinalModel.obj");
        var path = Path.Combine(Application.streamingAssetsPath, "CentralizedModel.obj");

        var obj = _provider.Load(path);

        var r = obj.GetComponent<Renderer>();
        r.material.mainTexture = _mainTexture;
    }
}
