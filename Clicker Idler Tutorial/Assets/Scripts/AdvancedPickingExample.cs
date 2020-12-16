using System.Collections.Generic;
using UnityEngine;

public class AdvancedPickingExample : MonoBehaviour
{
    public Material materialDeselect = null;
    public Material materialSelect = null;

    public string inputButtonName = "Click";
    public string layerNameMask = "Clickable";

    public List<GameObject> clickTargets = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        UnityEngine.Assertions.Assert.IsNotNull(materialDeselect);
        UnityEngine.Assertions.Assert.IsNotNull(materialSelect);

        // Deselect all targets.
        foreach (var clickTarget in clickTargets)
        {
            var renderer = clickTarget.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.material = materialDeselect;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonUp(inputButtonName))
        {
            // Deselect all targets.
            foreach (var clickTarget in clickTargets)
            {
                var renderer = clickTarget.GetComponent<Renderer>();
                if (renderer != null)
                {
                    renderer.material = materialDeselect;
                }
            }

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            LayerMask layerMask = LayerMask.GetMask(new string[] { layerNameMask });

            RaycastHit raycastHit = new RaycastHit();
            bool result = Physics.Raycast(ray, out raycastHit, float.MaxValue, layerMask.value);
            if (result)
            {
                var renderer = raycastHit.transform.gameObject.GetComponent<Renderer>();
                if (renderer != null)
                {
                    renderer.material = materialSelect;
                }
            }
        }
    }
}
