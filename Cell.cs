using Godot;
using System;

public class Cell : Control
{
	public Vector2 Index;

	public State State { get; private set; } = State.NULL;

	private Gameplay gameplay;

	public override void _Ready()
	{
		gameplay = GetNode<Gameplay>("/root/Gameplay");
	}

	public void OnClick()
	{
		if(State != State.NULL) return;
		
		State = gameplay.IsCurrentCross ? State.CROSS : State.CIRCLE;
		gameplay.Click(Index);
		GetNode<Sprite>("Sprite").Texture = gameplay.GetTexture();
	}
}

public enum State
{
	CROSS,
	CIRCLE,
	NULL
}
