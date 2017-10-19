namespace CoreWorkings
open TypeSystem
open FSharp.Data

module MainRunner =

    let run (analyzers: RunnableAnalyzers) = //uh what?
        let connStr = analyzers.databaseConnectionString