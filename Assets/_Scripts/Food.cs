using UnityEngine;
using Unity.Netcode;

public class Food : NetworkBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != "Player") return;

        if (!NetworkManager.Singleton.IsServer) return;

        if(other.TryGetComponent<PlayerLength>(out PlayerLength playerLength))
        {
            playerLength.AddLength();
        }

        else if(other.TryGetComponent<Tail>(out Tail tail)){
            tail.networkOwner.GetComponent<PlayerLength>().AddLength();
        }

        NetworkObject.Despawn();
    }
}
