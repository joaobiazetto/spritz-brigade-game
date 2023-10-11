using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class PrefabManager : MonoBehaviour
{
    // Singleton pattern to ensure there's only one instance of the manager
    private static PrefabManager _instance;
    public static PrefabManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<PrefabManager>();
                if (_instance == null)
                {
                    GameObject managerObject = new GameObject("PrefabManager");
                    _instance = managerObject.AddComponent<PrefabManager>();
                }
            }
            return _instance;
        }
    }

    // Delegate for handling prefab instantiation completion
    public delegate void PrefabInstantiationCallback(GameObject instantiatedPrefab);

    // Method for asynchronously instantiating a prefab
    public void InstantiatePrefabAsync(AssetReference prefabReference, Vector3 position, Quaternion rotation, PrefabInstantiationCallback callback)
    {
        Debug.Log("InstantiatePrefabAsync called");

        prefabReference.InstantiateAsync(position, rotation).Completed += handle =>
        {
            OnPrefabInstantiated(handle, callback);
        };
    }

    // Method to handle the completion of prefab instantiation
    private void OnPrefabInstantiated(AsyncOperationHandle<GameObject> handle, PrefabInstantiationCallback callback)
    {
        Debug.Log("OnPrefabInstantiated called");

        if (handle.Status == AsyncOperationStatus.Succeeded)
        {
            GameObject instantiatedPrefab = handle.Result;
            callback?.Invoke(instantiatedPrefab);
        }
        else
        {
            Debug.LogError("Failed to instantiate prefab: " + handle.DebugName);
        }
    }
}
