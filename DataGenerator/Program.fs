// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.

open System
open System.IO

let rnd = new Random()

[<EntryPoint>]
let main argv = 
    
    let seq = seq { for i in 1..10000 do
                        let i0 = rnd.NextDouble()
                        let i1 = rnd.NextDouble()
                        yield (i0, i1, i0 < i1) }

    let bla = seq
              |> Seq.map (fun (i0, i1, first) -> string i0 + "," + string i1 + "," + (string) (if first then 1 else -1))
              |> Seq.fold (fun res l -> res + Environment.NewLine + l) ""

    use sw = new StreamWriter("output.csv")
    sw.WriteLine(bla)

    printfn "%A" argv
    0 // return an integer exit code
