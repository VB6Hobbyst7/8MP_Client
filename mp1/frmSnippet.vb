Imports System.Net
Imports System.Web.Script.Serialization
Imports System.Dynamic

Imports System.Runtime.InteropServices 'for the API



<Runtime.InteropServices.ComVisible(True)>
Public Class frmSnippet


    'two API's to update richtextbox and prevent flicking when typing
    Private Declare Function SendMessage Lib "user32" Alias "SendMessageA" (ByVal hWnd As IntPtr, ByVal wMsg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer
    Private Declare Function LockWindowUpdate Lib "user32" (ByVal hWnd As Integer) As Integer

    'color blue
    Dim vbscriptKeyWords() As String = {"Set", "Rem", "Empty", "Nothing", "Dim"}
    'color red
    Dim vbscriptOperatorKeyWords() As String = {"+", "-", "*", "/", "\", "-", "&", "=",
                                        "<>", "<", "<=", ">", ">=", "SYSTEM_URL", "MEMORY_URL"}
    'color green
    Dim vbscriptWMPKeyWords() As String = {"Return", "localObject", "includeSnippet", "json", "getcache", "setcache"}

    'color magenta
    Dim commentChar As String = "'"


    Dim objApiService As New clsAPIService


    Private Enum EditMessages
        LineIndex = 187
        LineFromChar = 201
        GetFirstVisibleLine = 206
        CharFromPos = 215
        PosFromChar = 1062
    End Enum

    Public Function GetCharFromLineIndex(ByVal LineIndex As Integer) As Integer
        Return SendMessage(rtScriptBox.Handle.ToInt32, EditMessages.LineIndex, LineIndex, 0)
    End Function
    Public Function FirstVisibleLine() As Integer
        Return SendMessage(rtScriptBox.Handle.ToInt32, EditMessages.GetFirstVisibleLine, 0, 0)
    End Function

    Public Function LastVisibleLine() As Integer
        Dim LastLine As Integer = FirstVisibleLine() + (rtScriptBox.Height / rtScriptBox.Font.Height)

        If LastLine > rtScriptBox.Lines.Length Or LastLine = 0 Then
            LastLine = rtScriptBox.Lines.Length
        End If
        Return LastLine
    End Function
    Public Sub ColorRtb()
        Dim FirstVisibleChar As Integer
        Dim i As Integer = 0
        While i < rtScriptBox.Lines.Length
            FirstVisibleChar = GetCharFromLineIndex(i)
            ColorLineNumber(rtScriptBox, i, FirstVisibleChar)
            i += 1
        End While
    End Sub
    Public Sub ColorLineNumber(ByVal rtb As RichTextBox, ByVal LineIndex As Integer, ByVal lStart As Integer)
        Dim TLine As String = rtb.Lines(LineIndex) '.ToLower
        Dim i As Integer = 0
        Dim instance As Integer
        Dim SelectionAt As Integer = rtb.SelectionStart
        ' Lock the update
        LockWindowUpdate(rtb.Handle.ToInt32)
        ' Color the line black to remove any previous coloring 
        rtb.SelectionStart = lStart
        rtb.SelectionLength = TLine.Length
        rtb.SelectionColor = Color.Black
        HighLightWMPKeyWords(rtb) 'WMP
        HighLightOperatorKey(rtb) 'operator keyword
        HighLightKeywords(rtb) 'keyword

        ' Find any comments 
        instance = TLine.IndexOf(commentChar) + 1
        ' If there are comments, color them 
        If instance <> 0 Then
            rtb.SelectionStart = (lStart + instance - 1) 'rtb.SelectionStart = (lStart + instance - 1)
            rtb.SelectionLength = (TLine.Length - instance + 1)
            rtb.SelectionColor = Color.Magenta
        End If

        If instance = 1 Then
            ' Unlock the update, restore the start and exit 
            rtb.SelectionStart = SelectionAt
            rtb.SelectionLength = 0
            LockWindowUpdate(0)
            Exit Sub
            'Return ' TODO: might not be correct. Was : Exit Sub 
        End If

        ' Restore the selectionstart 
        rtb.SelectionStart = SelectionAt
        rtb.SelectionLength = 0

        ' Unlock the update 
        LockWindowUpdate(0)

    End Sub
    Public Sub HighLightKeywords(ByVal rtb As RichTextBox)
        For Each oneWord As String In vbscriptKeyWords
            Dim pos As Integer = 0
            Do While rtb.Text.ToUpper.IndexOf(oneWord.ToUpper, pos) >= 0
                pos = rtb.Text.ToUpper.IndexOf(oneWord.ToUpper, pos)
                rtb.Select(pos, oneWord.Length)
                rtb.SelectionColor = Color.Blue

                pos += 1

            Loop

        Next

    End Sub
    'vbscriptWMPKeyWords
    Public Sub HighLightWMPKeyWords(ByVal rtb As RichTextBox)
        For Each oneWord As String In vbscriptWMPKeyWords
            Dim pos As Integer = 0
            Do While rtb.Text.ToUpper.IndexOf(oneWord.ToUpper, pos) >= 0
                pos = rtb.Text.ToUpper.IndexOf(oneWord.ToUpper, pos)
                rtb.Select(pos, oneWord.Length)
                rtb.SelectionColor = Color.Green
                pos += 1

            Loop

        Next

    End Sub

    Public Sub HighLightOperatorKey(ByVal rtb As RichTextBox)
        For Each oneWord As String In vbscriptOperatorKeyWords

            Dim pos As Integer = 0

            Do While rtb.Text.ToUpper.IndexOf(oneWord.ToUpper, pos) >= 0

                pos = rtb.Text.ToUpper.IndexOf(oneWord.ToUpper, pos)

                rtb.Select(pos, oneWord.Length)
                ' rtb.SelectionFont = New Font("Courier New", 12, FontStyle.Regular)
                rtb.SelectionColor = Color.Red

                pos += 1

            Loop

        Next
    End Sub

    Public Sub ColorVisibleLines(ByVal rtb As RichTextBox)
        Dim FirstLine As Integer = FirstVisibleLine()
        Dim LastLine As Integer = LastVisibleLine()
        Dim FirstVisibleChar As Integer
        Dim i As Integer = FirstLine
        If (FirstLine = 0) And (LastLine = 0) Then
            'If there is no text it will error, so exit the sub
            Exit Sub
        Else
            While i < LastLine
                FirstVisibleChar = GetCharFromLineIndex(FirstLine)
                ColorLineNumber(rtb, FirstLine, FirstVisibleChar)
                FirstLine += 1
                i += 1
            End While
        End If

    End Sub

    Public Function getWidth() As Integer
        Dim w As Integer = 25
        'get total lines of richTextBox1    
        Dim line As Integer = rtScriptBox.Lines.Length
        If line <= 99 Then
            w = 20 + rtScriptBox.Font.Size
        ElseIf (line <= 999) Then
            w = 30 + rtScriptBox.Font.Size
        Else
            w = 50 + rtScriptBox.Font.Size
        End If
        Return w
    End Function

    Public Sub AddLineNumbers()

        '// create & set Point pt to (0,0)    
        Dim pt As Point = New Point(0, 0)
        '// get First Index & First Line from richTextBox1    
        Dim First_Index As Integer = rtScriptBox.GetCharIndexFromPosition(pt)
        Dim First_Line As Integer = rtScriptBox.GetLineFromCharIndex(First_Index)
        '// set X & Y coordinates of Point pt to ClientRectangle Width & Height respectively    
        pt.X = ClientRectangle.Width
        pt.Y = ClientRectangle.Height
        '// get Last Index & Last Line from richTextBox1    
        Dim Last_Index As Integer = rtScriptBox.GetCharIndexFromPosition(pt)
        Dim Last_Line As Integer = rtScriptBox.GetLineFromCharIndex(Last_Index)
        '// set Center alignment to LineNumberTextBox    
        lineTextBox.TextAlign = HorizontalAlignment.Center
        '// set LineNumberTextBox text to null & width to getWidth() function value    
        lineTextBox.Text = ""
        lineTextBox.Width = getWidth()
        '// now add each line number to LineNumberTextBox upto last line  
        Dim i As Integer
        'For (i = First_Line To i <= Last_Line + 2; i++)    
        '    {    
        '        LineNumberTextBox.Text += i + 1 + "\n";    
        '    }    
        For i = First_Line To Last_Line
            lineTextBox.Text += (i + 1).ToString + vbCrLf
            Application.DoEvents()
        Next
    End Sub
    '----End for RichTextBox---


    Private _targetForm As Form
    Public Property targetForm() As Form
        Get
            Return _targetForm
        End Get
        Set(ByVal value As Form)
            _targetForm = value
        End Set
    End Property

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        'showObjectName()



        Dim vCls As New clsMPFlex
        'initial
        vCls.Form = _targetForm
        vCls.Url = Root_url
        vCls.cacheUrl = Cache_url
        'vCls.message = "Test message"
        '------------

        Dim vTestScript As String
        vTestScript = rtScriptBox.Text
        txtReturn.Text = vCls.executeScritp(vTestScript)
        'MsgBox(vCls.Url)
        lblSuccess.Text = vCls.success
        lblMsg.Text = vCls.message
        If Not vCls.success Then
            MsgBox(vCls.error_message)
        End If


    End Sub

    Private Sub rtScriptBox_TextChanged(sender As Object, e As EventArgs) Handles rtScriptBox.TextChanged
        ColorVisibleLines(rtScriptBox)

    End Sub


    Public Shared Function getJsonString(ByVal address As String) As String

        Dim client As WebClient = New WebClient()
        Dim reply As String = client.DownloadString(address)
        Return reply
    End Function

    Public Shared Function getJsonObject(ByVal address As String) As Object

        Dim client As WebClient = New WebClient()
        Dim json As String = client.DownloadString(address)
        Dim jss = New JavaScriptSerializer()
        Dim data As Object = jss.Deserialize(Of Object)(json)
        Return data
    End Function



    'Private Sub Button5_Click(sender As Object, e As EventArgs)
    '    Dim json As Object
    '    json = getJsonObject("http://127.0.0.1:8000/api/snippet/" + txtSnippetSlug.Text)
    '    rtScriptBox.Text = json("code")

    '    'json = getJsonObject("http://127.0.0.1:8000/api/item/" + txtSnippetSlug.Text)
    '    'Dim ccc As String = json("lists")(0)("title")
    '    'Dim x As Object
    '    'For Each x In json("lists")
    '    '    ccc = x("title")
    '    'Next
    'End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        lineTextBox.Font = rtScriptBox.Font
        AddLineNumbers()

        objApiService.Url = Root_url
        objApiService.access_token = access_token
        timerExp.Enabled = True
    End Sub

    Private Sub Form1_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        AddLineNumbers()
    End Sub

    Private Sub timerExp_Tick(sender As Object, e As EventArgs) Handles timerExp.Tick
        Dim elapsed_time As TimeSpan

        Dim stop_time As Date
        stop_time = exp_token
        elapsed_time = stop_time.Subtract(Now)
        lblExpToken.Text =
                elapsed_time.TotalMinutes.ToString("0.00")

        'Root_url --> from module mdlWMP
        If elapsed_time.TotalSeconds < 20 Then
            timerExp.Enabled = False

            Dim clsAuthen As clsAuthentication = New clsAuthentication(
            Root_url, login_user, login_password)

            Dim vTokenResult As Boolean
            vTokenResult = clsAuthen.requestToken()

            'Assign public variable (MUST -- Very Importance)
            user_id = clsAuthen.user_id_token
            access_token = clsAuthen.access_token
            'refresh_token = clsAuthen.requestToken

            objApiService.access_token = access_token

            Dim ii As Integer = clsAuthen.exp
            Dim epoch = New DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            exp_token = epoch.AddSeconds(ii).ToLocalTime
            timerExp.Enabled = True
        End If



    End Sub

    Private Sub rtScriptBox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles rtScriptBox.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            lineTextBox.Text = ""
            AddLineNumbers()
            lineTextBox.Invalidate()
        End If
    End Sub


    'Private Sub rtScriptBox_SelectionChanged(sender As Object, e As EventArgs) Handles rtScriptBox.SelectionChanged
    '    Dim pt As Point = rtScriptBox.GetPositionFromCharIndex(rtScriptBox.SelectionStart)
    '    If pt.X = 1 Then
    '        AddLineNumbers()
    '    End If

    'End Sub

    Private Sub rtScriptBox_VScroll(sender As Object, e As EventArgs) Handles rtScriptBox.VScroll
        lineTextBox.Text = ""
        If lineTextBox.Height >= rtScriptBox.Height Then
            lineTextBox.Height = rtScriptBox.Height
        End If
        AddLineNumbers()
        lineTextBox.Invalidate()
    End Sub

    'Private Sub rtScriptBox_FontChanged(sender As Object, e As EventArgs) Handles rtScriptBox.FontChanged
    '    lineTextBox.Font = rtScriptBox.Font
    '    rtScriptBox.Select()
    '    AddLineNumbers()
    'End Sub

    'Private Sub rtScriptBox_MouseDown(sender As Object, e As MouseEventArgs) Handles rtScriptBox.MouseDown
    '    rtScriptBox.Select()
    '    lineTextBox.Invalidate()
    'End Sub


    'Private Sub Button2_Click(sender As Object, e As EventArgs)
    '    'MsgBox(getLocalObjectValue("button2"))

    '    Dim vvvv As ucTest
    '    vvvv = Controls("uctest1")
    '    MsgBox(vvvv.Controls("textbox2").Text)

    '    ' MsgBox(CallByName(vvvv, "getLocalObjectValue", Microsoft.VisualBasic.CallType.Get, "textbox2"))

    'End Sub


    'Private Sub GetResponse(uri As Uri, callback As Action(Of Response))
    '    Dim wc As New WebClient()
    '    AddHandler wc.OpenReadCompleted,
    '        Function(o, a)
    '            If callback IsNot Nothing Then
    '                Dim ser As New DataContractJsonSerializer(GetType(Response))
    '                callback(TryCast(ser.ReadObject(a.Result), Response))
    '            End If
    '            Return 0
    '        End Function
    '    wc.OpenReadAsync(uri)
    'End Sub







    '--------Mandatory Funtion for all User Controls-------------
    '--------DO NOT change---------------------------------------
    Public Property getLocalObjectValue(ByVal vObjectName As String) As String

        Get
            Dim vStep() As String
            vStep = Split(vObjectName, ".")
            If UBound(vStep) = 1 Then
                Dim nControl As Control
                nControl = Controls(vStep(0))
                getLocalObjectValue = ""
                'getLocalObjectValue = nControl.getLocalObjectValue(vStep(1))
                getLocalObjectValue = CallByName(nControl, "getLocalObjectValue", Microsoft.VisualBasic.CallType.Get, vStep(1))

            Else
                'getLocalObjectValue = UserControl.Controls(vObjectName)
                getLocalObjectValue = Controls(vObjectName).Text
            End If
        End Get
        Set(ByVal vName As String)
            ' Sets the property value.
            'currentForm = vForm_
        End Set


    End Property

    'Public Property CurrentForm() As Form
    '    Get
    '    End Get
    '    Set(ByVal vCurrForm As Form)
    '        vCurrentFormIn = vCurrForm
    '    End Set
    'End Property

    'Sub initODCSEscript()
    '    objOdcsys.setCustomForm = Me
    '    objOdcsys.setAllowUI = True
    '    objOdcsys.setOnCustomControl

    '    objPrint.setCustomForm = Me
    '    objPrint.setAllowUI = True
    '    objPrint.setOnCustomControl
    'End Sub

    Private Sub showObjectName()
        'On Error Resume Next
        Dim nControl As Control
        Dim toolTip1 As New ToolTip()
        Dim strObjName As String



        For Each nControl In Me.Controls
            strObjName = TypeName(nControl)

            If TypeOf nControl Is UserControl Then
                'Call Show Object for usercontrol
                'nControl.showObjectName()
                'cccc = 0
            Else
                'nControl.Text = nControl.Name
                toolTip1.SetToolTip(nControl, nControl.Name)
            End If
            'If Not TypeOf Me.ParentForm Is Form Then
            '    nControl.set = UserControl.ParentControls.Item(0).Name & "." & Extender.Name & "." & nControl.Name
            'Else
            '    nControl.ToolTipText = Extender.Name & "." & nControl.Name
            'End If
        Next
    End Sub
    '--------End Mandatory Funtion for all User Controls-------------

End Class


