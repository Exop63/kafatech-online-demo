using Mirror;
using UnityEngine;

public class CustomNetworkTransformReliable : NetworkTransformUnreliable
{
    protected override void SetPosition(Vector3 position)
    {
        var serverBounds = GameManager.Instance.ServerBounds;
        var localBounds = Player.local.GetComponent<PlayerMove>().bounds;

        base.SetPosition(NormalizePosition(position, localBounds, serverBounds));
    }

    private Vector3 NormalizePosition(Vector3 position, Vector3 localBounds, Vector3 serverBounds)
    {
        // Local player bounds
        float localMinX = -localBounds.x;
        float localMaxX = localBounds.x;
        float localMinY = -localBounds.y;
        float localMaxY = localBounds.y;

        // Server player bounds
        float serverMinX = -serverBounds.x;
        float serverMaxX = serverBounds.x;
        float serverMinY = -serverBounds.y;
        float serverMaxY = serverBounds.y;

        // Normalizing: transforming position to a value between 0 and 1
        float normalizedX = Mathf.Clamp01((position.x - serverMinX) / (serverMaxX - serverMinX));
        float normalizedY = Mathf.Clamp01((position.y - serverMinY) / (serverMaxY - serverMinY));

        // Rescaling: scaling the normalized value with local bounds
        float localX = Mathf.Lerp(localMinX, localMaxX, normalizedX);
        float localY = Mathf.Lerp(localMinY, localMaxY, normalizedY);

        return new Vector3(localX, localY, position.z);
    }
}
