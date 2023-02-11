'Imports data from a CSV, creates a sheet for every CSV, then add the name of the file to an index with the date and time of the data added, then creates an hyperlink for every file'

Private Function IsInCollection(col As Collection, item As Variant) As Boolean
    On Error Resume Next
    IsInCollection = Not IsError(col.item(item))
    On Error GoTo 0
End Function

Sub ImportCSVFiles()
Dim folderPath As String
Dim fileName As String
Dim ws As Worksheet
Dim indexSheet As Worksheet
Dim lastRow As Long
Dim importedFiles As Collection

' Set the folder path where the CSV files are located
folderPath = "C:\CSVFiles"

' Create a collection to store the names of the imported files
Set importedFiles = New Collection

' Check if the index sheet already exists, if not, create it
On Error Resume Next
Set indexSheet = ThisWorkbook.Sheets("Index")
On Error GoTo 0
If indexSheet Is Nothing Then
Set indexSheet = ThisWorkbook.Sheets.Add
indexSheet.Name = "Index"
indexSheet.Range("A1").value = "File Name"
indexSheet.Range("B1").value = "Date Imported"
End If

'Loop through all the files in the folder
fileName = Dir(folderPath & "*.csv")
Do While fileName <> ""
' Check if the file has already been imported
If Not IsInCollection(importedFiles, fileName) Then

 'Check if the sheet already exists, if not, create it
On Error Resume Next
Set ws = ThisWorkbook.Sheets(Replace(fileName, ".csv", ""))
On Error GoTo 0
If ws Is Nothing Then
    'Import the data from the CSV file into a new sheet
    Set wb = Workbooks.Open(folderPath & fileName)
    wb.Sheets(1).Copy After:=ThisWorkbook.Sheets(ThisWorkbook.Sheets.Count)
    wb.Close False
    Set ws = ThisWorkbook.Sheets(ThisWorkbook.Sheets.Count)
    ws.Name = Replace(fileName, ".csv", "")
End If


    ' Import the data from the CSV file into a new sheet
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
        .TextFileTabDelimiter = False
        .TextFileSemicolonDelimiter = True
        .TextFileCommaDelimiter = True
        .TextFileSpaceDelimiter = False
        .TextFileSpaceDelimiter = False
.TextFileColumnDataTypes = Array(1, 1, 1, 1, 1, 1)
.TextFileTrailingMinusNumbers = True
.Refresh BackgroundQuery:=False
End With

' Rename the new sheet to the name of the CSV file
Set ws = ActiveSheet
ws.Name = Replace(fileName, ".csv", "")

' Add the file name to the collection of imported files
importedFiles.Add fileName

' Add the date and time the file was imported to the index sheet
lastRow = indexSheet.Cells(indexSheet.Rows.Count, "A").End(xlUp).Row + 1
indexSheet.Cells(lastRow, "A").value = Replace(fileName, ".csv", "")
indexSheet.Cells(lastRow, "B").value = Format(Now, "yyyy-MM-dd hh:mm:ss")

' Add a hyperlink to the newly created sheet in the index sheet
indexSheet.Hyperlinks.Add Anchor:=indexSheet.Cells(lastRow, "A"), Address:="", SubAddress:= _
ws.Name & "!A1", TextToDisplay:=Replace(fileName, ".csv", "")

' Move to the next file
fileName = Dir()

Loop

End Sub



    'code for the add button'
    Sub AddImportButton()
    Dim btn As Button
    Set btn = ThisWorkbook.Sheets(1).Buttons.Add(10, 10, 70, 20)
    btn.Caption = "Import Data"
    btn.OnAction = "ImportCSVFiles"
    btn.Enabled = True
End Sub

