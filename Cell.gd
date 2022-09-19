extends Control

signal changed

func on_click():
	Gameplay.click()
	get_node("Sprite").texture = Gameplay.get_texture()
