using Godot;

public class Main: Node2D
{
	private Gameplay gameplay;
	
	public override void _Ready()
	{
		var grid = GetNode<GridContainer>("GridContainer");
		gameplay = GetNode<Gameplay>("/root/Gameplay");
		grid.Columns = gameplay.sizeY;
		gameplay.SpawnCells(grid);
	}
}
