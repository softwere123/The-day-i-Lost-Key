using UnityEngine;
using UnityEngine.UI;

public class HoverHelper : MonoBehaviour
{
    public GameObject targetObject; // Reference to the target object
    public ImageHover imageHover; // Reference to the ImageHover script

    void Start()
    {
        // Get the ImageHover script component from the same GameObject or another GameObject
        imageHover = GetComponent<ImageHover>();

        // Set the target object for the hover image
        if (imageHover != null && targetObject != null)
        {
            imageHover.SetTargetObject(targetObject);
        }
    }
}