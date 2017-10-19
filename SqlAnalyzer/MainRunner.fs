namespace CoreWorkings

open CoreWorkings.TypeSystem
open FSharp.Data
open System.IO

module MainRunner =

    let run (analyzers: seq<unit -> Result>) = //placeholder type... why types not working???
        let w = new StreamWriter("output/output.txt", false)

        analyzers
        |> Seq.iter { fun a -> //maybe extract match statement into a writeIntoReport method
            match a.run() with
            | OFFENSE x -> addOffense w x a.friendlyName
            | WARNING x -> addWarning w x a.friendlyName
            | OK x -> addOK w x a.friendlyName
        }

        w.Close()

    let addOffense (writer: StreamWriter) (flag: Offenses) (analyzerName: string) =
        let linebreak = "!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!"
        let opening = sprintf "ANALYZER %s RESULT:\n" analyzerName

        writer.WriteLine linebreak
        writer.WriteLine opening

        parseInstances w flag //iterate through flag instances and make up a prettyprint

        0