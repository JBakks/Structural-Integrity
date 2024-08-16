using UnityEngine;
using Oculus.Interaction;

public class IgnoreLayerFilter : MonoBehaviour, IGameObjectFilter
{
    public Debugger debugger;

    public LayerMask ignoreLayer;

    // The expected method signature for the interface
    public bool Filter(GameObject gameObject)
    {
        // Return true if the GameObject's layer is not in the ignoreLayer
        debugger.AddText("Ignoring Layer: " + ignoreLayer + "Game objects Layer: " + gameObject.layer);
        return (ignoreLayer & (1 << gameObject.layer)) == 0;
    }
}