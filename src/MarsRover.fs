module MarsRover

type Direction = N | S | E | W

type Rover = { Dir: Direction; Pos : int * int }

type Command = MoveForward | MoveBackward

module Commands =
  
  let moveForward ({ Dir = dir; Pos = (x, y)  } as rover) =
     match dir with | N -> (x, y + 1) | W -> (x - 1, y) | S -> (x, y - 1) | E -> (x + 1, y)
     |> fun pos -> { rover with Pos = pos}
  
  let moveBackward ({ Dir = dir; Pos = (x, y)  } as rover)=
    match dir with | N -> (x, y - 1) | W -> (x + 1, y) | S -> (x, y + 1) | E -> (x - 1, y)
        |> fun pos -> { rover with Pos = pos}

module Rover = 
  
  let executeCommand cmd rover =
    match cmd with
      | MoveForward -> Commands.moveForward rover
      | MoveBackward -> Commands.moveBackward rover