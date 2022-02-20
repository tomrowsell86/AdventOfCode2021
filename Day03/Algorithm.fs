
namespace Aoc.Day03
open System
module Algorithm =
    let getColumnCounts (codes:seq<string>) = 
        let folder (value:string) (state:int * int[]) = 
            let parseBits (s:string) = Array.map (fun v -> int (Char.GetNumericValue(v))) (s.ToCharArray()) 
            let countOne (x:int*int) = if snd x = 1 then fst x + 1 else fst x    
            let splitBits = parseBits value
            let fn innerState =  ((fst innerState) + 1 ,Array.zip (snd innerState) splitBits |> Array.map countOne) 
            if Array.isEmpty (snd state) 
            then
                fn (0,Array.replicate (splitBits.Length) 0) 
            else 
                fn state
        Seq.foldBack folder codes (0,Array.empty)
    let msbs count bits =
        let mapper total b = if total - b < total/2 then 1 else 0 
        Array.map (mapper count) bits

    let binToDec (bits:uint[]) = 
        Seq.zip (Seq.rev(seq{0..bits.Length-1})) bits 
        |> Seq.where (fun (_,b) -> b <> 0u)
        |> Seq.map fst
        |> Seq.map (fun a-> Math.Pow(2,a)) 
        |> Seq.sum

     


module Data =
    let TextLines = System.IO.File.ReadLines("input.txt");
