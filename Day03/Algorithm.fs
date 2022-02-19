
namespace Aoc.Day03
open System
module Algorithm =
    let parseBits (s:string) = Array.map (fun v -> int (Char.GetNumericValue(v))) (s.ToCharArray()) 
    let countOne (x:int*int) = if snd x = 1 then fst x + 1 else fst x    
    let folder (value:string) (state:int * int[]) = 
        let splitBits = parseBits value
        let fn innerState =  ((fst innerState) + 1 ,Array.zip (snd innerState) splitBits |> Array.map countOne) 
        if Array.isEmpty (snd state) 
        then
            fn (0,Array.replicate (splitBits.Length) 0) 
        else 
            fn state
    let getColumnCounts (codes:seq<string>) = Seq.foldBack folder codes (0,Array.empty)

module Data =
    let TextLines = System.IO.File.ReadLines("input.txt");
