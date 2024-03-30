using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.XR.OpenVR;
using UnityEngine.XR.OpenXR.Features.Interactions;
using Unity.XR.Oculus.Input;
using UnityEngine.XR.Interaction.Toolkit;

public class Rayyy : MonoBehaviour
{
    public bool TryGetHitInfo(out Vector3 position, out Vector3 normal, out int positionInLine, out bool isValidTarget)
    {
        position = default;
        normal = default;
        positionInLine = default;
        isValidTarget = default;

        if (! XRRayInteractor.TryGetCurrentRaycast(
                out var raycastHit,
                out var raycastHitIndex,
                out var raycastResult,
                out var raycastResultIndex,
                out var isUIHitClosest))
        {
            return false;
        }

        if (raycastResult.HasValue && isUIHitClosest)
        {
            position = raycastResult.Value.worldPosition;
            normal = raycastResult.Value.worldNormal;
            positionInLine = raycastResultIndex;

            isValidTarget = raycastResult.Value.gameObject != null;
        }
        else if (raycastHit.HasValue)
        {
            position = raycastHit.Value.point;
            normal = raycastHit.Value.normal;
            positionInLine = raycastHitIndex;

            // Determine if the collider is registered as an interactable and the interactable is being hovered
            isValidTarget = interactionManager.TryGetInteractableForCollider(raycastHit.Value.collider, out var interactable) &&
                            IsHovering(interactable);
        }

        return true;
    }
}
