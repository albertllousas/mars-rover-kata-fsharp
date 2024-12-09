module MarsRover

type Direction = N | S | E | W

type Rover = { Dir: Direction; Pos : int * int }

type Command = MoveForward | MoveBackward | TurnLeft

module Commands =
  
  let moveForward ({ Dir = dir; Pos = (x, y) } as rover) =
    let newPos = match dir with | N -> (x, y + 1) | W -> (x - 1, y) | S -> (x, y - 1) | E -> (x + 1, y)
    { rover with Pos = newPos}
  
  let moveBackward ({ Dir = dir; Pos = (x, y) } as rover) =
    let newPos = match dir with | N -> (x, y - 1) | W -> (x + 1, y) | S -> (x, y + 1) | E -> (x - 1, y)
    { rover with Pos = newPos}
  
  let turnLeft ({ Dir = dir; Pos =  pos } as rover) =
    let newDir = match dir with | N -> W | _ -> failwith "todo"
    { rover with Dir = newDir}
    

module Rover = 
  
  let executeCommand cmd rover =
    match cmd with
      | MoveForward -> Commands.moveForward rover
      | MoveBackward -> Commands.moveBackward rover
      | TurnLeft -> Commands.turnLeft rover