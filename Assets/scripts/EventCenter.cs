using UnityEngine;
using System.Collections;

public class EventCenter : MonoBehaviour {

	public delegate void RoomHandler(string room);
    public delegate void NoteHandler(string msg, bool zoom = false);
	public delegate void PlayerEnabler(bool enable);
	public delegate void CameraZoomHandler(bool zoom);
	public delegate void EquipItemHandler(string itemName);

	public event RoomHandler onRoomEntered;
	public event RoomHandler onRoomExited;

    public event NoteHandler onAddNote; 

	public event PlayerEnabler onEnablePlayer; 
	public event CameraZoomHandler onCameraZoom;
	
	public event EquipItemHandler onEquipItem;
	
	private static EventCenter _instance;
	private EventCenter() {}
	
	public static EventCenter Instance {
		get {
			if(_instance == null) {
	                _instance = GameObject.FindObjectOfType(typeof(EventCenter)) as EventCenter;      
			}
			return _instance;
		}
	}

	public void enterRoom(string room) {
		if(onRoomEntered != null) {
			onRoomEntered(room);
		}
	}

	public void exitRoom(string room) {
		if(onRoomExited != null) {
			onRoomExited(room);
		}
	}

	public void addNote(string msg, bool zoom = false) {
		if(onAddNote != null) {
			onAddNote(msg, zoom);
		}
	}

	public void enablePlayer(bool enable) {
		if(onEnablePlayer != null) {
			onEnablePlayer(enable);
		}
	}
	
	public void zoomCamera(bool zoom) {
		if(onCameraZoom != null) {
			onCameraZoom(zoom);
		}
	}
	
	public void equipItem(string itemName) {
		if(onEquipItem != null){
			onEquipItem(itemName);
		}
	}
}
