module MarsRover

type Direction = N | S | E | W

type Rover = { Dir: Direction; Pos : int * int }

type Command = MoveForward | MoveBackward

module Rover = 
  
  let executeCommand cmd ({ Dir = dir; Pos = (x, y)  } as rover) =
    match cmd with
      | MoveForward ->
        match dir with | N -> (x, y + 1) | W -> (x - 1, y) | S -> (x, y - 1) | E -> (x + 1, y)
        |> fun pos -> { rover with Pos = pos}
      | MoveBackward ->
        match dir with | N -> (x, y - 1) | W -> (x + 1, y) | S -> (x, y + 1) | E -> (x - 1, y)
        |> fun pos -> { rover with Pos = pos}