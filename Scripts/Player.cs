using Godot;
using System;

public partial class Player : CharacterBody2D
{
  [Export]
  private int SPEED = 50;

  public override void _PhysicsProcess(double delta)
  {
    var direction = new Vector2();

    direction.X = Input.GetActionStrength("ui_right") - Input.GetActionStrength("ui_left");
    direction.Y = Input.GetActionStrength("ui_down") - Input.GetActionStrength("ui_up");

    // If input is digital, normalize it for diagonal movement
    if (Math.Abs(direction.X) == 1 && Math.Abs(direction.Y) == 1)
    {
      direction = direction.Normalized();
    }

    // Apply movement
    Vector2 movement = direction * SPEED * (float)delta;
    
    MoveAndCollide(movement);
  }
}


