'Excel macro to import data from a CSV file, then create an index and get the data to create a sheet for every CSV'
Sub ImportCSVFiles()
    Dim folderPath As String
    Dim fileName As String
    Dim ws As Worksheet
    Dim indexSheet As Worksheet
    Dim lastRow As Long

    'Set the folder path where the CSV files are located
    folderPath = "C:\CSVFiles\"

    'Check if the index sheet already exists, if not, create it
    On Error Resume Next
    Set indexSheet = ThisWorkbook.Sheets("Index")
    On Error GoTo 0
    If indexSheet Is Nothing Then
        Set indexSheet = ThisWorkbook.Sheets.Add
        indexSheet.Name = "Index"
    End If

    'Loop through all the files in the folder
    fileName = Dir(folderPath & "*.csv")
    Do While fileName <> ""
        'Import the data from the CSV file into a new sheet
        With ActiveSheet.QueryTables.Add(Connection:="TEXT;" & folderPath & fileName, Destination:=Range("A1"))
            .Name = Replace(fileName, ".csv", "")
            .FieldNames = True
            .RowNumbers = False
            .FillAdjacentFormulas = False
            .PreserveFormatting = True
            .RefreshOnFileOpen = False
            .RefreshStyle = xlInsertDeleteCells
            .SavePassword = False
            .SaveData = True
            .AdjustColumnWidth = True
            .RefreshPeriod = 0
            .TextFilePromptOnRefresh = False
            .TextFilePlatform = 437
            .TextFileStartRow = 1
            .TextFileParseType = xlDelimited
            .TextFileTextQualifier = xlTextQualifierDoubleQuote
            .TextFileConsecutiveDelimiter = False
            .TextFileTabDelimiter = True
            .TextFileSemicolonDelimiter = False
            .TextFileCommaDelimiter = True
            .TextFileSpaceDelimiter = False
            .TextFileColumnDataTypes = Array(1, 1, 1, 1, 1, 1)
            .TextFileTrailingMinusNumbers = True
            .Refresh BackgroundQuery:=False
        End With

        'Rename the new sheet to the name of the CSV file
        Set ws = ActiveSheet
        ws.Name = Replace(fileName, ".csv", "")

        'Add the date and time the file was imported to the index sheet
        lastRow = indexSheet.Cells(indexSheet.Rows.Count, "A").End(xlUp).Row + 1
        indexSheet.Cells(lastRow, "A").Value = fileName
        indexSheet.Cells(lastRow, "B").Value = ws.Name
        indexSheet.Cells(lastRow, "C").Value = Now

        'Move to the next file
        fileName = Dir()
    Loop
End Sub
