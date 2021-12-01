// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System

[<EntryPoint>]
let main argv =
    let numbers = (System.IO.File.ReadLines("input.txt") |> Seq.map int |> Seq.toList)
    let getIncreases sweeps = 
        let rec inner counter = function
        
        |hd::adj::tl ->
            if hd < adj then 
                inner (counter + 1)  (adj::tl) 
            else 
                inner counter (adj::tl)   
        | [_] | [] -> counter
        inner 0 sweeps


    let getIncreasesSlidingWindow sweeps = 
        let rec loop counter = function 
        |a::b::c::d::tl -> 
            if (b+ c+d) > (a + b + c)
            then 
               loop (counter + 1) (b::c::d::tl)
            else 
                loop counter (b::c::d::tl)
        | [] | [_]| _ ::_| _::_::_ -> counter 
        loop 0 sweeps
    
    let incCount = getIncreases numbers
    let incCountSliding = getIncreasesSlidingWindow numbers
    printfn "The increase count was : %d" incCount
    printfn "The sliding increase count was %d" incCountSliding
    0 // return an integer exit code