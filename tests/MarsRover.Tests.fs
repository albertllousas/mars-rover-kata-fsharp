module MarsRoverTests

open Expecto
open MarsRover

let assertThat actual expected = Expect.equal actual expected ""

[<Tests>]
let tests = testList "Mars rover tests" [

  test "Should move a rover forward" {
    let rover = { Dir = N; Pos = (0, 0) }
    
    let result  = Rover.executeCommand MoveForward rover 
    
    assertThat result { rover with Pos = (0, 1) }
  }
  
  test "Should move a rover backward" {
    let rover = { Dir = N; Pos = (1, 1) }
    
    let result  = Rover.executeCommand MoveBackward rover 
    
    assertThat result { rover with Pos = (1, 0) }
  }
  
  test "Should move a rover forward when direction is west" {
    let rover = { Dir = W; Pos = (1, 1) }
    
    let result  = Rover.executeCommand MoveForward rover 
    
    assertThat result { rover with Pos = (0, 1) } 
  }
]
