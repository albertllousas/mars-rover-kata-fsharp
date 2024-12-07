module MarsRover

type Direction = N | S | E | W

type Rover = { Dir: Direction; Pos : int * int }

type Command = MoveForward | MoveBackward

module Rover = 
  
  let executeCommand cmd ({ Dir = dir; Pos = (x, y)  } as rover) =
    match cmd with
      | MoveForward ->
        match dir with
          | N -> { rover with Pos = (x, y + 1)  }
          | W -> { rover with Pos = (x - 1, y)  }
          | _ -> { rover with Pos = (x, y - 1)  }
      | MoveBackward -> { rover with Pos = (x, y - 1)  }