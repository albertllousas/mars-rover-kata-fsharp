module MarsRover

type Direction = N | S | E | W

type Planet = { Size : int * int; Obstacles : (int * int) list }

type Rover = { Dir: Direction; Pos : int * int; Planet: Planet; obstacle : (int * int) option }

type Command = MoveForward | MoveBackward | TurnLeft | TurnRight

module Commands =
  
  let moveForward ({ Dir = dir; Pos = (x, y) } as rover) =
    { rover with Pos = match dir with | N -> (x, y + 1) | W -> (x - 1, y) | S -> (x, y - 1) | E -> (x + 1, y)}
  
  let moveBackward ({ Dir = dir; Pos = (x, y) } as rover) =
    { rover with Pos = match dir with | N -> (x, y - 1) | W -> (x + 1, y) | S -> (x, y + 1) | E -> (x - 1, y)}
  
  let turnLeft ({ Dir = dir; Pos =  _ } as rover) =
    { rover with Dir = match dir with | N -> W | W -> S | S -> E | E -> N}
  
  let turnRight ({ Dir = dir; Pos =  _ } as rover) =
    { rover with Dir = match dir with | N -> E | W -> N | S -> W | E -> S}  
    
module Rover = 
  
  let private wrapAround ({ Pos = (x, y); Planet = { Size = (lenght, width) }} as rover) =
    let fit num max = ((num % (max + 1)) + (max + 1)) % (max + 1) 
    { rover with Pos = (fit x lenght, fit y width)}
    
  let executeCommand cmd rover =
    let newRover =
      match cmd with
        | MoveForward -> Commands.moveForward rover
        | MoveBackward -> Commands.moveBackward rover
        | TurnLeft -> Commands.turnLeft rover
        | TurnRight -> Commands.turnRight rover
      |> wrapAround
    if List.contains newRover.Pos rover.Planet.Obstacles then { rover with obstacle = (Some newRover.Pos) } else newRover
      