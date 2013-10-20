using UnityEngine;
using System.Collections;

public class EventCenter : MonoBehaviour {

	public delegate void RoomHandler(string room);
    public delegate void NoteHandler(string msg = "", bool zoom = false);
	public delegate void PlayerHandler(bool enable);
	public delegate void CameraZoomHandler(bool zoom);
	
	public delegate void EquipItemHandler(string itemName);
	
	public delegate void TriggerEventHandler(string evt);
	public delegate void CollectedEventHandler(string evt);
	
	public event RoomHandler onRoomEntered;
	public event RoomHandler onRoomExited;

    public event NoteHandler onAddNote; 
	public event NoteHandler onRemoveNote; 
	
	public event PlayerHandler onEnablePlayer; 
	
	public event CameraZoomHandler onCameraZoom;
	
	public event EquipItemHandler onEquipItem;
	
	public event TriggerEventHandler onTriggerEvent;
	public event CollectedEventHandler onCollectedEvent; 
	
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
	
	public void removeNote(string msg = "", bool zoom = false) {
		if(onRemoveNote != null) {
			onRemoveNote(msg, zoom);
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
	
	public void triggerEvent(string evt) {
		if(onTriggerEvent != null) {
			onTriggerEvent(evt);	
		}
	}
	
	public void collectedEvent(string evt) {
		if(onCollectedEvent != null) {
			onCollectedEvent(evt);
		}
	}
}
