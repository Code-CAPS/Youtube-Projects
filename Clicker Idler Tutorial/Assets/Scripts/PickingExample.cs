using System.Collections.Generic;
using UnityEngine;

public class PickingExample : MonoBehaviour
{
    public Material materialDeselect = null;
    public Material materialSelect = null;

    public List<OnClick> clickTargets = new List<OnClick>();

    // Start is called before the first frame update
    void Start()
    {
        UnityEngine.Assertions.Assert.IsNotNull(materialDeselect);
        UnityEngine.Assertions.Assert.IsNotNull(materialSelect);

        // Set the callback for our click targets and
        // deselect all targets.
        foreach (var clickTarget in clickTargets)
        {
            clickTarget.theDelegate = OnClickDelegateImplementation;

            var renderer = clickTarget.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.material = materialDeselect;
            }
        }
    }

    public void OnClickDelegateImplementation(OnClick onClickScript)
    {
        UnityEngine.Assertions.Assert.IsNotNull(onClickScript);

        // deselect everything
        foreach (var clickTarget in clickTargets)
        {
            var rendererClickTarget = clickTarget.GetComponent<Renderer>();
            if (rendererClickTarget != null)
            {
                rendererClickTarget.material = materialDeselect;
            }
        }

        var rendererOnClickScript = onClickScript.GetComponent<Renderer>();
        if (rendererOnClickScript != null)
        {
            rendererOnClickScript.material = materialSelect;
        }
    }
}
