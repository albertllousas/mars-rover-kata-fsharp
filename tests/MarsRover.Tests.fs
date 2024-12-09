module MarsRoverTests

open Expecto
open MarsRover

let assertThat actual expected = Expect.equal actual expected ""

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
         let rover = { Dir = dir; Pos = pos }
    
         let result  = Rover.executeCommand cmd rover 
    
         assertThat result { rover with Pos = expectedPos }
      }
  ]
  
  testList "Turn rover left and right scenarios" [
    let testCases = 
      [ (N, TurnLeft, W)
        ]
    for dir, cmd, expectedDir in testCases do
      test $"Should turn from {dir} to {expectedDir} when executing {cmd}" {
         let rover = { Dir = dir; Pos = (0, 0) }
    
         let result  = Rover.executeCommand cmd rover 
    
         assertThat result { rover with Dir = expectedDir }
      }
  ]
]
