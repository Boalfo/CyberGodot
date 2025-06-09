using Godot;
using System;

public partial class Player : Node2D
{
	
	public override void _PhysicsProcess(double delta) {
		GlobalPosition += new Vector2(40*delta,0);
	}
	
	
}
