using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class roomlisting : MonoBehaviourPunCallbacks
{
    [SerializeField] private RoomList _roomListing;
    [SerializeField] private Transform _content;

    private List<RoomList> _listings = new List<RoomList>();

    public void Update()
    {
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        Debug.Log("porra lek");

        foreach(RoomInfo info in roomList)
        {
            Debug.Log("sala existente");

            if (!info.IsOpen || !info.IsVisible || info.RemovedFromList)
            {
                Debug.Log("sala aberta");

                int index = _listings.FindIndex(x => x.RoomInfo.Name == info.Name);
                if(index != -1)
                {
                    Destroy(_listings[index].gameObject);
                    _listings.RemoveAt(index);
                      
                }
            }else
            {
                int _index = _listings.FindIndex(x => x.RoomInfo.Name == info.Name);
                if(_index == -1)
                {
                    Debug.Log("sala criada");

                    RoomList listing = Instantiate(_roomListing, _content);

                    if (listing)
                    {
                        listing.gameObject.SetActive(true);
                        listing.SetRoomInfo(info);
                        _listings.Add(listing);
                    }
                }else
                {
                    Debug.Log("sala atualizada");
                    _listings[_index].SetRoomInfo(info);
                }
            }
        }
    }
}
