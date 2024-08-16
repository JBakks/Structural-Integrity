using UnityEngine;
using UnityEditor;
using Oculus.Interaction.Surfaces;
using Oculus.Interaction;

[CustomEditor(typeof(AutoAssignScripts))]
public class AutoAssignScriptsEditor : Editor
{
    /*private void OnEnable()
    {
        AddComponentsIfNeeded((AutoAssignScripts)target);
    }*/

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        AutoAssignScripts script = (AutoAssignScripts)target;

        if (GUILayout.Button("Add Related Components"))
        {
            AddComponentsIfNeeded(script);
        }

        if (GUILayout.Button("Remove Related Components"))
        {
            RemoveComponentsIfNeeded(script);
        }
    }

    private void AddComponentsIfNeeded(AutoAssignScripts script)
    {
        script.gameObject.tag = "ground";

        if (script.gameObject.GetComponent<ColliderSurface>() == null)
        {
            Undo.AddComponent<ColliderSurface>(script.gameObject);
        }

        if (script.gameObject.GetComponent<RayInteractable>() == null)
        {
            Undo.AddComponent<RayInteractable>(script.gameObject);
        }

        if (script.gameObject.GetComponent<PointableUnityEventWrapper>() == null)
        {
            Undo.AddComponent<PointableUnityEventWrapper>(script.gameObject);
        }

        if (script.gameObject.GetComponent<AutoSetter>() == null)
        {
            Undo.AddComponent<AutoSetter>(script.gameObject);
        }
    }

    private void RemoveComponentsIfNeeded(AutoAssignScripts script)
    {
        script.gameObject.tag = "Untagged";

        var colliderSurface = script.gameObject.GetComponent<ColliderSurface>();
        if (colliderSurface != null)
        {
            Undo.DestroyObjectImmediate(colliderSurface);
        }

        var rayInteractable = script.gameObject.GetComponent<RayInteractable>();
        if (rayInteractable != null)
        {
            Undo.DestroyObjectImmediate(rayInteractable);
        }

        var eventWrapper = script.gameObject.GetComponent<PointableUnityEventWrapper>();
        if (eventWrapper != null)
        {
            Undo.DestroyObjectImmediate(eventWrapper);
        }

        var autoSetter = script.gameObject.GetComponent<AutoSetter>();
        if (autoSetter != null)
        {
            Undo.DestroyObjectImmediate(autoSetter);
        }
    }
}
