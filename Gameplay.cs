using System;
using System.Collections.Generic;
using Godot;
using System.Linq;

public class Gameplay: Node2D
{
	public int sizeX => 3;
	public int sizeY => 3;
	private int winLineCount = 3;

	public event Action WinEvent;

	public bool IsCurrentCross { get; private set; } = false;
	public bool Won { get; private set; } = false;

	private Texture cross = ResourceLoader.Load<Texture>("res://sprites/signs/cross.png");
	private Texture circle = ResourceLoader.Load<Texture>("res://sprites/signs/circle.png");

	private PackedScene controlCell;

	private Cell[,] cells;

	private Vector2[] _matchDirections = {
		new Vector2(1, 0),
		new Vector2(0, 1),
		new Vector2(1, 1),
		new Vector2(-1, 1)
	};

	public void SpawnCells(Node root)
	{
		controlCell = ResourceLoader.Load<PackedScene>("res://Control_Cell.tscn");
		
		cells = new Cell[sizeX, sizeY];
		
		for (int i = 0; i < sizeY; i++)
		{
			for (int j = 0; j < sizeX; j++)
			{
				var control = controlCell.Instance();
				var cell = control.GetNode<Cell>("Cell");
				cell.Index = new Vector2(j, i);
				cells[j, i] = cell;
				root.AddChild(control);
			}
		}
	}

	public Texture GetTexture()
	{
		return IsCurrentCross ? cross : circle;
	}

	public void Click(Vector2 index)
	{
		if(Won) return;
		
		IsCurrentCross = !IsCurrentCross;
		CheckWin(index);
	}

	private void CheckWin(Vector2 index)
	{
		State state = cells[(int) index.x, (int) index.y].State;
		int currentMatchCount = 1;
		bool reversed = false;
		for (int i = 0; i < _matchDirections.Length; i++)
		{
			currentMatchCount = 1;
			reversed = false;
			bool stop = false;
			if(stop) break;
			Vector2 currentCheckIndex = index;
			Vector2 dir = _matchDirections[i];
			while (!stop)
			{
				currentCheckIndex += dir;
				//reverse check if index is out of bounds
				bool outOfBounds = currentCheckIndex.x < 0
								   || currentCheckIndex.x >= sizeX
								   || currentCheckIndex.y < 0
								   || currentCheckIndex.y >= sizeY;
				if (outOfBounds)
				{
					if (!reversed)
					{
						dir *= -1;
						currentCheckIndex = index;
						reversed = true;
						continue;
					}
					else
					{
						break;
					}
				}

				if (cells[(int) currentCheckIndex.x, (int) currentCheckIndex.y].State == state)
				{
					currentMatchCount += 1;

					if (currentMatchCount >= winLineCount)
					{
						Won = true;
						WinEvent?.Invoke();
						stop = true;
						break;
					}
				}
				else
				{
					if (!reversed)
					{
						currentCheckIndex = index;
						dir *= -1;
						reversed = true;
						continue;
					}
					else
					{
						break;
					}
				}
			}
		}
	}
}
