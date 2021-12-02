// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System

let startProcessing  instructions =
    let rec loop x y =
        function
        | ("forward", argument) :: tl -> loop (x + argument) y tl
        | ("up", argument) :: tl -> loop x (y - argument) tl
        | ("down", argument) :: tl -> loop x (y + argument) tl
        | (_, _) :: _
        | [] -> x * y

    loop 0 0 instructions

let startProcessingPartB instructions =
    let rec loop x y aim = 
        function
        | ("forward", arg)::tl -> loop (x + arg) (y + (arg * aim)) aim tl
        | ("up", arg)::tl -> loop x y (aim - arg) tl 
        | ("down", arg)::tl -> loop x y (aim + arg) tl 
        | (_,_) :: _
        | [] -> x * y
    loop 0 0 0 instructions
[<EntryPoint>]
let main argv =
    let input =
        System.IO.File.ReadLines("input.txt")
        |> Seq.map (fun i -> i.Split(' '))
        |> Seq.map (fun parts -> (parts.[0], int parts.[1]))
        |> Seq.toList

    let result = startProcessing input
    let resultB = startProcessingPartB input
    printfn "The result is %d" result
    printfn "the result for part b is %d" resultB
    0

