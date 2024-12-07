module MarsRover

type Direction = N | S | E | W

type Rover = { Dir: Direction; Pos : int * int }

type Command = MoveForward | MoveBackward

module Rover = 
  
  let executeCommand cmd ({ Dir = _; Pos = (x, y)  } as rover) =
    match cmd with
      | MoveForward -> { rover with Pos = (x, y + 1)  }
      | MoveBackward -> { rover with Pos = (x, y - 1)  }