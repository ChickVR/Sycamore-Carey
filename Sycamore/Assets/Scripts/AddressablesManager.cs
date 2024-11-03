using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.AddressableAssets.ResourceLocators;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.Video;

public class AssetReferenceVideoClip : AssetReferenceT<VideoClip>
{
    public AssetReferenceVideoClip(string guid): base(guid) { }
}
public class AddressablesManager : MonoBehaviour
{
    [SerializeField]
    private AssetReferenceVideoClip videosReference;

    // Start is called before the first frame update
    void Start()
    {
        Addressables.InitializeAsync().Completed += AddressablesManager_Completed;
    }

    void AddressablesManager_Completed(AsyncOperationHandle<IResourceLocator> obj)
    {
        videosReference.LoadAssetAsync<VideoClip>().Completed += (clip) =>
        {

        };
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
