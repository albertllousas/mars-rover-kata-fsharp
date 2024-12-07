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
]