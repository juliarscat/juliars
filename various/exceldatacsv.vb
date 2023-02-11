Sub ImportCSVFiles()
Dim folderPath As String
Dim fileName As String
Dim ws As Worksheet
Dim indexSheet As Worksheet
Dim lastRow As Long
Dim wb As Workbook
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

    'Add the date and time the file was imported to the index sheet
    lastRow = indexSheet.Cells(indexSheet.Rows.Count, "A").End(xlUp).Row + 1
    indexSheet.Cells(lastRow, "A").Value = Replace(fileName, ".csv", "")
    indexSheet.Cells(lastRow, "B").Value = Format(Now, "yyyy-MM-dd hh:mm:ss")
    indexSheet.Hyperlinks.Add Anchor:=indexSheet.Cells(lastRow, "A"), Address:="", SubAddress:= _
        ws.Name & "!A1", TextToDisplay:=Replace(fileName, ".csv", "")

    'Move to the next file
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

