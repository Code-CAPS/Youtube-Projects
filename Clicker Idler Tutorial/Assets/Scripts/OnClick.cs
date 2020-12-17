using UnityEngine;

public class OnClick : MonoBehaviour
{
    // declare a callback delegate
    public delegate void OnClickDelegate(OnClick onClickScript);

    // declare a member variable of the type of the callback delegate
    public OnClickDelegate theDelegate = null;

    void OnMouseUp()
    {
        Debug.Log("Mouse Click on " + this.name);

        if (theDelegate != null)
        {
            theDelegate(this);
        }
    }
}
