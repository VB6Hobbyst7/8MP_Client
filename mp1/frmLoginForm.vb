Imports System.IO
Imports System.Net
Imports System.Net.Http
Imports System.Net.Http.Headers
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

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
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
        'refresh_token = clsAuthen.requestToken
        Dim ii As Integer = clsAuthen.exp
        Dim epoch = New DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)
        exp_token = epoch.AddSeconds(ii).ToLocalTime

        '------------------------
        ', DateTimeKind.Local

        If vTokenResult Then
            frmParameter.Show()
            'Form1.Show()
            'Me.Close()
        Else
            MsgBox("Invalid Username or Password , please try again", MsgBoxStyle.Critical, "Invalid User")
        End If

    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Close()
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
        Me.Text = Me.Text + " Server :" & Root_url
    End Sub
End Class
