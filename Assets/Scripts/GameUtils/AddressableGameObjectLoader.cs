using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine;

public class AddressableGameObjectLoader : MonoBehaviour
{
    public static AssetReference objectToLoad;
    public AssetReference accessoryObjectToLoad;
    private GameObject instantiatedObject;
    private GameObject instantiatedAccessoryObject;

    public void Start()
    {
        Addressables.LoadAssetAsync<GameObject>(objectToLoad).Completed += ObjectLoadDone;
    }

    private void ObjectLoadDone(AsyncOperationHandle<GameObject> obj)
    {
        if (obj.Status == AsyncOperationStatus.Succeeded)
        {
            GameObject loadedObject = obj.Result;
            Debug.Log("Successfully loaded object.");
            instantiatedObject = Instantiate(loadedObject);
            Debug.Log("Successfully instantiated object.");
            if (accessoryObjectToLoad != null)
            {
                accessoryObjectToLoad.InstantiateAsync(instantiatedObject.transform).Completed += op =>
                {
                    if (op.Status == AsyncOperationStatus.Succeeded)
                    {
                        instantiatedAccessoryObject = op.Result;
                        Debug.Log("Successfully loaded and instantiated accessory object.");
                    }
                };
            }
        }
    }
}
