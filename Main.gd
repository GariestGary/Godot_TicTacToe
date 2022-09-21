extends Node2D

func _ready():
	$GridContainer.columns = Gameplay.y_size
	var x = Gameplay.y_size * 140
	var y = Gameplay.x_size * 140
	$GridContainer.rect_size = Vector2(x, y)
	$GridContainer.rect_position = Vector2(-x / 2, -y / 2)
	Gameplay.spawn_cells($GridContainer)
