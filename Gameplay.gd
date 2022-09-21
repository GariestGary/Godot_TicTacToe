extends Node2D

export var x_size: int = 6
export var y_size: int = 6

var current_cross = false

var cross = load("res://sprites/signs/cross.png")
var circle = load("res://sprites/signs/circle.png")

var control_cell = preload("res://Control_Cell.tscn")

var cells = []

var match_directions = [
	Vector2(1, 0),
	Vector2(-1, 0),
	Vector2(0, 1),
	Vector2(0, -1),
	Vector2(1, 1),
	Vector2(-1, 1),
	Vector2(-1, -1),
	Vector2(1, -1)
]

func spawn_cells(root: Control):
	for x in range(x_size):
		cells.append([])
		for _y in range(y_size):
			var cell = control_cell.instance()
			
			cells[x].append(cell)
			root.add_child(cell)

func click():
	current_cross = !current_cross

func get_texture() -> Texture:
	if(current_cross):
		return cross
	else:
		return circle

func check_win():
	pass
