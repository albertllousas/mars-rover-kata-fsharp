module MarsRoverTests

open Expecto
open MarsRover

let assertThat actual expected = Expect.equal actual expected ""

let planet = { Size = (2, 2); Obstacles = [] }

[<Tests>]
let tests = testList "Mars rover tests" [
  
  testList "Move rover forward and backward scenarios" [
    let testCases = 
      [ (N, (0, 0), MoveForward, (0, 1))
        (W, (1, 1), MoveForward, (0, 1))
        (S, (1, 1), MoveForward, (1, 0))
        (E, (1, 1), MoveForward, (2, 1))
        (N, (1, 1), MoveBackward, (1, 0))
        (W, (1, 1), MoveBackward, (2, 1))
        (S, (1, 1), MoveBackward, (1, 2))
        (E, (1, 1), MoveBackward, (0, 1))
        ]
    for dir, pos, cmd, expectedPos in testCases do
      test $"Should go from {pos} to {expectedPos} when executing {cmd} and direction is {dir}" {
         let rover = { Dir = dir; Pos = pos; Planet = planet; obstacle = None }
    
         let result  = Rover.executeCommand cmd rover 
    
         assertThat result { rover with Pos = expectedPos }
      }
  ]
  
  testList "Turn rover left and right scenarios" [
    let testCases = 
      [ (N, TurnLeft, W)
        (W, TurnLeft, S)
        (S, TurnLeft, E)
        (E, TurnLeft, N)
        (N, TurnRight, E)
        (W, TurnRight, N)
        (S, TurnRight, W)
        (E, TurnRight, S)
        ]
    for dir, cmd, expectedDir in testCases do
      test $"Should turn from {dir} to {expectedDir} when executing {cmd}" {
         let rover = { Dir = dir; Pos = (0, 0); Planet = planet; obstacle = None }
    
         let result  = Rover.executeCommand cmd rover 
    
         assertThat result { rover with Dir = expectedDir }
      }
  ]
  
  testList "Wrap around the planet scenarios" [
    let testCases = 
      [ (N, (0, 2), (0, 0))
        (S, (0, 0), (0, 2))
        (W, (0, 0), (2, 0))
        (E, (2, 0), (0, 0))
        ]
    for dir, pos, expectedPos in testCases do
      test $"Should wrap around when {dir} edge of the planet is reached moving from {pos} to {expectedPos}" {
         let rover = { Dir = dir; Pos = pos; Planet = planet; obstacle = None }
    
         let result  = Rover.executeCommand MoveForward rover 
    
         assertThat result { rover with Pos = expectedPos }
      }
  ]
  
  test "Should not move and report if there is an obstacle when trying to process a command" {
    let planetWithObstacles = { Size = (2, 2); Obstacles = [(0, 1)] }
    let rover = { Dir = N; Pos = (0, 0); Planet = planetWithObstacles; obstacle = None }
    
    let result  = Rover.executeCommand MoveForward rover 
    
    assertThat result { rover with obstacle = Some (0, 1) }
  }
]
