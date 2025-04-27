using UnityEngine;
using UnityEngine.UI;

public class ImageHover : MonoBehaviour
{
    public Image hoverImage;                // Reference to the image that hovers over the object
    public Collider targetCollider;         // Reference to the collider of the target object
    public Collider playerCollider;         // Reference to the collider of the player character

    private Transform targetTransform;      // Reference to the transform of the target object

    private void Update()
    {
        // Check if the player character is inside the target object's collider
        if (IsPlayerInsideTargetCollider())
        {
            // Get the screen position of the target object
            Vector3 targetScreenPos = Camera.main.WorldToScreenPoint(targetTransform.position);

            // Update the position of the hover image to the target screen position
            hoverImage.transform.position = targetScreenPos;
            hoverImage.enabled = true; // Enable the hover image
        }
        else
        {
            hoverImage.enabled = false; // Disable the hover image
        }
    }

    // Set the target object for the hover image
    public void SetTargetObject(GameObject targetObject)
    {
        // Get the collider and transform of the target object
        targetCollider = targetObject.GetComponent<Collider>();
        targetTransform = targetObject.transform;
    }

    // Check if the player character is inside the target object's collider
    private bool IsPlayerInsideTargetCollider()
    {
        if (targetCollider == null || playerCollider == null)
        {
            return false;
        }

        // Check if the player character is inside the target object's collider
        return targetCollider.bounds.Contains(playerCollider.bounds.center);
    }
}