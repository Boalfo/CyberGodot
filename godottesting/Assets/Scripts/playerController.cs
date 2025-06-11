using Godot;
using System;

enum moveState {
		Stationary = 0,
		Grounded = 200,
		Air = 250,
		Sliding = 300,
		Dashing = 500
	}
public partial class playerController : CharacterBody2D
{
	private moveState playerState;
	private float accelSpeed = 100;
	private float gravity = 100;
	private float jumpStrength = 100;
	public override void _PhysicsProcess(double delta) {
		Vector2 acceleration = new Vector2(0, 0);
		Vector2 velocity = GetVelocity();
		bool grounded = IsOnFloor();
		//read horizontal movement input
		if(Input.IsActionPressed("move_left")){
			acceleration.X -= accelSpeed;
		}
		if(Input.IsActionPressed("move_right")){
			acceleration.X += accelSpeed;
		}
		//read for jumping
		if(Input.IsActionPressed("move_jump") && grounded){
			acceleration.Y -= jumpStrength/(float)delta;
		}
		//add Gravity
		if(!grounded){
			acceleration.Y += gravity;
		}
		
		//Update player's movement state
		if(acceleration.X == 0){
			playerState = moveState.Stationary;
		} else if(grounded){
			playerState = moveState.Grounded;
		} else {
			playerState = moveState.Air;
		}
		
		//Clamp player velocity
		velocity += acceleration*(float)delta;
		if (MathF.Abs(velocity.X) > (int)playerState){
			velocity.X = MathF.Sign(velocity.X)*(int)playerState;
		}
		
		//finalize physics & run update
		SetVelocity(velocity);
		MoveAndSlide();
	}
}
