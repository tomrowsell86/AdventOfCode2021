open Aoc.Day03

[<EntryPoint>]
let main argv =
    let result = Algorithm.getColumnCounts Data.TextLines
    Array.iter (fun x -> printfn "%d" x ) (snd result)
    0 