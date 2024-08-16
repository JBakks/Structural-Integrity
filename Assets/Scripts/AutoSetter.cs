using UnityEngine;
using Oculus.Interaction.Surfaces; // Make sure to include the namespace for Oculus components.
using Oculus.Interaction;

public class AutoSetter : MonoBehaviour
{
    // Call auto-setup methods in Awake to ensure everything is set up before the game starts.
    private void Awake()
    {
        EnsureColliderSurface();
        EnsureRayInteractable();
        EnsurePointableUnityEventWrapper();
    }

    private void EnsureColliderSurface()
    {
        ColliderSurface colliderSurface = GetComponent<ColliderSurface>();
        Collider collider = GetComponent<Collider>();

        // If there is a collider but it's not a MeshCollider, remove it
        if (collider != null && !(collider is MeshCollider))
        {
            DestroyImmediate(collider);
            collider = null;
        }

        // If there is no collider, add a MeshCollider
        if (collider == null)
        {
            collider = gameObject.AddComponent<MeshCollider>();
        }

        // Inject the MeshCollider into the ColliderSurface
        colliderSurface.InjectCollider(collider);
    }

    private void EnsureRayInteractable()
    {
        RayInteractable rayInteractable = GetComponent<RayInteractable>();
        if (rayInteractable == null)
        {
            rayInteractable = gameObject.AddComponent<RayInteractable>();
        }

        // Automatically grab the ISurface component if not assigned
        if (rayInteractable.Surface == null)
        {
            ISurface surface = GetComponent<ISurface>();
            rayInteractable.InjectAllRayInteractable(surface);
        }
    }

    private void EnsurePointableUnityEventWrapper()
    {
        PointableUnityEventWrapper eventWrapper = GetComponent<PointableUnityEventWrapper>();
        if (eventWrapper == null)
        {
            eventWrapper = gameObject.AddComponent<PointableUnityEventWrapper>();
        }

        // Automatically grab the IPointable component

        IPointable pointable = GetComponent<IPointable>();

        eventWrapper.InjectAllPointableUnityEventWrapper(pointable);
    }

    // Start and Update methods can be removed if not used.
}
