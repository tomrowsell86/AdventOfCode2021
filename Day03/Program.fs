open Aoc.Day03

[<EntryPoint>]
let main argv =
    let (total,counts) = Algorithm.getColumnCounts Data.TextLines
    let msbs = (Algorithm.msbs total counts) |> Array.map uint
    let lsbs = Array.map (fun (x:uint) -> if x = 0u then 1u else 0u) msbs 
    let gammaRate = uint (Algorithm.binToDec msbs)
    let epsilonRate = uint (Algorithm.binToDec lsbs)
    printfn "Result is : %d " (gammaRate * epsilonRate) 
    
    0 