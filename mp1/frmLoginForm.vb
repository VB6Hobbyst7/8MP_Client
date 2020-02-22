Imports System.IO
Imports System.Net
Imports System.Net.Http
Imports System.Net.Http.Headers
Imports System.Reflection
Imports System.Text
Imports System.Web.Script.Serialization






Public Class frmLoginForm

    ' TODO: Insert code to perform custom authentication using the provided username and password 
    ' (See https://go.microsoft.com/fwlink/?LinkId=35339).  
    ' The custom principal can then be attached to the current thread's principal as follows: 
    '     My.User.CurrentPrincipal = CustomPrincipal
    ' where CustomPrincipal is the IPrincipal implementation used to perform authentication. 
    ' Subsequently, My.User will return identity information encapsulated in the CustomPrincipal object
    ' such as the username, display name, etc.

    Dim objApiService As New clsAPIService
    Dim vUrl As String

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim vTokenResult As Boolean
            Dim user As String
            Dim password As String

            user = UsernameTextBox.Text
            password = PasswordTextBox.Text

            login_user = user
            login_password = password

            'Root_url --> from module mdlWMP
            Dim clsAuthen As clsAuthentication = New clsAuthentication(
                Root_url, user, password)


            vTokenResult = clsAuthen.requestToken()
            lblStatus.Text = clsAuthen.Message
            lblStatus.ForeColor = IIf(vTokenResult, Color.Green, Color.Red)

            'Assign public variable (MUST -- Very Importance)
            user_id = clsAuthen.user_id_token
            access_token = clsAuthen.access_token
            refresh_token = clsAuthen.refresh_token
            Dim ii As Integer = clsAuthen.exp
            Dim epoch = New DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            exp_token = epoch.AddSeconds(ii).ToLocalTime

            '------------------------
            ', DateTimeKind.Local

            If vTokenResult Then

                objApiService.Url = Root_url
                objApiService.access_token = access_token
                vUrl = Root_url

                getUserOperation(user_id)
                'frmParameter.Show()
                'Form1.Show()
                'Me.Close()
                OK.Enabled = False
                btnOpen.Enabled = True
                Cancel.Enabled = True
                UsernameTextBox.Enabled = False
                PasswordTextBox.Enabled = False
            Else
                UsernameTextBox.Enabled = True
                PasswordTextBox.Enabled = True
                OK.Enabled = True
                btnOpen.Enabled = False
                Cancel.Enabled = False
                cbOperation.DataSource = Nothing
                MsgBox("Invalid Username or Password , please try again", MsgBoxStyle.Critical, "Invalid User")
            End If
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
        End Try


    End Sub

    Sub checkOperationType(Optional vOperationId As String = "")
        Dim operation As Object = Nothing
        If vOperationId <> "" Then
            operation = objApiService.getJsonObject(vUrl + "/api/operation/" & vOperationId & "/")
        Else
            Exit Sub
        End If




        If Not operation Is Nothing Then

            'gOperationType = operation("operation_type")
            'gOperationSlug = operation("slug")
            'gOperationName = operation("name")
            Select Case operation("operation_type")
                Case "ASSEMBLY"
                    frmAssembly.operation = vOperationId
                    frmAssembly.ShowDialog()

                Case "REGISTRATION"
                    frmParameter.operation = vOperationId
                    frmParameter.ShowDialog()
                Case "INSPECTION"
                    frmInspection.operation = vOperationId
                    frmInspection.ShowDialog()
            End Select
        End If
    End Sub

    Sub getUserOperation(Optional vUserId As String = "")
        Dim operations As Object
        Dim operation As Object

        'if vUserId is Blank --> get all existing operation
        'if exist -->get only authorize operation

        If vUserId <> "" Then
            operations = objApiService.getJsonObject(vUrl + "/api/profile/" & vUserId & "/operations/") '("operations")
        Else
            operations = objApiService.getJsonObject(vUrl + "/api/operation/")
        End If

        Try
            If Not operations Is Nothing Then
                Dim comboSource As New Dictionary(Of String, String)()

                comboSource.Add("", "---")
                For Each operation In operations
                    comboSource.Add(operation("operation")("name") & ":" &
                                    operation("operation")("title"), operation("operation")("slug")
                                    )
                Next
                With cbOperation
                    .DropDownStyle = ComboBoxStyle.DropDownList
                    .DataSource = New BindingSource(comboSource, Nothing)
                    .DisplayMember = "Key"
                    .ValueMember = "Value"
                    '.SelectedValue = vDefaultValue
                    .Items.Insert(0, String.Empty)
                End With
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        'Me.Close()
        UsernameTextBox.Enabled = True
        PasswordTextBox.Enabled = True

        cbOperation.DataSource = Nothing
        UsernameTextBox.Text = ""
        PasswordTextBox.Text = ""
        lblStatus.Text = ""
        UsernameTextBox.Select()
        OK.Enabled = True
        btnOpen.Enabled = False
        Cancel.Enabled = False
    End Sub

    Private Sub UsernameTextBox_TextChanged(sender As Object, e As EventArgs) Handles UsernameTextBox.TextChanged
        lblStatus.Text = ""
    End Sub

    Private Sub PasswordTextBox_TextChanged(sender As Object, e As EventArgs) Handles PasswordTextBox.TextChanged
        lblStatus.Text = ""
    End Sub

    Private Sub frmLoginForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim fName As String = "system.ini"              'path to text file
        Dim My_Ini As New clsIni(fName)

        Root_url = My_Ini.GetValue("Setting", "core_url")
        Cache_url = My_Ini.GetValue("Setting", "cache_url")

        Dim versionNumber As Version

        versionNumber = Assembly.GetExecutingAssembly().GetName().Version
        Me.Text = Me.Text & " version :" & versionNumber.ToString
        lblServer.Text = "8MP Server : " & Root_url

        'Me.Text = Me.Text + " Server :" & Root_url
    End Sub

    Private Sub btnOpen_Click(sender As Object, e As EventArgs) Handles btnOpen.Click
        Dim key As String = DirectCast(cbOperation.SelectedItem, KeyValuePair(Of String, String)).Key
        Dim value As String = DirectCast(cbOperation.SelectedItem, KeyValuePair(Of String, String)).Value 'slug
        If key = "" Then
            Exit Sub
        End If
        checkOperationType(value)
    End Sub
End Class
