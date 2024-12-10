module MarsRover

type Direction = N | S | E | W

type Planet = { Size : int * int }

type Rover = { Dir: Direction; Pos : int * int; Planet: Planet }

type Command = MoveForward | MoveBackward | TurnLeft | TurnRight

module Commands =
  
  let moveForward ({ Dir = dir; Pos = (x, y) } as rover) =
    let newPos = match dir with | N -> (x, y + 1) | W -> (x - 1, y) | S -> (x, y - 1) | E -> (x + 1, y)
    { rover with Pos = newPos}
  
  let moveBackward ({ Dir = dir; Pos = (x, y) } as rover) =
    let newPos = match dir with | N -> (x, y - 1) | W -> (x + 1, y) | S -> (x, y + 1) | E -> (x - 1, y)
    { rover with Pos = newPos}
  
  let turnLeft ({ Dir = dir; Pos =  _ } as rover) =
    let newDir = match dir with | N -> W | W -> S | S -> E | E -> N
    { rover with Dir = newDir}
  
  let turnRight ({ Dir = dir; Pos =  _ } as rover) =
    let newDir = match dir with | N -> E | W -> N | S -> W | E -> S
    { rover with Dir = newDir}  
    
module Rover = 
  
  let private wrapAround ({ Pos = (x, y); Planet = { Size = (lenght, width) }} as rover) =
    { rover with Pos = (x, ((y % (width + 1)) + (width + 1)) % (width + 1))}
   
  let executeCommand cmd rover =
    let newRover =
      match cmd with
        | MoveForward -> Commands.moveForward rover
        | MoveBackward -> Commands.moveBackward rover
        | TurnLeft -> Commands.turnLeft rover
        | TurnRight -> Commands.turnRight rover
    wrapAround newRover
      