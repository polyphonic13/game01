using UnityEngine;
using System.Collections;

public class EventCenter : MonoBehaviour {

	public delegate void RoomHandler (string room);
    public delegate void NoteHandler(string msg);
	public delegate void PlayerEnabler(bool enable);
	public delegate void EquipItemHandler(string itemName);

	public event RoomHandler onRoomEntered;
	public event RoomHandler onRoomExited;

    public event NoteHandler onAddNote; 

	public event PlayerEnabler onEnablePlayer; 

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
		if (onRoomEntered != null) {
			onRoomEntered (room);
		}
	}

	public void exitRoom(string room) {
		if (onRoomExited != null) {
			onRoomExited (room);
		}
	}

	public void addNote(string msg) {
		if(onAddNote != null) {
			onAddNote(msg);
		}
	}

	public void enablePlayer (bool enable) {
		if (onEnablePlayer != null) {
			onEnablePlayer (enable);
		}
	}

	public void equipItem(string itemName) {
		if(onEquipItem != null){
			onEquipItem(itemName);
		}
	}
}
