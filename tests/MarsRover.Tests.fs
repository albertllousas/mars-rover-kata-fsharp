module MarsRover

open Expecto

let assertThat actual expected = Expect.equal actual expected ""

[<Tests>]
let tests = testList "Mars rover tests" [

  test "Should work" {
    assertThat 1 1
  }
]