using UnityEngine;
using System.Collections;

public class Guide : InteractiveElement {

	public Material lenseOn;
	public Material lenseOff;
	public Material innardsOn;
	public Material innardsOff;

	public ItemWeight weight; 

	public float animationSpeed = 1.0f;

	public bool isIntact { get; set; }
	public bool isActive { get; set; }

	private const string DEFAULT_CLIP = "guide01_default";
	private const string ARMS_OPEN_CLIP = "guide01_arms_open";
	private const string ARMS_CLOSE_CLIP = "guide01_arms_close";

	private Vector3 _startY;
	private Vector3 _endY;
	private float _startTime = 0;
	private float _levitationAmount = 0;
	private bool _isLevitated = false;

	private Transform _lens;
	private Transform _innards;

	private Animation _animation;
	private Camera _mainCamera; 
	private Player _player; 

	public void initGuide() {
		_player = GameObject.Find("player").GetComponent<Player>();
		_mainCamera = Camera.main;
		isActive = false;
		_lens = this.transform.Search("lens");
		_innards = this.transform.Search("innards");
		_animation = GetComponent<Animation>();
		_playClip(DEFAULT_CLIP);
		_applyOffMaterials();
//		Debug.Log("Guide/initGuide, lens = " + _lens + ", _innards = " + _innards);
		init();
	}
	 
	public void OnMouseDown() {
		toggleActivated();
	}

	public void toggleActivated() {
		if(isActive) {
			deactivate();
		} else {
			activate();
		}
		isActive = !isActive;
	}

	public void activate() {
		Debug.Log("Guide/activate");
		_applyOnMaterials();
		_playClip(ARMS_OPEN_CLIP);
		_levitationOn();
}

	public void deactivate() {
		Debug.Log("Guide/deactivate");
		_applyOffMaterials();
		_playClip(ARMS_CLOSE_CLIP);
		_levitationOff();
	}

	private void _applyOffMaterials() {
		_lens.renderer.material = lenseOff;
		_innards.renderer.material = innardsOff;
	}

	private void _applyOnMaterials() {
		_lens.renderer.material = lenseOn;
		_innards.renderer.material = innardsOn;
	}

	private void _playClip(string clip) {
		_animation[clip].wrapMode = WrapMode.Once;
		_animation.Play(clip);
	}
	
	private void _levitationOff() {
		float right = this.transform.position.x;
		float up = this.transform.position.y - 1f;
		float forward = this.transform.position.z;
//		ItemWeight _weightClone = (ItemWeight) Instantiate(weight, this.transform.position, this.transform.rotation);
		ItemWeight _weightClone = (ItemWeight) Instantiate(weight, new Vector3(right, up, forward), this.transform.rotation);
		_weightClone.parentObject = this.gameObject;
		_weightClone.transform.parent = this.transform;
	}

	private void _levitationOn() {
		_isLevitated = false;
		_startY = this.transform.position;
		_endY = new Vector3(this.transform.position.x, (_mainCamera.transform.position.y - 0.1f), this.transform.position.z);
		_startTime = Time.time;
		_levitationAmount = Vector3.Distance(_startY, _endY);
	}

	private void _updateLevitation() {
		float distCovered = (Time.time - _startTime) * animationSpeed;
		float fracJourney = distCovered / _levitationAmount;
		this.transform.position = Vector3.Lerp(_startY, _endY, fracJourney);
		if(this.transform.position.y >= _endY.y) {
			this._isLevitated = true;
		}
	}
	
	private void _updateDirection() {
		var targetPos = _player.transform.position - transform.position;
		targetPos.y = 0;
		Quaternion newRotation = Quaternion.LookRotation(targetPos);
		transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * animationSpeed);
	}

	private void _updatePosition() {

	}

	void Awake() {
		initGuide();
	}

	void Update() {
		if(this.isActive) {
			_updateDirection();
			if(!this._isLevitated) {
				_updateLevitation();
			} else {
				_updatePosition();
			} 
		}
	}
}
