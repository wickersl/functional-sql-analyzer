namespace CoreWorkings

module TypeSystem =

    type TableInfo = {
        schema: string
        tableName: string
        tableSize: int
        pkName: string
    }

    type FlaggedRows = string seq

    type TableFlag = {
        flaggedTable: TableInfo
        flaggedRows: FlaggedRows
    }

    type OffenseString = string
    type WarningString = string
    type OKString = string

    type Offenses = {
        msg: OffenseString
        instances: TableFlag seq
    }

    type Warnings = {
        msg: WarningString
        instances: TableFlag seq
    }

    type AllFine = {
        msg: OKString
    }

    type Result =
    | OFFENSE of Offenses
    | WARNING of Warnings
    | OK of AllFine

    //------------------------------------

    type ConnectionString = string

    type Analyzer = {
        run: ConnectionString -> Result
        friendlyName: string
    }


    //consider making record type
    type RunnableAnalyzers = {
        analyzers: seq<Analyzer>
    }