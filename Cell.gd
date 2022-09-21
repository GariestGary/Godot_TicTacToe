extends Control

export var index = 0

func on_click():
	Gameplay.click()
	get_node("Sprite").texture = Gameplay.get_texture()
