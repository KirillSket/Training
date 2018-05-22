using UnityEngine;
using System.Collections;

public class AlphaAnimHelper : MonoBehaviour
{

	private tk2dBaseSprite _sprite;
	private Color _color;

	// Use this for initialization
	void Start()
	{
		_sprite = GetComponent<tk2dBaseSprite>();
		_color = _sprite.color;
	}
	
	// Update is called once per frame
	void Update()
	{
		if (_sprite != null && _sprite.color != _color)
		{
			_color = _sprite.color;
			_sprite.Build();
		}
	}
}

