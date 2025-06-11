using Godot;
using System;

public partial class playerController : Node2D
{
	private float moveSpeed = 100;
	public override void _PhysicsProcess(double delta) {
		Vector2 inputMovement = new Vector2(0, 0);
		if(Input.IsActionPressed("move_left")){
			inputMovement.X -= moveSpeed;
		}
		if(Input.IsActionPressed("move_right")){
			inputMovement.X += moveSpeed;
		}
		GlobalPosition += inputMovement*(float)delta;
	}
}
