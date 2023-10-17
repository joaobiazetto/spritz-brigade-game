using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class PrefabManager : MonoBehaviour
{
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

    public delegate void PrefabInstantiationCallback(GameObject instantiatedPrefab);

    public void InstantiatePrefabAsync(AssetReference prefabReference, PrefabInstantiationCallback callback)
    {
        prefabReference.InstantiateAsync(transform.position, Quaternion.identity).Completed += handle =>
        {
            OnPrefabInstantiated(handle, callback);
        };
    }

    public void InstantiatePrefabAsync(AssetReference prefabReference, Vector3 position, Quaternion rotation, PrefabInstantiationCallback callback)
    {
        prefabReference.InstantiateAsync(position, rotation).Completed += handle =>
        {
            OnPrefabInstantiated(handle, callback);
        };
    }

    private void OnPrefabInstantiated(AsyncOperationHandle<GameObject> handle, PrefabInstantiationCallback callback)
    {
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
