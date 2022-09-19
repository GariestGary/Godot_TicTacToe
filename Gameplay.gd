extends Node2D

var current_cross = false

var cross = load("res://sprites/signs/cross.png")
var circle = load("res://sprites/signs/circle.png")

func click():
	current_cross = !current_cross

func get_texture() -> Texture:
	if(current_cross):
		return cross
	else:
		return circle
