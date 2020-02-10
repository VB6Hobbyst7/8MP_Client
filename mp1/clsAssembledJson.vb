Imports System.Collections.Generic

Public Class clsAssembledJson
    Public Property number As Long
    Public Property pn As String
    Public Property refdes As String
    Public Property pn_type As String
    Public Property module_number As Long
    Public Property component_number As String
    Public Property operation As String
    Public Property note As String
    Public Property action_status As Boolean
    Public Property user As String
    Public Property module_name As String
End Class


'           "number" 2,
'            "pn": "PN001",
'            "rev": "R1",
'            "pn_type": "MODULE",
'            "refdes": "C1",
'            "module_number": 4,
'            "component_number": "COM3",
'            "operation": "Inspection",
'            "note": "test",
'            "action_date": "2020-02-09T11:51:59.030229",
'            "action_status": true,
'            "user": 1,