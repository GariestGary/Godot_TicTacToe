using Godot;

public class Main: Node2D
{
	private Gameplay gameplay;
	
	public override void _Ready()
	{
		var grid = GetNode<GridContainer>("Canvas/Control/GridContainer");
		gameplay = GetNode<Gameplay>("/root/Gameplay");
		grid.Columns = gameplay.sizeY;
		gameplay.SpawnCells(grid);
		gameplay.WinEvent += ShowWin;
	}

	private void ShowWin()
	{
		GetNode<Label>("Canvas/Control/Win").Visible = true;
	}

	public override void _ExitTree()
	{
		gameplay.WinEvent -= ShowWin;
	}
}
